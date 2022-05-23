using System;


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

        /// <summary>
        /// Constructs a new instance of Seeker.
        /// </summary>
        public Word()
        {
            _randomWord = "apple";
        }

        /// <summary>
        /// Gets the current location.
        /// </summary>
        /// <returns>The current location.</returns>
        public string GetLetter()
        {
            return _randomWord;
        }

        /// <summary>
        /// Moves to the given location.
        /// </summary>
        /// <param name="letter">The given location.</param>
        public void CurrentLetter(string letter)
        {
            this._randomWord = letter;
        }

    }
}