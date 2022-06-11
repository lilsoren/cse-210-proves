namespace Unit04.Game.Casting
{

    /// class decloration. Inherit from the actor class
    public class Rock : Artifact{

        /// constructs a new instance of Rock 
        public Rock():base(){
        }

        /// return a point value 
        public int getPointValue(){
            return -1;
        }

        /// changing all rocks to o
        public override string GetText(){
            return "o";
        }
    }
}
