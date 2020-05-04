using System;
using Its.Games.Core.Commons;

namespace Its.Games.Othello
{
    public class InvalidMoveException : Exception
    {
        private static string message = "Invalid move (X,Y)=(%1, %2)";
        private IMove move;

        public InvalidMoveException(IMove mv) : base()
        {
            move = mv;
        }

        public override string Message
        {
            get 
            { 
                return String.Format(message, move.Coordinate.X, move.Coordinate.Y); 
            }
        }        
    }
}