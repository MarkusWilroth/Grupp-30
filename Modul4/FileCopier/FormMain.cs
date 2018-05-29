using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace FileCopier
{
    /// <summary>
    /// The only GUI needed
    /// </summary>
    public partial class FormMain : Form
    {
        /// <summary>
        /// Fields
        /// </summary>
        /// 
        private StreamReader sReader;
        private StreamWriter sWriter;

        private string sourceFileName;             // The actual filename
        private string targetFileName;
        private List<string> textStrings;   // The list of strings making the source file
        private CircularBuffer buffer;        // The shared data, a circular string buffer
        private Writer writer;              // The string writer
        private Reader reader;              // The string reader
        private Modifier modifier;          // The string modifier
        private Thread wrThread;            // The corresponding threads
        private Thread rdThread;
        private Thread modifyThread;

        /// <summary>
        /// Default constructor
        /// </summary>
        public FormMain()
        {
            // The find/replace groupbox and the create button is disabled
            //until a valid source- and destination file is selected
            InitializeComponent();
            grpFind.Enabled = false;
            btnCreate.Enabled = false;
            sourceFileName = string.Empty;
            targetFileName = string.Empty;
            textStrings = new List<string>();           
            btnClear.Enabled = false;
            
        }

        /// <summary>
        /// The create destination file button, starts a copy
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreate_Click(object sender, EventArgs e)
        {
            // Create a circular buffer with 10 elements, send sourcetextbox, notify status, and strings for find/replace
            buffer = new CircularBuffer(10, rtxSrc, chkNotify.Checked, txtFind.Text, txtReplace.Text);

            writer = new Writer(buffer, textStrings);
            reader = new Reader(buffer, textStrings.Count);
            modifier = new Modifier(buffer, textStrings.Count); // Create the modifier also with nr of strings to check
            wrThread = new Thread(writer.WriteLoop);
            rdThread = new Thread(reader.ReadLoop);
            modifyThread = new Thread(modifier.ModifierLoop);
            wrThread.Start();                                   // and start all 3
            rdThread.Start();
            modifyThread.Start();

            // Wait until all threads done
            while (wrThread.IsAlive || rdThread.IsAlive || modifyThread.IsAlive) Application.DoEvents();
            rtxSrc.SelectionStart = 0;                          // Just for removing the last selection in source textbox but
            rtxSrc.SelectionLength = 0;                         // leaving the markings
            CreateDestinatinFile();                             // Then set up for output
        }

        /// <summary>
        /// Menu exit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Ev. stop running threads
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(System.Environment.ExitCode);
        }

        /// <summary>
        /// Menu file open source file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuFileOpen_Click(object sender, EventArgs e)
        {
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                sourceFileName = dlgOpen.FileName;
                try
                {
                    sReader = new StreamReader(sourceFileName);
                    while (!sReader.EndOfStream)
                    {
                        string s = sReader.ReadLine();
                        rtxSrc.AppendText(s + "\n");    // Store string in text box
                        textStrings.Add(s);             // also in list for copy
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Could not open source file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                finally
                {
                    sReader.Close();
                }
            }
            grpFind.Enabled = true;
            btnCreate.Enabled = true;
            lblInfo.Visible = false;
        }

   
        /// <summary>
        /// Read source
        /// </summary>
        private void FillSrcList()
        {
            
        }

        /// <summary>
        /// Mark or unmark a region in a textbox
        /// </summary>
        /// <param name="box">The textbox to alter</param>
        /// <param name="mark">mark/unmark</param>
        /// <param name="s">The string to search for</param>
        private void MarkUnmark(Box box, bool mark, string s)
        {
            int start = 0;          // Start position for next search
            int pos = 0;            // The position of next found string
            RichTextBox rtb;

            if (box == Box.Src)
                rtb = rtxSrc;
            else
                rtb = rtxDst;       // Set which textbox to mark/unmark
            while (true)            // Loop until no more matches
            {
                pos = rtb.Find(s, start, RichTextBoxFinds.MatchCase);   // Get next found position
                if (pos == -1) break;                                   // If no more, end
                rtb.SelectionStart = pos;                               // Else set this position as selection start
                rtb.SelectionLength = s.Length;                         // The selection length is the length of search string
                if (mark)
                {
                    rtb.SelectionBackColor = Color.Green;               // If to mark make this selection region white text on green background
                    rtb.SelectionColor = Color.White;
                }
                else
                {
                    rtb.SelectionBackColor = Color.White;               // If to unmark this region, set it back to black text on white background
                    rtb.SelectionColor = Color.Black;
                }
                start = pos + s.Length;                                 // Advance the start pointer to after the selection
            }                                                           // and search for more
            rtb.SelectionStart = 0;                                     // After marking/unmarking remove the latest selection, leaving the marks
            rtb.SelectionLength = 0;
        }

        /// <summary>
        /// Clear the destination textbox and remove markers in source textbox
        /// Disable the result and this button again
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            rtxDst.Clear();
            MarkUnmark(Box.Src, false, txtFind.Text);
            lblResult.Text = "No Replacements:"; 
            btnClear.Enabled = false;
        }

        /// <summary>
        /// The final step is to create output
        /// </summary>
        private void CreateDestinatinFile()
        {
            List<string> temp = reader.GetText;                      // Get the list of (ev.) modified strings from reader
            foreach (string s in temp)
                rtxDst.AppendText(s + "\n");                        // Write in destination text box
            if (!string.IsNullOrWhiteSpace(txtReplace.Text))
                MarkUnmark(Box.Dst, true, txtReplace.Text);         // If replaces made, mark those in destination text box
            lblResult.Text = "No Replacements:" + buffer.GetNrReplace; // Update result (nr of replacements)                             
            btnClear.Enabled = true;

            if (dlgDest.ShowDialog() == DialogResult.OK)
            {
                try                                                     // Finally just write the strings to destination file
                {
                    sWriter = new StreamWriter(dlgDest.FileName);
                    foreach (string s in temp)
                        sWriter.WriteLine(s);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Could not save destination file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    sWriter.Close();
                }
            }
        }
    }
}
