using Its.Games.Core.Commons;

namespace Its.Games.Othello.Commons
{
    public abstract class OthelloRegulatorBase : IOthelloRegulator
    {
        private IOthelloBoard board = null;

        protected void SetBoard(IOthelloBoard brd)
        {
            board = brd;
        }

        protected void Init(IMarker first, IMarker second)
        {
            board.Initialize(first, second);
        }

        public void Init()
        {
            //TODO : Throw exception here
        }

        public bool IsPlayable(IMarker marker)
        {
            return true;
        }

        public bool IsValidMove(IMove move)
        {
            return true;
        }

        public bool IsPlayable(IPlayer player)
        {
            return false;
        }

        public bool IsOver()
        {
            return true;
        }

        public void Move(IMove move)
        {
        } 
    }
}