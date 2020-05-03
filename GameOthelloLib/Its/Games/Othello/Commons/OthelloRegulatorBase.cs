using Its.Games.Core.Commons;
using Its.Games.Othello.Utils;

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
            ICoordinate c = move.Coordinate;
            IMarker m = move.Mark;

            IMarker currentMark = board.Get(c);
            if (currentMark != null)
            {
                //Not an empty position
                return false;
            }

            bool eatable = false;
            foreach (MoveDirectionEnum direction in MoveDirectionEnum.GetValues(typeof(MoveDirectionEnum)))
            {
                bool isDirectionEatable = OthelloRegulatorUtils.IsFlipAble(board, c, m, direction);
                eatable = eatable || isDirectionEatable;
            }

            return eatable;
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