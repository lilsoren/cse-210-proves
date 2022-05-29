using System;
using System.Collections.Generic;


namespace Unit03.Game 
{
    /// <summary>
    /// <para>The person hiding from the Seeker.</para>
    /// <para>
    /// The responsibility of Hider is to keep track of its location and distance from the seeker.
    /// </para>
    /// </summary>
    public class HangMan
    {
        public Word word;

        /// <summary>
        /// Constructs a new instance of Hider. 
        /// </summary>
        public HangMan()
        {
            word = new Word();

        }

        /// <summary>
        /// Gets a hint for the seeker.
        /// </summary>
        /// <returns>A new hint.</returns>
        public string GetHint()
        {
            return word.getProgress();
        }

        /// <summary>
        /// Whether or not the hider has been found.
        /// </summary>
        /// <returns>True if found; false if otherwise.</returns>
        public bool IsComplete()
        {
            return !Word.isContained(word.getProgress(), "_") || word.GetErrorCount() >=5;
        }
       

        public string CreateMan(){
            int errorCount = word.GetErrorCount();


            object[] array = {
                "",
                // word.getProgress(),
                errorCount < 1?@" ___ ":"", 
                errorCount < 2?@"/___\":"", 
                errorCount < 3?@"\   /":"", 
                errorCount < 4?@" \ /":"", 
                errorCount < 5?@"  0":"  X", 
                @" /|\", 
                @" / \",
                @"^^^^^^",
            };
    

            string image = string.Join("\n ", array);

            return image;
        }
    }
}