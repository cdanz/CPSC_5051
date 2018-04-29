// AUTHOR: Craig Danz
// FILENAME: EncryptWord.cs
// DATE: 4/15/2018
// REVISION HISTORY: 1.0 
// REFERENCES (optional): EncryptWord.h EncryptWord.cpp 
// www.tutorialspoint.com/csharp/csharp_quick_guide.htm


using System;

namespace ProgrammingAssignments5051 {
    /*  Description: -- this class creates an object that can perform a caesar
     shift cipher on text and allows the client to guess the shift. The
     function that performs the caesar cipher returns encrypted text. There is
     a function that takes in a guess, updates stats based on the guess and
     returns a boolean value indicating if the client is correct or not.
    
     Assumptions:
     An EncryptedWord object is considered "on" if its encrypt function is in
     use, otherwise it is off.
     Resetting an EncryptedWord object re-initializes the stats back to zero.
    */
   class EncryptWord {
       // member variables
        const int MIN_CHARS = 4; //arbitrary minimum number of characters allowed
        int SHIFT = 3; //the number used to shift by in the caesar shift.
        int LETTERS = 26; //Number of letters in the alphabet
        int UP_LOW = 65; //Lowerbound of ASCII Uppercase letter characters
        int UP_HIGH = 90; //Upperbound of ASCII Uppercase letter characters
        int LOW_LOW = 97; //Lowerbound of ASCII Lowercase letter characters
        int LOW_HIGH = 122; //Upperbound of ASCII Lowercase letter characters
        int guesses; //accumulator of guesses made.
        int highGuess; //tracks highest guess made.
        int lowGuess; //tracks lowest guess made.
        double averageGuess; //tracks calculated average of guesses
        bool on; //whether the encryption has been used yet or not.
        string text; //string of text to be worked with and encrypted.
       /* TODO No constructors? */

       // Acts as a pseudo contructor, setting each objects member variables
       // to their proper starting state. 
       // preconditions: None
       // postconditions: All tracking variables are set at zero. On is true.
       public void Initiate() {
            guesses = 0;
            highGuess = 0;
            lowGuess = 0;
            averageGuess = 0;
            on = false;
        }

       // Give the object a word to encrypt, the method returns it in its 
       // encrypted form. Provided string must have the minimum number of 
       // charaters set in the MIN_CHARS constant.
       // preconditions: Must be off.
       // postconditions: All tracking variables are set at zero. On is true.
        public string encrypt(string in) {
            if (in.length() < MIN_CHARS)
                return "ERROR";
            on = true;
            string out = "";
            //go through text character by character
            for (int i = 0; i < in.length(); i++) {
                //check to see if character is uppercase and return a shift that is
                //also uppercase if it is.
                if (in[i] >= UP_LOW && in[i] <= UP_HIGH)
                    out += char((int(in[i])+SHIFT-UP_LOW)%LETTERS +UP_LOW);
                //if not upper, check if lower and shift to another lowercase value.
                else if (in[i] >= LOW_LOW && in[i] <= LOW_HIGH)
                    out += char((int(in[i])+SHIFT-LOW_LOW)%LETTERS +LOW_LOW);
                //to stop any phrases, detection of a space will throw an error.
                else
                    return "ERROR";
            }

            return out;
        }

       // Decrypt a word as a means of getting more information on what the 
       // encryption method may be. Provided string must have the minimum 
       // number of charaters set in the MIN_CHARS constant.
       // preconditions: Must be on.
       // postconditions: Still on. 
        public string decrypt(string in) {
            if (!on)
                return "ERROR";
            if (in.length() < MIN_CHARS)
                return "ERROR";
            string out = "";
            //go through text character by character
            for (int i = 0; i < in.length(); i++) {
                //check to see if character is uppercase and return a shift that is
                //also uppercase if it is.
                if (in[i] >= UP_LOW && in[i] <= UP_HIGH)
                    out += char((int(in[i]) + (LETTERS - SHIFT) - UP_LOW) % LETTERS + UP_LOW);
                    //if not upper, check if lower and shift to another lowercase value.
                else if (in[i] >= LOW_LOW && in[i] <= LOW_HIGH)
                    out += char((int(in[i]) + (LETTERS - SHIFT) - LOW_LOW) % LETTERS + LOW_LOW);
                    //Any non-letters will throw an error.
                else
                    return "ERROR";
            }

            return out;
        }

        //Process a guess at what the shift is. takes in a number "guess", adjusts
        //the statics of the guesses accordingly by incrementing the number of
        //guesses, adjusting the high guess if it is a new high, adjusting low if
        //new low and recalculating the average guess. Finally a boolean is returned
        //true if and only if the guess is equal to the shift.
        // preconditions: Must be on.
        // postconditions: Still on. 
        public bool makeGuess(int g) {
            //check to see if encryption has been used yet.
            if (!on)
                return false;
            //first guess is both the high and low guess
            if (guesses == 0) {
                highGuess = g;
                lowGuess = g;
            }
            //check for new high
            if (g > highGuess)
                highGuess = g;
            //check for new low
            if (g < lowGuess)
                lowGuess = g;
            //increment
            guesses++;
            //recalculate average
            averageGuess = ((averageGuess * (guesses - 1)) + g ) / guesses;

            return g == SHIFT;
        }

        // Getter for high guess.
        // preconditions: Must be on.
        // postconditions: Still on. 
        public int getHighGuess() {
            //check to see if encryption has been used yet.
            if (!on)
                return -1;
            return highGuess;
        }

        // Getter for low guess.
        // preconditions: Must be on.
        // postconditions: Still on. 
        public int getLowGuess() {
            //check to see if encryption has been used yet.
            if (!on)
                return -1;
            return lowGuess;
        }

        // Getter for average of guesses.
        // preconditions: Must be on.
        // postconditions: Still on. 
        public double getAverageGuess() {
            //check to see if encryption has been used yet.
            if (!on)
                return -1;
            return averageGuess;
        }

        // Getter for number of guesses.
        // preconditions: Must be on.
        // postconditions: Still on. 
        int getGuesses() {
            //check to see if encryption has been used yet.
            if (!on)
                return -1;
            return guesses;
        }

        // Find out if the object is on.
        // preconditions: Either on or off.
        // postconditions: No change. 
        public bool getOn() const {
            return on;
        }

        // Find the minimum allowed number of characters in a gstrin meant 
        // for encryption.
        // preconditions: On or off.
        // postconditions: No change.
        public int getMin() const {
            return MIN_CHARS;
        }

        // Reset the object for another word.
        // preconditions: On or off.
        // postconditions: No change.
        public void reset() {
            //check to see if encryption has been used yet.
            if (!on)
                return;
            //reset all guess stats back to zero.
            guesses = 0;
            highGuess = 0;
            lowGuess = 0;
            averageGuess = 0;
            on = false;
        }
   }

    /*  Description: -- this class acts as a driver for the EncryptWord class.
    */
   class ExecuteEncryptWord {

      static void Main(string[] args) {
        string userWord;
        EncryptWord e = new EncryptWord();
        e.Initiate();
        userWord = Console.ReadLine();
        Console.WriteLine(e.encrypt(userWord));
        Console.ReadKey();
      }
   }
}