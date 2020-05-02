using Its.Games.Core.Commons;
using Its.Games.Othello.Commons;

namespace Its.Games.Othello
{
    public class OthelloRegulator : OthelloRegulatorBase
    {
        public OthelloRegulator(IOthelloBoard brd, IMarker first, IMarker second)
        {
            SetBoard(brd);
            Init(first, second);
        }
    }
}