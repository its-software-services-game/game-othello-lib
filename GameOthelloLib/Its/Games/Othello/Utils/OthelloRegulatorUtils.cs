using System.Collections.Generic;
using Its.Games.Core.Commons;
using Its.Games.Othello.Commons;
using Its.Games.Othello.Exceptions;

namespace Its.Games.Othello.Utils
{
    public static class OthelloRegulatorUtils
    {
        private static bool IsFlipAble(IOthelloBoard  board,  ICoordinate startPosition, IMarker marker, MoveDirectionEnum direction)
        {
            ICoordinate pos = startPosition;
            int opponentCnt = 0;
            
            pos = GetNextPosition(pos, direction);
            bool isValidPosition = IsValidCoordinate(pos);
            
            while (isValidPosition)
            {
                IMarker mk = board.Get(pos);
                if (mk == null)
                {
                    return false;
                }

                if (!mk.Name.Equals(marker.Name))
                {
                    opponentCnt++;
                }
                else if (opponentCnt > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

                pos = GetNextPosition(pos, direction);
                isValidPosition = IsValidCoordinate(pos);                
            }

            return false;
        }

        private static bool Flip(IOthelloBoard  board,  ICoordinate startPosition, IMarker marker, MoveDirectionEnum direction)
        {
            bool flipAble = IsFlipAble(board, startPosition, marker, direction);

            if (!flipAble)
            {
                return false;
            }

            ICoordinate pos = startPosition;
            pos = GetNextPosition(pos, direction);
            bool isValidPosition = IsValidCoordinate(pos);

            while (isValidPosition)
            {
                IMarker mk = board.Get(pos);                
                if (!mk.Name.Equals(marker.Name))
                {
                    IMarker opponentMark = mk.GetOpponentMarker();
                    board.Put(pos, opponentMark);
                }

                pos = GetNextPosition(pos, direction);
                isValidPosition = IsValidCoordinate(pos);                
            }

            return true;
        }

        private static bool IsValidCoordinate(ICoordinate pos)
        {
            int x = pos.X;
            int y = pos.Y;

            if ((x < 0) || (y < 0))
            {
                return false;
            }

            if ((x >= 8) || (y >= 8))
            {
                return false;
            }

            return true;
        }

        private static ICoordinate GetNextPosition(ICoordinate startPosition, MoveDirectionEnum direction)
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

        public static bool IsOver(IOthelloBoard  board)
        {
            IMarker a = new OthelloMarkerA();
            IMarker b = new OthelloMarkerB();

            bool isPlayableA = IsPlayAble(board,  a);
            bool isPlayableB = IsPlayAble(board,  b);

            bool isPlayable = isPlayableA || isPlayableB; 

            return !isPlayable;
        }

        public static bool IsPlayAble(IOthelloBoard  board,  IMarker mark)
        {
            for (int x = 0; x < board.RowCount; x++)
            {
                for (int y = 0; y < board.ColumnCount; y++)
                {
                    IMove move = new OthelloMove(x, y, mark);
                    bool foundValidMove = IsValidMove(board, move);

                    if (foundValidMove)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static bool IsValidMove(IOthelloBoard  board,  IMove move)
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
                bool isDirectionEatable = IsFlipAble(board, c, m, direction);
                eatable = eatable || isDirectionEatable;
            }

            return eatable;
        }

        public static void Flip(IOthelloBoard  board,  IMove move)
        {
            ICoordinate c = move.Coordinate;
            IMarker m = move.Mark;

            bool flipAble = false;
            foreach (MoveDirectionEnum direction in MoveDirectionEnum.GetValues(typeof(MoveDirectionEnum)))
            {
                bool isFlipAble = Flip(board,  c, m, direction);
                flipAble = flipAble || isFlipAble;
            }

            if (!flipAble)
            {
                throw new InvalidMoveException(move);
            }
        } 

        public static List<ICoordinate> GetPlayAbleList(IOthelloBoard  board,  IMarker mark)
        {
            var list = new List<ICoordinate>();

            for (int x = 0; x < board.RowCount; x++)
            {
                for (int y = 0; y < board.ColumnCount; y++)
                {
                    IMove move = new OthelloMove(x, y, mark);
                    bool foundValidMove = IsValidMove(board, move);

                    if (foundValidMove)
                    {
                        ICoordinate c = new Coordinate(x, y);
                        list.Add(c);
                    }
                }
            }

            return list;
        }                 
    }
}