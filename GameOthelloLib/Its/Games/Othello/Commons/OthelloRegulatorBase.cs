using Its.Games.Core.Commons;
using Its.Games.Othello.Utils;
using System.Collections.Generic;

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
        
        public bool IsPlayable(IPlayer player)
        {
            //TODO : Throw exception here
            return false;
        }

        public bool IsPlayable(IMarker marker)
        {
            bool IsPlayAble = OthelloRegulatorUtils.IsPlayAble(board, marker);
            return IsPlayAble;
        }

        public bool IsValidMove(IMove move)
        {
            bool isValid = OthelloRegulatorUtils.IsValidMove(board, move);
            return isValid;
        }

        public bool IsOver()
        {
            bool isOver = OthelloRegulatorUtils.IsOver(board);
            return isOver;
        }

        public void Move(IMove move)
        {
            OthelloRegulatorUtils.Flip(board, move);
        }

        public List<ICoordinate> GetPlayAbleList(IMarker marker)
        {
            var list = OthelloRegulatorUtils.GetPlayAbleList(board, marker);
            return list;
        }
    }
}