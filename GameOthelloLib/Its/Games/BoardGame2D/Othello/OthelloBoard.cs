using Its.Games.Core.Commons;
using Its.Games.BoardGame2D.Commons;

namespace Its.Games.BoardGame2D.Othello
{
    public class OthlloBoard : BoardBase
    {
        private static readonly int maxRow = 8;
        private static readonly int maxCol = 8;

        protected override IMarker[,] CreateBoard()
        {
            IMarker[,] board = new IMarker[maxRow, maxCol];
            return board;
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