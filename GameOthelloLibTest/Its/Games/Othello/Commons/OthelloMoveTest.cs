using NUnit.Framework;
using Its.Games.Core.Commons;

namespace Its.Games.Othello.Commons
{
    public class OthelloMoveTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void OthelloMoveInitializeTest()
        {
            int x = 4;
            int y = 5;

            var move = new OthelloMove(x, y, new OthelloMarkerA());
            ICoordinate c = move.Coordinate;
            IMarker m = move.Mark;

            Assert.AreEqual(x, c.X, "X value is different what has been set !!!");
            Assert.AreEqual(y, c.Y, "Y value is different what has been set !!!");
            Assert.AreEqual("A", m.Name, "Marker value is different what has been set !!!");
        }
    }
}