using System;
using NUnit.Framework;
using Its.Games.Core.Commons;

namespace Its.Games.Othello
{
    public class OthelloRegulatorTest
    {
        private IMarker playerA;
        private IMarker playerB;

        public OthelloRegulatorTest()
        {
            playerA = new OthelloMarkerA();
            playerB = new OthelloMarkerB();
        }

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

        private OthelloBoard InitBoard(IMarker p1, IMarker p2)
        {
            var initBoard = new OthelloBoard();
            initBoard.Put(new Coordinate(3,3), p1);
            initBoard.Put(new Coordinate(4,4), p1);
            initBoard.Put(new Coordinate(3,4), p2);
            initBoard.Put(new Coordinate(4,3), p2);

            return initBoard;
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void OthelloRegulatorInitialAFirstTest()
        {
            var brd = new OthelloBoard();
            var regulator = new OthelloRegulator(brd, playerA, playerB);
            var board = (OthelloBoard) regulator.GetBoard();

            var initBoard = InitBoard(playerA, playerB);
            bool isEqual = IsEqual(initBoard, board);

            Assert.IsTrue(isEqual, "Initial board state is wrong!!!");
        }

        [Test]
        public void OthelloRegulatorInitialBFirstTest()
        {
            var brd = new OthelloBoard();
            var regulator = new OthelloRegulator(brd, playerB, playerA);
            var board = (OthelloBoard) regulator.GetBoard();

            var initBoard = InitBoard(playerB, playerA);
            bool isEqual = IsEqual(initBoard, board);

            Assert.IsTrue(isEqual, "Initial board state is wrong!!!");
        }

        [Test]
        public void InitNotSupportExceptionTest()
        {
            var brd = new OthelloBoard();
            var regulator = new OthelloRegulator(brd, playerA, playerB);        
            var ex = Assert.Throws<NotSupportedException>(() => regulator.Init());        
        } 

        [Test]
        public void IsPlayableNotSupportExceptionTest()
        {
            var brd = new OthelloBoard();
            var regulator = new OthelloRegulator(brd, playerA, playerB);        
            var ex = Assert.Throws<NotSupportedException>(() => regulator.IsPlayable((IPlayer) null));        
        }                                    
    }
}