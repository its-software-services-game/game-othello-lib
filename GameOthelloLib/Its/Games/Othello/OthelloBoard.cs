using Its.Games.Core.Commons;
using Its.Games.BoardGame2D.Core.BoardGame2D;
using Its.Games.Othello.Commons;

namespace Its.Games.Othello
{
    public class OthelloBoard : BoardBase, IOthelloBoard
    {
        private static readonly int maxRow = 8;
        private static readonly int maxCol = 8;

        protected override IMarker[,] CreateBoard()
        {
            IMarker[,] board = new IMarker[maxRow, maxCol];
            return board;
        }

        public void Initialize(IMarker first, IMarker second)
        {
            Coordinate c1 = new Coordinate(3, 3);
            Put(c1, first);
            Coordinate c2 = new Coordinate(4, 4);
            Put(c2, first);
            
            Coordinate c3 = new Coordinate(3, 4);
            Put(c3, second);
            Coordinate c4 = new Coordinate(4, 3);
            Put(c4, second);
        }

        protected override int GetMaxRow()
        {
            return maxRow;
        }

        protected override int GetMaxCol()
        {
            return maxCol;
        }
    }
}