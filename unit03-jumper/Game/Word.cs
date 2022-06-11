using System;
using System.Collections.Generic;
using System.IO;


namespace Unit03.Game
{
    /// <summary>
    /// <para>The person looking for the Hider.</para>
    /// <para>
    /// The responsibility of a Seeker is to keep track of its location.
    /// </para>
    /// </summary>
    public class Word
    {
        private string _randomWord = "";
        private string _guessedCharacters = "";
        /// <summary>
        /// Constructs a new instance of Seeker.
        /// </summary>
        public Word()
        {
            _randomWord = pickARandomNewWord();
        }

        private string pickARandomNewWord(){
            /// Find list of words
            string path = "/Users/lilysorensen/Documents/CSE 210/cse-210-proves/unit03-jumper/Game/RandomWords.txt" ;
            /// read the list of words
            List <string> wordsList = new List<string>();
            foreach(string line in System.IO.File.ReadLines(path)){
                wordsList.Add(line);
            }
            // wordsList.AddRange(System.IO.File.ReadAllLines(path));
            wordsList.AddRange(@"subjective
monsters
asylum
lightbox
robbie
stake
cocktail
outlets
swaziland
varieties
arbor
mediawiki
configurations
poison".Split(" \n\r".ToCharArray()));
            /// pick a randome one
            Console.WriteLine(System.IO.File.Exists(path));
            int randomNumber = new Random(DateTime.Now.Millisecond).Next(0, wordsList.Count - 1);

            return wordsList[randomNumber];
        }

        /// <summary>
        /// Gets the current location.
        /// </summary>
        /// <returns>The current location.</returns>
        public string Getword()
        {
            return _randomWord;
        }

        /// <summary>
        /// Moves to the given location.
        /// </summary>
        /// <param name="letter">The given location.</param>
        public void CurrentLetter(string letter){
            _guessedCharacters += letter;
        }
        public static bool isContained(string word, string letter){
            return word.ToLower().IndexOf(letter.ToLower()) > -1;
        }
        public enum eLetterResult{
            noGuess, 
            correct, 
            incorrect
        }
        public eLetterResult isLastLetterCorrect(){
            if (_guessedCharacters.Length == 0)
            return eLetterResult.noGuess;

            string lastLetter = _guessedCharacters.Substring(_guessedCharacters.Length - 1);
            
            if (isContained(_randomWord, lastLetter)){
                return eLetterResult.correct;
            }
            else{
                return eLetterResult.incorrect;
            }
        }
        public string getProgress(){
            string result = "";
            foreach(char c in _randomWord.ToCharArray()){
                if (isContained(_guessedCharacters, c + "")){
                    result += c + " ";
                }
                else{
                    result += "_ ";
                }
            }


            return result;
        }
        public int GetErrorCount(){
            int errorCount = 0;
            foreach(char c in _guessedCharacters.ToCharArray()){
                if (!isContained(_randomWord, c + "")){
                    errorCount += 1;
                }
            }


            return errorCount;
        }
    }
}