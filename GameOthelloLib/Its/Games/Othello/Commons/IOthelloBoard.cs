using Its.Games.Core.Commons;

namespace Its.Games.Othello.Commons
{
    public interface IOthelloBoard : IBoard
    {
        void Initialize(IMarker first, IMarker second);
    }
}
