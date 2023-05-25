using System;
using System.IO;

namespace LabCleanCode
{
    class Hangman
    {
        public static void PlayHangman()
        {

            Console.WriteLine("Welcome to Hangman!!!!!!!!!!");

            StreamReader file = new StreamReader("usa.txt");
            Random randGen = new Random();
            var idx = randGen.Next(0, 61333);
            //var idx = randGen.Next(0, 10);
            string mysteryWord = new string("");
            for (int i = 0; i < idx; i++) {
                mysteryWord = file.ReadLine();
            }
            file.Close();

            char[] guess = new char[mysteryWord.Length];
            Console.Write("Please enter your guess: ");

            for (int p = 0; p < mysteryWord.Length; p++)
                guess[p] = '*';


            while (true)
            {
                char playerGuess = 'A';
                try
                {
                    playerGuess = char.Parse(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    playerGuess = ' ';
                }
                for (int j = 0; j < mysteryWord.Length; j++)
                {
                    if (playerGuess == mysteryWord[j])
                        guess[j] = playerGuess;
                }
                string a = new string(guess);
                if (!gano(a, mysteryWord))
                {
                    //Sigue jugando
                }
                else
                {
                    break;
                }
                Console.WriteLine(guess);
            }
            Console.ReadLine();
        }


        /*public static bool perdio(string word1, string word2, int counter)
        {
            if (word1.Equals(word2))
            {
                Console.Write("Congratulations the word was: " + word2);
                return true;
            }
            if (counter > 10)
            {
                Console.Write("You lose, the word was: " + word2);
                counter++;
            }
            return false;
        }*/

        ////////////////////////////////////////////////////////////////////////////////
        // Validación del juego
        ////////////////////////////////////////////////////////////////////////////////
        public static bool gano(string word1, string word2)
        {
            if (word1.Equals(word2))
            {
                Console.Write("Congratulations the word was: " + word2);
                return true;
            }
            return false;
        }

        public void readdata()
        {
            FileStream fs = new FileStream("usa.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            sr.BaseStream.Seek(0, SeekOrigin.Begin);
            string str = sr.ReadLine();
            while (str != null)
            {
                Console.WriteLine("{0}", str);
                str = sr.ReadLine();
            }
            //Close the Writer and File
            sr.Close();
            fs.Close();
        }

    }
}
