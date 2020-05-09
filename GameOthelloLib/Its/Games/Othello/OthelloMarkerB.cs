using Its.Games.Othello.Commons;
using Its.Games.Core.Commons;

namespace Its.Games.Othello
{
    public class OthelloMarkerB : OthelloMarker
    {
        protected override string GetName()
        {
            return "B";
        }

        protected override int GetId()
        {
            return 2;
        }

        public override IMarker GetOpponentMarker()
        {
            return new OthelloMarkerA();
        }        
    }
}