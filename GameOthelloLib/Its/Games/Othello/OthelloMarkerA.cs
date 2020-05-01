using Its.Games.Othello.Commons;

namespace Its.Games.Othello
{
    public class OthelloMarkerA : OthelloMarker
    {
        protected override string GetName()
        {
            return "A";
        }

        protected override int GetId()
        {
            return 2;
        }
    }
}