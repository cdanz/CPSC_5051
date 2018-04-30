// AUTHOR: Craig Danz
// FILENAME: driver.cs
// DATE: 4/29/2018
// REVISION HISTORY: 1.0 
// REFERENCES (optional): EncryptWord.h EncryptWord.cpp 
// www.tutorialspoint.com/csharp/csharp_quick_guide.htm

using System;
using ProgrammingAssignments5051;

namespace CPSC_5051
{
    /*  Description: -- takes inputs from main and corrdinates appropriate use
     * of objects.
    */
    class Driver
    {
        /*  Description: -- takes in user defined string to use for encryption.
        */
        public string word(string x)
        {
            EncryptWord e = new EncryptWord();
            e.Initiate();
            return e.encrypt(x);
        }
        /*  Description: -- takes in user defined int guess of the shift 
         * applied by the cipher.
        */
        public bool guess(int y)
        {
            bool guessTruth = false;
            EncryptWord e = new EncryptWord();
            e.Initiate();
            guessTruth = e.makeGuess(y);
            return guessTruth;
        }
    }
}