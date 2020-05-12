using NUnit.Framework;

namespace Its.Games.Othello.Commons
{
    public class OthelloMarkerTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void OthelloMarkerATest()
        {
            var markerA = new OthelloMarkerA();
            Assert.AreEqual("A", markerA.Name, "Expected name to be 'A' !!!");
            Assert.AreEqual(1, markerA.Id, "Expected id to be 1 !!!");
        }

        [Test]
        public void OthelloMarkerAOpponentTest()
        {
            var markerA = new OthelloMarkerA();
            var opponent = markerA.GetOpponentMarker();

            Assert.IsInstanceOf(typeof(OthelloMarkerB), opponent, "Should get opponent type OthelloMarkerB !!!");
        }

        [Test]
        public void OthelloMarkerBTest()
        {
            var markerB = new OthelloMarkerB();
            Assert.AreEqual("B", markerB.Name, "Expected name to be 'B' !!!");
            Assert.AreEqual(2, markerB.Id, "Expected id to be 2 !!!");
        }

        [Test]
        public void OthelloMarkerBOpponentTest()
        {
            var markerB = new OthelloMarkerB();
            var opponent = markerB.GetOpponentMarker();

            Assert.IsInstanceOf(typeof(OthelloMarkerA), opponent, "Should get opponent type OthelloMarkerA !!!");
        }                    
    }
}