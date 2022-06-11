namespace Unit04.Game.Casting
{

    /// class decloration. Inherit from the actor class
    public class Gem : Artifact{

        /// constructs a new instance of Gem 
        public Gem():base(){
        }

        /// return a point value 
        public int getPointValue(){
            return 1;
        }

        /// changing all gems to *
        public override string GetText(){
            return "*";
        }
    }
}
