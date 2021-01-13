using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Hangman_part2
{
    class Program
    {
        static string[] dictionary;
        static Random rnd = new Random();
        static string theWord;
        static string maskedWord;
        static string guessedLetters;
        static int lives;


        static void Main(string[] args)
        {
            dictionary = File.ReadAllLines("Dictionary.txt");
            bool canContinue = true;
            while (canContinue)
            {
                //Console.WriteLine("How many lives do you want?");
                //string userlives = Console.ReadLine();
                theWord = dictionary[rnd.Next(dictionary.Length)]; //next = up to
                Console.WriteLine(theWord); //delete before finishing
                lives = 6;
                guessedLetters = "";
                maskedWord = "";
                for (int letterCount = 0; letterCount < theWord.Length; letterCount++)
                {
                    maskedWord += "* ";
                }

                while (maskedWord.Contains("*") && lives > 0) 
                {
                    DrawScreen();
                    Console.SetCursorPosition(5, 15);
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine("Please guess a letter");
                    string userGuess = Console.ReadLine();
                    if (userGuess.Length != 1)
                    {
                        Console.WriteLine("Please enter a single character");
                    }

                    else
                    {
                        if (guessedLetters.Contains(userGuess))
                        {
                            Console.WriteLine(userGuess + "has already been guessed");
                        }

                        if (theWord.Contains("a"))
                        {
                            Console.WriteLine("has an A");
                        }

                        else //processing the guess
                        {
                            guessedLetters += userGuess; //this works
                            if (theWord.Contains(userGuess)) //they get a letter 
                            {
                                Console.WriteLine("entered correct");
                                int startPosition = 0;
                                int letterPosition = 0;
                                while (letterPosition != -1)
                                {
                                    letterPosition = theWord.IndexOf(userGuess, startPosition);
                                    //index of == what the number of it is
                                    if (letterPosition != -1)
                                    {
                                        startPosition = letterPosition + 1;
                                        maskedWord = maskedWord.Substring(0, letterPosition * 2) + userGuess + maskedWord.Substring(letterPosition * 2 + 1);
                                        //1st substring = finding where the guessed letter in theWord is
                                        //+ userGuess is adding that to the search
                                        //2ns substring = replacing the * with the letter
                                        // have to start with -1 because the masked word is not being replaced with guess letter 
                                        // has to be + 1 trial and error and it works!!!
                                        // *2 because I have a space in between the letters of the word
                                    }
                                }

                            }

                            else
                            {
                                Console.WriteLine("Sorry " + userGuess + " is not in the word");
                                Console.WriteLine("You have " + --lives + " lives");

                            }
                        }
                    }
                }

                DrawScreen();
                if (lives == 0)
                {
                    Console.WriteLine("You have lost, the word was " + theWord);
                    Console.ReadLine();
                }

                else
                {
                    Console.WriteLine("Well done you have won!");
                    Console.ReadLine();
                }

                Console.WriteLine("Would you like to play again?");
                string playAgain = Console.ReadLine();
                if (playAgain.ToLower() == "no")
                {
                    canContinue = false;
                }
            }
        }

        static void DrawScreen() // function to test screen drawing
            // ideally want to draw out the whole hang man person like my python one
        {
            //draw the frame
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("############################################################");
            Console.WriteLine("#                                       #                  #");
            Console.WriteLine("#                                       #                  #");
            Console.WriteLine("#                                       #                  #");
            Console.WriteLine("############################################################");
            Console.WriteLine("#                                       #                  #");
            Console.WriteLine("#                                       #                  #");
            Console.WriteLine("#                                       #                  #");
            Console.WriteLine("#                                       #                  #");
            Console.WriteLine("#                                       #                  #");
            Console.WriteLine("#                                       #                  #");
            Console.WriteLine("#                                       #                  #");
            Console.WriteLine("#                                       #                  #");
            Console.WriteLine("############################################################");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(12, 2);
            Console.WriteLine("H A N G M A N");

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.SetCursorPosition(43, 6);
            Console.WriteLine("+-----+");
            Console.SetCursorPosition(43, 7);
            Console.WriteLine("|/    |");
            Console.SetCursorPosition(43, 8);
            Console.WriteLine("|");
            Console.SetCursorPosition(43, 9);
            Console.WriteLine("|");
            Console.SetCursorPosition(43, 10);
            Console.WriteLine("|\\");
            Console.SetCursorPosition(43, 11);
            Console.WriteLine("+------------");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(4, 9);
            Console.WriteLine("Lives Left : ");
            Console.SetCursorPosition(4, 11);
            Console.WriteLine("Letters Guessed : ");
            Console.SetCursorPosition(43, 2);
            Console.WriteLine("Words : ");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(3, 6);
            Console.WriteLine(maskedWord);
            Console.SetCursorPosition(17, 9);
            Console.WriteLine(lives);
            Console.SetCursorPosition(22, 11);
            Console.WriteLine(guessedLetters);
            Console.SetCursorPosition(51, 2);
            Console.WriteLine(dictionary.Length);

            
            Console.ForegroundColor = ConsoleColor.Gray;
            if (lives < 6)
            {
                Console.SetCursorPosition(49, 8);
                Console.WriteLine("o");
            }

            if (lives < 5)
            {
                Console.SetCursorPosition(48, 9);
                Console.WriteLine("/");
            }

            if (lives < 4)
            {
                Console.SetCursorPosition(49, 9);
                Console.WriteLine("|");
            }

            if (lives < 3)
            {
                Console.SetCursorPosition(50, 9);
                Console.WriteLine("\\");
            }

            if (lives < 2)
            {
                Console.SetCursorPosition(48,10);
                Console.WriteLine("/");
            }

            if (lives < 1)
            {
                Console.SetCursorPosition(48, 10);
                Console.WriteLine("\\");
            }
        }
    }
}


