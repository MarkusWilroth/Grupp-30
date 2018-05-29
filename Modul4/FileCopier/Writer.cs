using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCopier
{
    /// <summary>
    /// The writer object
    /// </summary>
    public class Writer
    {
        private List<string> textToWrite;
        private CircularBuffer buffer;

        public Writer(CircularBuffer buffer, List<string> textIn)
        {
            textToWrite = textIn;
            this.buffer = buffer;
        }

        /// <summary>
        /// The threadloop
        /// </summary>
        public void WriteLoop()
        {
            foreach(string s in textToWrite)
            {
                buffer.WriteData(s);
            }
        }
    }
}
