using Its.Games.Core.Commons;
using Its.Games.Othello;

namespace Its.Games.Othello.Commons
{
    public interface IOthelloRegulator : IRegulator
    {
        bool IsPlayable(IMarker marker);
    }
}