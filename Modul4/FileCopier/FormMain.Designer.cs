namespace FileCopier
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose (bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose ( );
            }
            base.Dispose ( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ( )
        {
            this.grpFind = new System.Windows.Forms.GroupBox ( );
            this.chkNotify = new System.Windows.Forms.CheckBox ( );
            this.label2 = new System.Windows.Forms.Label ( );
            this.label1 = new System.Windows.Forms.Label ( );
            this.txtReplace = new System.Windows.Forms.TextBox ( );
            this.txtFind = new System.Windows.Forms.TextBox ( );
            this.btnCreate = new System.Windows.Forms.Button ( );
            this.menuStrip1 = new System.Windows.Forms.MenuStrip ( );
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem ( );
            this.mnuFileOpen = new System.Windows.Forms.ToolStripMenuItem ( );
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator ( );
            this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem ( );
            this.tabFiles = new System.Windows.Forms.TabControl ( );
            this.Source = new System.Windows.Forms.TabPage ( );
            this.rtxSrc = new System.Windows.Forms.RichTextBox ( );
            this.Destination = new System.Windows.Forms.TabPage ( );
            this.rtxDst = new System.Windows.Forms.RichTextBox ( );
            this.lblInfo = new System.Windows.Forms.Label ( );
            this.dlgOpen = new System.Windows.Forms.OpenFileDialog ( );
            this.dlgDest = new System.Windows.Forms.SaveFileDialog ( );
            this.lblResult = new System.Windows.Forms.Label ( );
            this.btnClear = new System.Windows.Forms.Button ( );
            this.grpFind.SuspendLayout ( );
            this.menuStrip1.SuspendLayout ( );
            this.tabFiles.SuspendLayout ( );
            this.Source.SuspendLayout ( );
            this.Destination.SuspendLayout ( );
            this.SuspendLayout ( );
            // 
            // grpFind
            // 
            this.grpFind.Controls.Add ( this.chkNotify );
            this.grpFind.Controls.Add ( this.label2 );
            this.grpFind.Controls.Add ( this.label1 );
            this.grpFind.Controls.Add ( this.txtReplace );
            this.grpFind.Controls.Add ( this.txtFind );
            this.grpFind.Location = new System.Drawing.Point ( 12, 32 );
            this.grpFind.Name = "grpFind";
            this.grpFind.Size = new System.Drawing.Size ( 446, 122 );
            this.grpFind.TabIndex = 0;
            this.grpFind.TabStop = false;
            this.grpFind.Text = "Find and Replace";
            // 
            // chkNotify
            // 
            this.chkNotify.AutoSize = true;
            this.chkNotify.Location = new System.Drawing.Point ( 88, 87 );
            this.chkNotify.Name = "chkNotify";
            this.chkNotify.Size = new System.Drawing.Size ( 152, 17 );
            this.chkNotify.TabIndex = 4;
            this.chkNotify.Text = "Notify user on every match";
            this.chkNotify.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point ( 10, 61 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size ( 72, 13 );
            this.label2.TabIndex = 3;
            this.label2.Text = "Replace with:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point ( 7, 40 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size ( 30, 13 );
            this.label1.TabIndex = 2;
            this.label1.Text = "Find:";
            // 
            // txtReplace
            // 
            this.txtReplace.Location = new System.Drawing.Point ( 88, 60 );
            this.txtReplace.Name = "txtReplace";
            this.txtReplace.Size = new System.Drawing.Size ( 327, 20 );
            this.txtReplace.TabIndex = 1;
            // 
            // txtFind
            // 
            this.txtFind.Location = new System.Drawing.Point ( 88, 33 );
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size ( 327, 20 );
            this.txtFind.TabIndex = 0;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point ( 485, 119 );
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size ( 180, 23 );
            this.btnCreate.TabIndex = 1;
            this.btnCreate.Text = "Create the Destination File";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler ( this.btnCreate_Click );
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange ( new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile} );
            this.menuStrip1.Location = new System.Drawing.Point ( 0, 0 );
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size ( 698, 24 );
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange ( new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileOpen,
            this.toolStripSeparator1,
            this.mnuFileExit} );
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size ( 37, 20 );
            this.mnuFile.Text = "File";
            // 
            // mnuFileOpen
            // 
            this.mnuFileOpen.Name = "mnuFileOpen";
            this.mnuFileOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mnuFileOpen.Size = new System.Drawing.Size ( 206, 22 );
            this.mnuFileOpen.Text = "Open Source File";
            this.mnuFileOpen.Click += new System.EventHandler ( this.mnuFileOpen_Click );
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size ( 203, 6 );
            // 
            // mnuFileExit
            // 
            this.mnuFileExit.Name = "mnuFileExit";
            this.mnuFileExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.mnuFileExit.Size = new System.Drawing.Size ( 206, 22 );
            this.mnuFileExit.Text = "Exit";
            this.mnuFileExit.Click += new System.EventHandler ( this.mnuFileExit_Click );
            // 
            // tabFiles
            // 
            this.tabFiles.Controls.Add ( this.Source );
            this.tabFiles.Controls.Add ( this.Destination );
            this.tabFiles.Location = new System.Drawing.Point ( 12, 170 );
            this.tabFiles.Name = "tabFiles";
            this.tabFiles.SelectedIndex = 0;
            this.tabFiles.Size = new System.Drawing.Size ( 653, 359 );
            this.tabFiles.TabIndex = 3;
            // 
            // Source
            // 
            this.Source.Controls.Add ( this.rtxSrc );
            this.Source.Location = new System.Drawing.Point ( 4, 22 );
            this.Source.Name = "Source";
            this.Source.Padding = new System.Windows.Forms.Padding ( 3 );
            this.Source.Size = new System.Drawing.Size ( 645, 333 );
            this.Source.TabIndex = 0;
            this.Source.Text = "Source";
            this.Source.UseVisualStyleBackColor = true;
            // 
            // rtxSrc
            // 
            this.rtxSrc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtxSrc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxSrc.Font = new System.Drawing.Font ( "Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)) );
            this.rtxSrc.HideSelection = false;
            this.rtxSrc.Location = new System.Drawing.Point ( 3, 3 );
            this.rtxSrc.Name = "rtxSrc";
            this.rtxSrc.Size = new System.Drawing.Size ( 639, 327 );
            this.rtxSrc.TabIndex = 0;
            this.rtxSrc.Text = "";
            // 
            // Destination
            // 
            this.Destination.Controls.Add ( this.rtxDst );
            this.Destination.Location = new System.Drawing.Point ( 4, 22 );
            this.Destination.Name = "Destination";
            this.Destination.Padding = new System.Windows.Forms.Padding ( 3 );
            this.Destination.Size = new System.Drawing.Size ( 645, 333 );
            this.Destination.TabIndex = 1;
            this.Destination.Text = "Destination";
            this.Destination.UseVisualStyleBackColor = true;
            // 
            // rtxDst
            // 
            this.rtxDst.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtxDst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxDst.Font = new System.Drawing.Font ( "Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)) );
            this.rtxDst.Location = new System.Drawing.Point ( 3, 3 );
            this.rtxDst.Name = "rtxDst";
            this.rtxDst.Size = new System.Drawing.Size ( 639, 327 );
            this.rtxDst.TabIndex = 0;
            this.rtxDst.Text = "";
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point ( 485, 42 );
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size ( 88, 13 );
            this.lblInfo.TabIndex = 4;
            this.lblInfo.Text = "Select source file";
            // 
            // dlgOpen
            // 
            this.dlgOpen.Filter = "Text Files (*.txt) |*.txt";
            this.dlgOpen.Title = "Select Text Source File";
            // 
            // dlgDest
            // 
            this.dlgDest.CheckPathExists = false;
            this.dlgDest.Filter = "Text Files (*.txt)|*.txt";
            this.dlgDest.Title = "Select or set filename for Destination name";
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point ( 279, 161 );
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size ( 98, 13 );
            this.lblResult.TabIndex = 5;
            this.lblResult.Text = "No Replacements: ";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point ( 485, 151 );
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size ( 180, 23 );
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Clear Dest. and remove mark";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler ( this.btnClear_Click );
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF ( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size ( 698, 532 );
            this.Controls.Add ( this.btnClear );
            this.Controls.Add ( this.lblResult );
            this.Controls.Add ( this.lblInfo );
            this.Controls.Add ( this.tabFiles );
            this.Controls.Add ( this.btnCreate );
            this.Controls.Add ( this.grpFind );
            this.Controls.Add ( this.menuStrip1 );
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMain";
            this.Text = "Text File Copier - with Find and Replace";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler ( this.FrmMain_FormClosing );
            this.grpFind.ResumeLayout ( false );
            this.grpFind.PerformLayout ( );
            this.menuStrip1.ResumeLayout ( false );
            this.menuStrip1.PerformLayout ( );
            this.tabFiles.ResumeLayout ( false );
            this.Source.ResumeLayout ( false );
            this.Destination.ResumeLayout ( false );
            this.ResumeLayout ( false );
            this.PerformLayout ( );

        }

        #endregion

        private System.Windows.Forms.GroupBox grpFind;
        private System.Windows.Forms.CheckBox chkNotify;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtReplace;
        private System.Windows.Forms.TextBox txtFind;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuFileOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuFileExit;
        private System.Windows.Forms.TabControl tabFiles;
        private System.Windows.Forms.TabPage Source;
        private System.Windows.Forms.TabPage Destination;
        private System.Windows.Forms.RichTextBox rtxSrc;
        private System.Windows.Forms.RichTextBox rtxDst;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.OpenFileDialog dlgOpen;
        private System.Windows.Forms.SaveFileDialog dlgDest;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Button btnClear;
    }
}

