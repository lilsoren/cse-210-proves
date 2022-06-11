using System.Collections.Generic;
using Unit04.Game.Casting;
using Unit04.Game.Services;


namespace Unit04.Game.Directing
{
    /// <summary>
    /// <para>A person who directs the game.</para>
    /// <para>
    /// The responsibility of a Director is to control the sequence of play.
    /// </para>
    /// </summary>
    public class Director
    {
        private KeyboardService keyboardService = null;
        private VideoService videoService = null;
        private int Score;

        /// <summary>
        /// Constructs a new instance of Director using the given KeyboardService and VideoService.
        /// </summary>
        /// <param name="keyboardService">The given KeyboardService.</param>
        /// <param name="videoService">The given VideoService.</param>
        public Director(KeyboardService keyboardService, VideoService videoService)
        {
            this.keyboardService = keyboardService;
            this.videoService = videoService;
        }

        /// <summary>
        /// Starts the game by running the main game loop for the given cast.
        /// </summary>
        /// <param name="cast">The given cast.</param>
        public void StartGame(Cast cast)
        {
            Score = 0;
            System.Console.WriteLine("LILY IS STARTING THE GAME");
            videoService.OpenWindow();
            while (videoService.IsWindowOpen())
            {
                GetInputs(cast);
                DoUpdates(cast);
                DoOutputs(cast);
            }
            videoService.CloseWindow();
        }

        /// <summary>
        /// Gets directional input from the keyboard and applies it to the robot.
        /// </summary>
        /// <param name="cast">The given cast.</param>
        private void GetInputs(Cast cast)
        {
            Actor robot = cast.GetFirstActor("robot");
            Point velocity = keyboardService.GetDirection();
            velocity = new Point(velocity.GetX(), 0);
            robot.SetVelocity(velocity);     
        }

        /// <summary>
        /// Updates the robot's position and resolves any collisions with artifacts.
        /// </summary>
        /// <param name="cast">The given cast.</param>
        private void DoUpdates(Cast cast)
        {
            Actor banner = cast.GetFirstActor("banner");
            Actor robot = cast.GetFirstActor("robot");
            List<Actor> rocksGems = cast.GetActors("gems and rocks");

            updateBanner(banner);

            int maxX = videoService.GetWidth();
            int maxY = videoService.GetHeight();
            robot.MoveNext(maxX, maxY);

            foreach (Actor actor in rocksGems)
            {
                if (robot.GetPosition().Near(actor.GetPosition()))
                {
                    if (actor is Gem){
                        Gem g = (Gem)actor;
                        Score += g.getPointValue();
                        g.SetPosition(new Point(g.GetPosition().GetX(), maxY));
                    }
                    else if (actor is Rock){
                        Rock r = (Rock)actor;
                        Score += r.getPointValue();
                        r.SetPosition(new Point(r.GetPosition().GetX(), maxY));

                    }

                    updateBanner(banner);
                }
                
                // string info = actor.GetPosition().GetX() + "," + actor.GetPosition().GetY();
                actor.MoveNext(maxX, maxY); /// need to check 
                // info += "-->" + actor.GetPosition().GetX() + "," + actor.GetPosition().GetY();

                // System.Console.WriteLine(info);

                
            } 
        }

        /// function that creates banner that shows the score
        private void updateBanner(Actor banner){
            banner.SetText("Score: " + Score);
        }

        /// <summary>
        /// Draws the actors on the screen.
        /// </summary>
        /// <param name="cast">The given cast.</param>
        public void DoOutputs(Cast cast)
        {
            List<Actor> actors = cast.GetAllActors();
            videoService.ClearBuffer();
            videoService.DrawActors(actors);
            videoService.FlushBuffer();
        }

    }
}