using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;

namespace FileCopier
{
    /// <summary>
    /// The shared data, the circular string buffer
    /// </summary>
    public class CircularBuffer //Bounded buffer
    {
        /// <summary>
        /// Fields
        /// </summary>
        private string[] stringArray;                // The actual string buffer array
        private int maxBufferSize;                        // Elements in buffer
        private int writePos;                   // The position pointers for each thread
        private int readPos;
        private int findPos;
        private BufferStatus[] status;                // An array of Status objects, one for each element in buffer
        private RichTextBox rtxBox;             // The rich text box to mark in
        private string findString;              // The string to search for, if any
        private string replaceString;           // The replace string, if any
        private int start;                      // The start position in textbox for marking
        private int numOfReplacements;            // Replacement counter
        private bool notify;                    // User notify
        private object lockObject;              // For ME

        private delegate void Marker();         // Delegate used in textbox invoke
        private delegate void Selector();       // Delegate used in textbox invoke 

        public int GetNrReplace { get { return numOfReplacements; } }

        /// <summary>
        /// Parametric constructor
        /// </summary>
        /// <param name="size">No of elements in buffer</param>
        /// <param name="rt">The source rich text box</param>
        /// <param name="notify">User notification</param>
        /// <param name="find">Find string</param>
        /// <param name="replace">Replace string</param>
        public CircularBuffer(int size, RichTextBox rt, bool notify, string find, string replace)
        {
            maxBufferSize = size;
            writePos = 0;               // Start all three pointers from 0
            readPos = 0;
            findPos = 0;
            stringArray = new string[maxBufferSize];   // Create the actual buffer
            status = new BufferStatus[maxBufferSize];   // and the corresponding status array
            for (int i = 0; i < maxBufferSize; status[i++] = BufferStatus.Empty) ; // Status is empty from start
            rtxBox = rt;
            start = 0;
            numOfReplacements = 0;
            this.notify = notify;
            findString = find;
            replaceString = replace;
            lockObject = new object();
        }

        public string ReadData()
        {
            string hlp = string.Empty;

            lock (lockObject) //alt monitor.enter??????
            {
                while (status[readPos] != BufferStatus.Checked)
                {
                    Monitor.Wait(lockObject);
                }

                status[readPos] = BufferStatus.Empty;
                hlp = stringArray[readPos];
                readPos = (readPos + 1) % maxBufferSize;
                Monitor.PulseAll(lockObject);

                return hlp;
            }
        }

        public void WriteData(string s)
        {
            lock (lockObject)
            {
                while (status[writePos] != BufferStatus.Empty)
                {
                    Monitor.Wait(lockObject);
                }

                stringArray[writePos] = s;
                status[writePos] = BufferStatus.New;
                writePos = (writePos + 1) % maxBufferSize;
                Monitor.PulseAll(lockObject);
            }
        }

        public void Modify()
        {
            string s;       //Temporary string
            int start = 0;  //Next startpos in string to test
            int pos;        //Next match position in string to test

            lock (lockObject)
            {
                while (status[findPos] != BufferStatus.New)
                {
                    Monitor.Wait(lockObject);
                }

                if (!string.IsNullOrEmpty(findString))
                {
                    s = stringArray[findPos];
                    while (true)
                    {
                        pos = s.IndexOf(findString, start);
                        if (pos < 0) break;
                        rtxBox.Invoke(new Selector(Select));
                        if (string.IsNullOrWhiteSpace(replaceString))
                        {
                            rtxBox.Invoke(new Marker(Mark));
                            start = pos + replaceString.Length;
                            continue;
                        }

                        if (!notify || MessageBox.Show("Replace " + findString + " with " + replaceString, "Replace", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            s = ReplaceAt(s, replaceString, pos, findString.Length);
                            rtxBox.Invoke(new Marker(Mark));
                            start = pos + replaceString.Length;
                            numOfReplacements++;
                        }
                        else
                        {
                            start = pos + findString.Length;
                        }
                    }

                    stringArray[findPos] = s;
                }
                status[findPos] = BufferStatus.Checked;
                findPos = (findPos + 1) % maxBufferSize;
                Monitor.PulseAll(lockObject);
            }
        }

        /// <summary>
        /// Method to call in textbox invoke
        /// Mark the selection area
        /// </summary>
        private void Mark()
        {
            rtxBox.SelectionBackColor = Color.Green;
            rtxBox.SelectionColor = Color.White;
        }

        /// <summary>
        /// Method to call in textbox invoke
        /// Select next occurace of findstring, and advance start
        /// </summary>
        private void Select()
        {
            int pos;
            pos = rtxBox.Find(findString, start, RichTextBoxFinds.MatchCase);
            rtxBox.SelectionStart = pos;
            rtxBox.SelectionLength = findString.Length;
            start = pos + findString.Length;
        }

        /// <summary>
        /// Extending string operations with a ReplaceAt method
        /// Replaces rep in s at pos
        /// </summary>
        /// <param name="s">The string to alter</param>
        /// <param name="rep">The string to replace</param>
        /// <param name="pos">The position to replace</param>
        /// <param name="size">The number of characters to remove at pos before inserting rep</param>
        /// <returns></returns>
        private string ReplaceAt(string s, string rep, int pos, int size)
        {
            string s1 = s.Substring(0, pos);                            // Get a string from start up to string to remove
            string s2 = s.Substring(pos + size, s.Length - pos - size); // Get the remaining string after string to remove
            return s1 + rep + s2;                                       // Mix these with replacement
        }
    }
}
