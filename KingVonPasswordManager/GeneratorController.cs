using System;

namespace KingVonPasswordManager
{
    internal class GeneratorController
    {
        private readonly char[] characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*+-/~'?:;.<>|()".ToCharArray(); // char array with all possible characters
        private int passwordLength;  // declaration of password length
        private char[] password; // declaration of password array
        private readonly Random random = new Random();   // new random object
        private string passwordAsString;    // declaration of password as string
        private readonly PasswordGen form;    // declaration of form object
        public GeneratorController(PasswordGen form) // constructor with form object as parameter
        {
            this.form = form;   // sets the form object to the form object from the parameter
        }
        public string GetPasswordAsString() { return passwordAsString; } // getter for password as string

        // generator method
        public void GeneratePassword() 
        {
            passwordLength = form.GetTrackBar().Value; // sets the password length to the value of the trackbar
            password = new char[passwordLength];   // initializes the password array with the password length

            for (int i = 0; i < passwordLength; i++)   // loop to generate the password. Itterates through the password length
            {
                int picker = random.Next(characters.Length);  // picks a random number between 0 and the length of the characters array
                password[i] = characters[picker];   // sets the password at the current index to the character at the index of the random number
            }
            passwordAsString = new string(password);   // sets the password as string to the password array
        }
    }
}
