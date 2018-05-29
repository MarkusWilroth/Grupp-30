using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCopier
{
    /// <summary>
    /// The modifier object
    /// </summary>
    public class Modifier
    {
        /// <summary>
        /// Fields
        /// </summary>
        private int count;              // Total number of strings to test
        private CircularBuffer cBuffer;   // The shared resource

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="nrOfStrings"></param>
        public Modifier(CircularBuffer buffer, int nrOfStrings)
        {
            count = nrOfStrings;
            cBuffer = buffer;
        }

        /// <summary>
        /// The threadloop
        /// </summary>
        public void ModifierLoop()
        {
             for (int i = 0; i < count; i++)
             {
                cBuffer.Modify();
             }
        }
    }
}
