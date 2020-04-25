using Its.Games.Core.Commons;

namespace Its.Games.Othello
{
    public interface IOthelloBoard
    {
        void Init(IMarker playerMarker1, IMarker playerMarker2);
    }
}