using Its.Games.Core.Commons;

namespace Its.Games.Othello
{
    public class OthlloBoard : IBoard, IOthelloBoard
    {
        private static readonly int maxRow = 8;
        private static readonly int maxCol = 8;
        private IMarker[,] board = new IMarker[maxRow, maxCol];

        private void InitialBoard(IMarker playerMarker1, IMarker playerMarker2)
        {
            board[3, 3] = playerMarker1;
            board[4, 4] = playerMarker1;

            board[3, 4] = playerMarker2;
            board[4, 3] = playerMarker2;            
        }

        private void ClearBoard()
        {
            for (int r=0; r<maxRow; r++)
            {
                for (int c=0; c<maxRow; c++)
                {
                    board[r, c] = null;
                }
            }
        }

        public void Init(IMarker playerMarker1, IMarker playerMarker2)
        {
            ClearBoard();
            InitialBoard(playerMarker1, playerMarker2);
        }

        public void Init()
        {
            ClearBoard();
        }

        public void Move(IMove move)
        {
            ICoordinate coordinate = move.Coordinate;
            IMarker marker = move.Mark;

            int row = coordinate.X;
            int col = coordinate.Y;

            board[row, col] = marker;    
        }
    }
}