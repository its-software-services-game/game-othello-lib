using Its.Games.Core.Commons;
using Its.Games.Othello.Commons;

namespace Its.Games.Othello.Utils
{
    public static class OthelloRegulatorUtils
    {
        public static bool IsFlipAble(IOthelloBoard  board,  ICoordinate startPosition, IMarker marker, MoveDirectionEnum direction)
        {
            return false;
        }

        public static ICoordinate GetNextPosition(ICoordinate startPosition, MoveDirectionEnum direction)
        {
            int x = startPosition.X;
            int y = startPosition.X;

            if (direction == MoveDirectionEnum.Up)
            {
                x = x-1;
            }
            else if (direction == MoveDirectionEnum.Down)
            {
                x = x+1;
            }
            else if (direction == MoveDirectionEnum.Left)
            {
                y = y-1;
            }
            else if (direction == MoveDirectionEnum.Ritht)
            {
                y = y+1;
            }
            else if (direction == MoveDirectionEnum.UpLeft)
            {
                x = x-1;
                y = y-1;
            }
            else if (direction == MoveDirectionEnum.UpRight)
            {
                x = x-1;
                y = y+1;
            }
            else if (direction == MoveDirectionEnum.DownLeft)
            {
                x = x+1;
                y = y-1;
            }
            else if (direction == MoveDirectionEnum.DownRight)
            {
                x = x+1;
                y = y+1;
            }

            Coordinate c = new Coordinate(x, y);
            return c;
        }        
    }
}