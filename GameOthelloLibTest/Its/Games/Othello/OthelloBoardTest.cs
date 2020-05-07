using NUnit.Framework;
using Its.Games.Core.Commons;

namespace Its.Games.Othello
{
    public class OthelloBoardTest
    {
        private IMarker playerA;
        private IMarker playerB;

        private bool IsEqual(OthelloBoard src, OthelloBoard dest)
        {
            for (int i=0; i<8; i++)
            {
                for (int j=0; j<8; j++)
                {
                    var c = new Coordinate(i ,j);
                    IMarker srcMarker = src.Get(c);
                    IMarker dstMarker = dest.Get(c);

                    if ((srcMarker != null) && (dstMarker == null))
                    {
                        return false;                  
                    }
                    else if ((srcMarker == null) && (dstMarker != null))
                    {
                        return false;
                    }
                    else if ((srcMarker != null) && (dstMarker != null))
                    {
                        if (!srcMarker.Name.Equals(dstMarker.Name))
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        public OthelloBoardTest()
        {
            playerA = new OthelloMarkerA();
            playerB = new OthelloMarkerB();
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void BoardInitializePlayerATest()
        {
            var board = new OthelloBoard();
            board.Initialize(playerA, playerB);

            var initBoard = new OthelloBoard();
            initBoard.Put(new Coordinate(3,3), playerA);
            initBoard.Put(new Coordinate(4,4), playerA);
            initBoard.Put(new Coordinate(3,4), playerB);
            initBoard.Put(new Coordinate(4,3), playerB);

            bool isEqual = IsEqual(initBoard, board);

            Assert.IsTrue(isEqual, "Initial board state is wrong!!!");
        }

        [Test]
        public void BoardInitializePlayerBTest()
        {
            var board = new OthelloBoard();
            board.Initialize(playerB, playerA);

            var initBoard = new OthelloBoard();
            initBoard.Put(new Coordinate(3,3), playerB);
            initBoard.Put(new Coordinate(4,4), playerB);
            initBoard.Put(new Coordinate(3,4), playerA);
            initBoard.Put(new Coordinate(4,3), playerA);

            bool isEqual = IsEqual(initBoard, board);

            Assert.IsTrue(isEqual, "Initial board state is wrong!!!");
        }

        [Test]
        public void BoardInitializeFalseStateTest()
        {
            var board = new OthelloBoard();
            board.Initialize(playerA, playerB);

            var initBoard = new OthelloBoard();
            initBoard.Put(new Coordinate(3,3), playerB);
            initBoard.Put(new Coordinate(4,4), playerB);
            initBoard.Put(new Coordinate(3,4), playerA);
            initBoard.Put(new Coordinate(4,3), playerA);

            bool isEqual = IsEqual(initBoard, board);

            Assert.IsFalse(isEqual, "Initial board state is wrong!!!");
        }              
    }
}