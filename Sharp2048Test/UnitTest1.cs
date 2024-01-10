using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sharp2048;

namespace Sharp2048Test
{

    [TestClass]
    public class UnitTest1
    {
        public bool IsBoardEqual(Sharp2048.Board board1, Sharp2048.Board board2)
        {
            int i;
            int j;
            if(board1==null ||
                board2 == null)
            {
                return false;
            }
            if (board1.RowSize != board2.RowSize
                ||board1.ColSize != board2.ColSize)
            {
                return false;
            }
            for (i = 0; i < board1.RowSize; i++)
            {
                for (j = 0; j < board1.ColSize; j++)
                {
                    if(board1.Matrix [i,j] != board2.Matrix[i, j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        [TestMethod]
        public void CanMove()
        {
            Sharp2048.Board board = new Board();
            board.Matrix[0, 1] = 2;
           // board.Move(Board.Direction.Right);

            Assert.AreEqual(board.CanMove(), true);
            int i;
            int j;
            int count = 0;
            for (i = 0; i < board.RowSize; i++)
            {
                for (j = 0; j < board.ColSize; j++)
                {
                    count++;
                    board.Matrix[i, j] = count;
                }
            }
            Assert.AreEqual(board.CanMove(), false);
        }
        [TestMethod]
        public void Move()
        {
            Sharp2048.Board board = new Board();
            board.Matrix[0, 1] = 2;
            board.Move(Board.Direction.Right);

            Assert.AreEqual(board.Matrix[0, 1], 0);
            Assert.AreEqual(board.Matrix[0, 3], 2);

            board = new Board();
            board.Matrix[0, 0] = 2;
            board.Matrix[1, 1] = 2;
            board.Matrix[2, 2] = 2;
            board.Matrix[3, 3] = 2;
            board.Move(Board.Direction.Left);
            Assert.AreEqual(board.Matrix[0, 0], 2);
            Assert.AreEqual(board.Matrix[1, 1], 0);
            Assert.AreEqual(board.Matrix[2, 2], 0);
            Assert.AreEqual(board.Matrix[3, 3], 0);
          //  Assert.AreEqual(board.Matrix[3, 3], 0);

            

            Assert.AreEqual(board.Matrix[0, 0], 2);
            Assert.AreEqual(board.Matrix[1, 0], 2);
            Assert.AreEqual(board.Matrix[2, 0], 2);
            Assert.AreEqual(board.Matrix[3, 0], 2);

            Board newBoard = board.Clone();
            board.Move(Board.Direction.Up);

            Assert.AreEqual(board.Matrix[0, 0], 4);
            Assert.AreEqual(board.Matrix[1, 0], 4);
            Assert.AreEqual(board.Matrix[2, 0], 0);
            Assert.AreEqual(board.Matrix[3, 0], 0);

           // Assert.IsTrue(IsBoardEqual(newBoard, board));


            board.Move(Board.Direction.Down);
            //  Assert.IsTrue(IsBoardEqual(newBoard, board));
            Assert.AreEqual(board.Matrix[0, 0], 0);
            Assert.AreEqual(board.Matrix[1, 0], 0);
            Assert.AreEqual(board.Matrix[2, 0], 0);
            Assert.AreEqual(board.Matrix[3, 0], 8);


            board.Move(Board.Direction.Left);
            Assert.AreEqual(board.Matrix[0, 0], 0);
            Assert.AreEqual(board.Matrix[1, 0], 0);
            Assert.AreEqual(board.Matrix[2, 0], 0);
            Assert.AreEqual(board.Matrix[3, 0], 8);


            board.Move(Board.Direction.Right);
            Assert.AreEqual(board.Matrix[0, 3], 0);
            Assert.AreEqual(board.Matrix[1, 3], 0);
            Assert.AreEqual(board.Matrix[2, 3], 0);
            Assert.AreEqual(board.Matrix[3, 3], 8);

        }
        [TestMethod]
        public void FirstRowContainValue()
        {
            int[,] Matrix = new int[,]
            {
                { 2,0,0,0 },
                {2,0,0,2 },
                {0,0,0,0 },
                {0,0,0,0 }
            };
            int indexFirstRowContainValue = Matrix.FirstRowContainValue(0, 2);
            Assert.AreEqual(0, indexFirstRowContainValue);

            indexFirstRowContainValue = Matrix.FirstRowContainValue(1, 2);
            Assert.AreEqual(-1, indexFirstRowContainValue);

            indexFirstRowContainValue = Matrix.FirstRowContainValue(2, 2);
            Assert.AreEqual(-1, indexFirstRowContainValue);

            indexFirstRowContainValue = Matrix.FirstRowContainValue(3, 2);
            Assert.AreEqual(1, indexFirstRowContainValue);

            indexFirstRowContainValue = Matrix.FirstRowContainValue(0, 0);
            Assert.AreEqual(2, indexFirstRowContainValue);

            indexFirstRowContainValue = Matrix.FirstRowContainValue(1, 0);
            Assert.AreEqual(0, indexFirstRowContainValue);

        }

        [TestMethod]
        public void LastRowContainValue()
        {
            int[,] Matrix = new int[,]
            {
                { 2,0,0,0 },
                {2,0,0,2 },
                {0,0,0,0 },
                {0,0,0,0 }
            };
            int indexLastRowContainValue = Matrix.LastRowContainValue(0, 2);
            Assert.AreEqual(1, indexLastRowContainValue);

            indexLastRowContainValue = Matrix.LastRowContainValue(1, 2);
            Assert.AreEqual(-1, indexLastRowContainValue);

            indexLastRowContainValue = Matrix.LastRowContainValue(2, 2);
            Assert.AreEqual(-1, indexLastRowContainValue);

            indexLastRowContainValue = Matrix.LastRowContainValue(3, 2);
            Assert.AreEqual(1, indexLastRowContainValue);

            Matrix = new int[,]
            {
                {0,0,0,2 },
                {0,0,0,0 },
                {0,0,0,0 },
                {2,0,0,0 }
            };

            indexLastRowContainValue = Matrix.LastRowContainValue(0, 2);
            Assert.AreEqual(3, indexLastRowContainValue);


            indexLastRowContainValue = Matrix.LastRowContainValue(3, 2);
            Assert.AreEqual(0, indexLastRowContainValue);


            indexLastRowContainValue = Matrix.LastRowContainValue(1, 0);
            Assert.AreEqual(3, indexLastRowContainValue);


        }


        [TestMethod]
        public void FirstColumnContainValue()
        {
            int[,] Matrix = new int[,]
            {
                { 2,0,0,0 },
                {2,0,0,2 },
                {0,0,0,0 },
                {0,0,0,0 }
            };

        }

        [TestMethod]
        public void LastColumnContainValue()
        {
            int[,] Matrix = new int[,]
            {
                { 2,0,0,0 },
                {2,0,0,2 },
                {0,0,0,0 },
                {0,0,0,0 }
            };

        }
        [TestMethod]
        public void getListOfCanMovePosition()
        {
            Sharp2048.Board board = new Board();
            board.SetRowTileValue(0,new int[]{ 2,0,0,0});
            board.SetRowTileValue(1, new int[] { 2, 0, 0, 2 });

            List<Position> listPosition = board.getListOfCanMovePosition(Board.Direction.Right);
            Assert.AreEqual(2, listPosition.Count );

           
            listPosition = board.getListOfCanMovePosition(Board.Direction.Left);
            Assert.AreEqual(1, listPosition.Count);


            listPosition = board.getListOfCanMovePosition(Board.Direction.Up);
            Assert.AreEqual(2, listPosition.Count);


            listPosition = board.getListOfCanMovePosition(Board.Direction.Down );
            Assert.AreEqual(2, listPosition.Count);

          

        }
        [TestMethod]
        public void MoveToDifferentTile()
        {
            Sharp2048.Board board = new Board();
           

            board = new Board();
            board.Matrix[0, 0] = 2;
            board.Matrix[1, 1] = 2;
            board.Matrix[2, 2] = 2;
            board.Matrix[3, 3] = 2;


            board.Matrix[0, 1] = 4;
            board.Matrix[0, 2] = 4;
            board.Matrix[0, 3] = 4;

            board.Matrix[1, 2] = 8;
            board.Matrix[1, 3] = 8;
            board.Matrix[2, 3] = 8;
                        
            
            //board.Matrix[3, 1] = 4;

           // Board originalBoard = board.Clone();
            board.Move(Board.Direction.Right);
            Assert.AreEqual(board.Matrix[0, 0], 0);
            Assert.AreEqual(board.Matrix[0, 1], 2);
            Assert.AreEqual(board.Matrix[0, 2], 4);
            Assert.AreEqual(board.Matrix[0, 3], 8);

            Assert.AreEqual(board.Matrix[1, 0], 0);
            Assert.AreEqual(board.Matrix[1, 1], 0);
            Assert.AreEqual(board.Matrix[1, 2], 2);
            Assert.AreEqual(board.Matrix[1, 3], 16);

            Assert.AreEqual(board.Matrix[2, 0], 0);
            Assert.AreEqual(board.Matrix[2, 1], 0);
            Assert.AreEqual(board.Matrix[2, 2], 2);
            Assert.AreEqual(board.Matrix[2, 3], 8);
            //   Assert.IsTrue(IsBoardEqual(originalBoard, board));


        }

        [TestMethod]
        public void IsGameFinished()
        {
            Sharp2048.Board board = new Board();


            board = new Board();
           

            Assert.AreEqual(board.IsGameFinished(), false);
            int i;
            int j;
            for (i = 0; i < board.RowSize; i++)
            {
                for (j = 0; j < board.ColSize; j++)
                {
                    board.Matrix[i, j] = 2048;
                }
            }
            Assert.AreEqual(board.IsGameFinished(), true);

        }
        [TestMethod]
        public void MoveToSameTile()
        {
            Sharp2048.Board board = new Board();


            board = new Board();
            board.Matrix[0, 0] = 2;
            board.Matrix[1, 1] = 2;
            board.Matrix[2, 2] = 2;
            board.Matrix[3, 3] = 2;


            board.Matrix[0, 3] = 2;
            board.Matrix[1, 3] = 2;
            board.Matrix[2, 3] = 2;
            //board.Matrix[3, 1] = 4;
            Assert.AreEqual(board.Score, 0);
            //Board originalBoard = board.Clone();
            board.Move(Board.Direction.Right);
            Assert.AreEqual(board.Matrix[0, 0], 0);
            Assert.AreEqual(board.Matrix[1, 1], 0);
            Assert.AreEqual(board.Matrix[2, 2], 0);
            Assert.AreEqual(board.Matrix[3, 3], 2);



            Assert.AreEqual(board.Matrix[0, 3], 4);
            Assert.AreEqual(board.Matrix[1, 3], 4);
            Assert.AreEqual(board.Matrix[2, 3], 4);
            Assert.AreEqual(board.Score, 12);

            board.Move(Board.Direction.Up);
            Assert.AreEqual(board.Matrix[0, 3], 8);
            Assert.AreEqual(board.Matrix[1, 3], 4);
            Assert.AreEqual(board.Matrix[2, 3], 2);
            Assert.AreEqual(board.Matrix[3, 3], 0);
            Assert.AreEqual(board.Score, 20);

            board = new Board();
            board.Matrix[0, 0] = 2;
            board.Matrix[0, 1] = 2;
            board.Matrix[0, 2] = 2;
            board.Matrix[0, 3] = 2;

            board.Move(Board.Direction.Left );
            Assert.AreEqual(board.Matrix[0, 0], 4);
            Assert.AreEqual(board.Matrix[0, 1], 4);
            Assert.AreEqual(board.Matrix[0, 2], 0);
            Assert.AreEqual(board.Matrix[0, 3], 0);
            Assert.AreEqual(board.Score, 8);

            board = new Board();
            board.Matrix[0, 0] = 2;
            board.Matrix[0, 1] = 2;
            board.Matrix[0, 2] = 2;
            board.Matrix[0, 3] = 2;

            board.Move(Board.Direction.Right);
            Assert.AreEqual(board.Matrix[0, 0], 0);
            Assert.AreEqual(board.Matrix[0, 1], 0);
            Assert.AreEqual(board.Matrix[0, 2], 4);
            Assert.AreEqual(board.Matrix[0, 3], 4);
            Assert.AreEqual(board.Score, 8);

            board = new Board();
            board.Matrix[0, 0] = 0;
            board.Matrix[0, 1] = 2;
            board.Matrix[0, 2] = 2;
            board.Matrix[0, 3] = 2;
            board.Move(Board.Direction.Right);
            Assert.AreEqual(board.Matrix[0, 0], 0);
            Assert.AreEqual(board.Matrix[0, 1], 0);
            Assert.AreEqual(board.Matrix[0, 2], 2);
            Assert.AreEqual(board.Matrix[0, 3], 4);
            Assert.AreEqual(board.Score, 4);
            board = new Board();
            board.Matrix[0, 0] = 2;
            board.Matrix[0, 1] = 0;
            board.Matrix[0, 2] = 2;
            board.Matrix[0, 3] = 2;
            board.Move(Board.Direction.Right);
            Assert.AreEqual(board.Matrix[0, 0], 0);
            Assert.AreEqual(board.Matrix[0, 1], 0);
            Assert.AreEqual(board.Matrix[0, 2], 2);
            Assert.AreEqual(board.Matrix[0, 3], 4);
            Assert.AreEqual(board.Score, 4);

            board = new Board();
            board.Matrix[0, 0] = 2;
            board.Matrix[1, 0] = 2;
            board.Matrix[2, 0] = 2;
            board.Matrix[3, 0] = 2;
            board.Move(Board.Direction.Up );
            Assert.AreEqual(board.Matrix[0, 0], 4);
            Assert.AreEqual(board.Matrix[1, 0], 4);
            Assert.AreEqual(board.Matrix[2, 0], 0);
            Assert.AreEqual(board.Matrix[3, 0], 0);
            Assert.AreEqual(board.Score, 8);

            board = new Board();
            board.Matrix[0, 0] = 2;
            board.Matrix[1, 0] = 2;
            board.Matrix[2, 0] = 2;
            board.Matrix[3, 0] = 2;
            board.Move(Board.Direction.Down);
            Assert.AreEqual(board.Matrix[0, 0], 0);
            Assert.AreEqual(board.Matrix[1, 0], 0);
            Assert.AreEqual(board.Matrix[2, 0], 4);
            Assert.AreEqual(board.Matrix[3, 0], 4);
            Assert.AreEqual(board.Score, 8);

            board.Move(Board.Direction.Down);
            Assert.AreEqual(board.Matrix[0, 0], 0);
            Assert.AreEqual(board.Matrix[1, 0], 0);
            Assert.AreEqual(board.Matrix[2, 0], 0);
            Assert.AreEqual(board.Matrix[3, 0], 8);
            Assert.AreEqual(board.Score, 16);

            // Assert.IsTrue(IsBoardEqual(originalBoard, board));


        }



        [TestMethod]
        public void MoveToSameTile2()
        {
            Sharp2048.Board board = new Board();


            board = new Board();
            board.SetRowTileValue(0, new int[] { 4, 2, 2, 4 });


            board.Move(Board.Direction.Left);
            Assert.AreEqual(board.Matrix[0, 0], 4);
            Assert.AreEqual(board.Matrix[0, 1], 4);
            Assert.AreEqual(board.Matrix[0, 2], 4);
            Assert.AreEqual(board.Matrix[0, 3], 0);
            Assert.AreEqual(board.Score,4);

            board.Move(Board.Direction.Left);
            Assert.AreEqual(board.Matrix[0, 0], 8);
            Assert.AreEqual(board.Matrix[0, 1], 4);
            Assert.AreEqual(board.Matrix[0, 2], 0);
            Assert.AreEqual(board.Matrix[0, 3], 0);
            Assert.AreEqual(board.Score, 12);





        }
    }
}
