using Its.Games.Core.Commons;
using System.Collections.Generic;

namespace Its.Games.Othello.Commons
{
    public interface IOthelloRegulator : IRegulator
    {
        bool IsPlayable(IMarker marker);
        List<ICoordinate> GetPlayAbleList(IMarker marker);
        IOthelloBoard GetBoard();
    }
}