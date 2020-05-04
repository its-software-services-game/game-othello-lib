using Its.Games.Core.Commons;

namespace Its.Games.Othello.Commons
{
    public class OthelloMove : IMove
    {
        public IMarker Mark { get; set; }
        public ICoordinate Coordinate { get; set; }

        public OthelloMove(int x, int y, IMarker mark)
        {
            Mark = mark;
            Coordinate = new Coordinate(x, y);
        }
    }
}