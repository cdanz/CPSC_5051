// AUTHOR: Craig Danz
// FILENAME: main.cs
// DATE: 4/29/2018
// REVISION HISTORY: 1.0 
// REFERENCES (optional): EncryptWord.h EncryptWord.cpp 
// www.tutorialspoint.com/csharp/csharp_quick_guide.htm

using System;
using ProgrammingAssignments5051;

namespace CPSC_5051
{
    /*  Description: -- does the basic main function and offloads most of the 
     * coordination between objects to the driver.
    */
    class Program
    {
        static void Main(string[] args)
        {
            string userWord;
            int userGuess;
            Console.WriteLine("Please provide a word to encrypt: ");
            userWord = Console.ReadLine();
            Console.WriteLine("Your word is: "+userWord);
            Driver driver = new Driver();
            Console.WriteLine("Encrpted it is: " + driver.word(userWord));
            do
            {
                Console.WriteLine("Guess the shift applied to Encrypt: ");
                userGuess = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Your guess is: " + driver.guess(userGuess));
            } while (!driver.guess(userGuess));
            Console.ReadKey();
        }
    }
}

