using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CharacterTransfer {
    ///a class representing the shared data
    class CharacterBuffer {

        private char character;
        private bool hasCharacter; ///status buffer
        private Mutex mutex;
        private ListBox lstReader; ///listbox to show reader progress
        private ListBox lstWriter; ///listbox to show writer prgress

        ///delegat för att anropa huvudtråden
        private delegate void DisplayDelegate(string inputString, ListBox listBox);

        ///Default constructor
        public CharacterBuffer(ListBox listWriter, ListBox listReader) {
            character = ' '; ///start value
            hasCharacter = false;
            mutex = new Mutex();
            lstReader = listReader;
            lstWriter = listWriter;

        }
        ///When the data is on asyncronous mode
        public char NotSyncRead {
            get {
                ///Read and log value
                lstReader.Invoke(new DisplayDelegate(DisplayString), new object[] { "Reading " + character, lstReader });
                return character;
            }

            set {
                ///write and log value
                lstWriter.Invoke(new DisplayDelegate(DisplayString), new object[] { "Writing " + value, lstWriter });
                character = value;
            }
        }
        ///The syncronous data reader
        ///<returns>Read character</returns>      
        public char SyncRead(out bool success) {
            success = false;
            char charToRead = ' ';

            mutex.WaitOne();   ///lock data while working

            if (!hasCharacter) ///if nothing to read
            {
                ///log waitinh
                lstReader.Invoke(new DisplayDelegate(DisplayString), new Object[] { "No data. Reader waits", lstReader });

            } else {
                hasCharacter = false;    ///change status after reading
                lstReader.Invoke(new DisplayDelegate(DisplayString), new object[] { "Reading " + character, lstReader });

                charToRead = character; ///fro returning correct value after pulse
                success = true;
            }

            mutex.ReleaseMutex();
            return charToRead;
        }
        ///The syncronous data writer
        ///returns Operation /returns
        public bool SyncWrite(char charToWrite) {
            bool success = false;
            mutex.WaitOne(); ///lock data while working

            if (hasCharacter) ///if not read previous data
            {
                ///log waiting
                lstWriter.Invoke(new DisplayDelegate(DisplayString), new object[] { "Data exists. Writer waits", lstWriter });

            } else {
                hasCharacter = true; ///change status after writing
                                     ///log wirting
                lstWriter.Invoke(new DisplayDelegate(DisplayString), new object[] { "Writing " + charToWrite, lstWriter });
                character = charToWrite;
                success = true;
            }
            mutex.ReleaseMutex();
            return success;

        }
        ///method to invoke when writing
        private void DisplayString(string s, ListBox lb) {
            lb.Items.Add(s);
        }

    }
}
