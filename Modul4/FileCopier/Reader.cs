using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCopier
{
    /// <summary>
    /// The reader object
    /// </summary>
    public class Reader
    {
        private int count;
        private CircularBuffer buffer;
        private List<string> stringList;

        /// <summary>
        /// Property for retrieveing the result string list
        /// </summary>
        public List<string> GetText { get { return stringList; } }

        public Reader(CircularBuffer buffer, int numOfStrings)
        {
            count = numOfStrings;
            this.buffer = buffer;
            stringList = new List<string>();
        }

        /// <summary>
        /// The threadloop
        /// </summary>
        public void ReadLoop()
        {
            for (int i = 0; i < count; i++)
            {
                stringList.Add(buffer.ReadData());
            }
        }
    }
}
