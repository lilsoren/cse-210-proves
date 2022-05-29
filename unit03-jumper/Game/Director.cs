namespace Unit03.Game
{
    /// <summary>
    /// <para>A person who directs the game.</para>
    /// <para>
    /// The responsibility of a Director is to control the sequence of play.
    /// </para>
    /// </summary>
    public class Director
    {
        private HangMan hangman = new HangMan();
        private bool isPlaying = true;
        private TerminalService terminalService = new TerminalService();

        /// <summary>
        /// Constructs a new instance of Director.
        /// </summary>
        public Director()
        {
        }

        /// <summary>
        /// Starts the game by running the main game loop.
        /// </summary>
        public void StartGame()
        {
            while (isPlaying)
            {
                GetInputs();
                DoOutputs();
            }
        }

        /// <summary>
        /// Moves the seeker to a new location.
        /// </summary>
        private void GetInputs()
        {
            /// terminalService.WriteText(hider.location.ToString());
            string letter = terminalService.ReadText("\nEnter a letter:  ");
            hangman.word.CurrentLetter(letter);
        }
       

        /// <summary>
        /// Provides a hint for the seeker to use.
        /// </summary>
        private void DoOutputs()
        {
            string hint = hangman.GetHint();
            terminalService.WriteText(hint);
            terminalService.WriteText(hangman.CreateMan());
            if (hangman.IsComplete())
            {
                isPlaying = false;
            }
            
        }
    }
}