using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharp2048
{
    public class Board
    {
        public int[,] Matrix;
        public int RowSize { get; private set; } = 4;
        public int ColSize { get; private set; } = 4;
        public Board Clone()
        {
            Board newBoard = new Board();
            int i;
            int j;
            for (i = 0; i < newBoard.RowSize; i++)
            {
                for (j = 0; j < newBoard.ColSize; j++)
                {
                    newBoard.Matrix[i, j] = this.Matrix[i, j];
                }
            }
            return newBoard;
        }
        public void SetRowTileValue(int row, int[] arrValue)
        {
            int i;
            for (i = 0; i < arrValue.Length; i++)
            {
                Matrix[row, i] = arrValue[i];
            }
        }
        public void SetColTileValue(int col, int[] arrValue)
        {
            int i;
            for (i = 0; i < arrValue.Length; i++)
            {
                Matrix[i, col] = arrValue[i];
            }
        }
        public bool CanMove()
        {
            int i;
            int j;
            List<int> listNeightborRow = new List<int>()
            {
                -1, //Up
                1,  //Down
                0,  //Left
                0  //Right
            };
            List<int> listNeightborCol = new List<int>()
            {
                0, //Up
                0,  //Down
                -1,  //Left
                1  //Right
            };
            int k;
            for (i = 0; i < RowSize; i++)
            {
                for (j = 0; j < ColSize; j++)
                {
                    if(Matrix [i,j]== 0)
                    {
                        return true;
                    }
                    for (k = 0; k < listNeightborRow.Count; k++)
                    {
                        int neighborRow = i + listNeightborRow [k];
                        int neighborCol = j + listNeightborCol [k];
                        if(!IsValidPosition(neighborRow, neighborCol))
                        {
                            continue;
                        }
                        if (Matrix[neighborRow, neighborCol] == 0
                                || Matrix[neighborRow, neighborCol] == Matrix[i, j])
                        {
                            return true;
                        }
                    }
                   
                    //newBoard.Matrix[i, j] = this.Matrix[i, j];
                }
            }
            return false;
        }
        public Board()
        {
            Matrix = new int[RowSize, ColSize];
            int i;
            int j;
            for (i = 0; i < RowSize; i++)
            {
                for (j = 0; j < ColSize; j++)
                {
                    Matrix[i, j] = 0;
                }
            }
        }
        public enum Direction
        {
            Up,
            Down,
            Left,
            Right
        }
        public enum MovingResult
        {
            NotMoveYet,
            FoundBlankTile,
            FoundSamevalueTile,
            FoundDifferentValue
        }
        public bool IsGameFinished()
        {
            int i;
            int j;
            for (i = 0; i < RowSize; i++)
            {
                for (j = 0; j < ColSize; j++)
                {
                    if(Matrix [i,j] != 2048)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public int Score { get; private set; } = 0;
        public void AddScore(int addScore)
        {
            Score += addScore;
        }
        private bool internalMove(Direction direction)
        {
            int i;
            int j;
            int deltaRow = 0;
            int deltaCol = 0;
            int firstRow = 0;
            int firstCol = 0;
            int lastRow = 0;
            int lastCol = 0;
            bool IsDirectionValid = false;
            bool[,] IsTileANewMix = new bool[this.RowSize , this.ColSize ];
            for (i = 0; i < this.RowSize ; i++)
            {
                for (j = 0; j < this.ColSize ; j++)
                {
                    IsTileANewMix[i, j] = false;
                }
            }
            switch (direction)
            {
                case Direction.Up:
                    deltaRow = -1;
                    firstRow = 0;
                    firstCol = 0;
                    lastRow = RowSize - 1;
                    lastCol = ColSize - 1;
                    break;
                case Direction.Down:
                    deltaRow = 1;
                    firstRow = RowSize - 1;
                    firstCol = ColSize - 1;
                    lastRow = 0;
                    lastCol = 0;

                    break;
                case Direction.Right:
                    deltaCol = 1;
                    firstRow = 0;
                    lastRow = RowSize - 1;

                    firstCol = ColSize - 1;                    
                    lastCol = 0;
                    break;
                case Direction.Left:
                    deltaCol  = -1;
                    firstRow = 0;
                    lastRow = RowSize - 1;
                    firstCol = 0;
                    lastCol = ColSize - 1;
                    break;
            }
            int iChange = firstRow < lastRow
                ? 1
                : -1;
            int jChange = firstCol < lastCol
                ? 1
                : -1;
            for (i = firstRow; 
                iChange == 1 
                    ? i<=lastRow
                    : i>=lastRow 
                ; i+=iChange)
            {
                for (j = firstCol; 
                    jChange ==1 
                        ? j<=lastCol
                        : j>=lastCol 
                    ; j+=jChange)
                {

                    bool hasFinishedMoving = false;
                    int newRow = i + deltaRow;
                    int newCol = j + deltaCol;
                    int tileValue = Matrix[i, j];
                    bool CanMove = false;
                    int destinationRow = 0;
                    int destinationCol = 0;

                    while (!hasFinishedMoving)
                    {
                        MovingResult moveResult = MovingResult.NotMoveYet;
                        if (!IsValidPosition(newRow, newCol))
                        {
                            hasFinishedMoving = true;
                            continue;
                        }
                        if(tileValue == 0)
                        {
                            hasFinishedMoving = true;
                            continue;
                        }

                        if (Matrix[newRow, newCol] == tileValue
                            && !IsTileANewMix [newRow ,newCol ])
                        {
                           moveResult = MovingResult.FoundSamevalueTile;
                        } else if (Matrix[newRow, newCol] == 0)
                        {
                            moveResult = MovingResult.FoundBlankTile;
                        }
                        else
                        {
                            moveResult = MovingResult.FoundDifferentValue;
                        }

                        switch (moveResult)
                        {
                            case MovingResult.FoundBlankTile:
                                CanMove = true;
                                destinationRow = newRow;
                                destinationCol = newCol;

                                newRow = newRow + deltaRow;
                                newCol = newCol + deltaCol;
                                break;
                            case MovingResult.FoundSamevalueTile:
                                destinationRow = newRow;
                                destinationCol = newCol;

                                hasFinishedMoving = true;
                                CanMove = true;
                                break;
                            case MovingResult.FoundDifferentValue:
                                hasFinishedMoving = true;
                                break;

                        }
                    }

                    if (!CanMove)
                    {
                        continue;
                    }
                        if(Matrix [i,j]==Matrix [destinationRow ,destinationCol])
                        {
                            Matrix[destinationRow, destinationCol] *= 2;
                            AddScore(Matrix[destinationRow, destinationCol]);
                            IsTileANewMix[destinationRow, destinationCol] = true;
                        }else
                        {
                            Matrix[destinationRow, destinationCol] = Matrix[i, j];                            
                        }
                        Matrix[i, j] = 0;
                    IsDirectionValid = true;


                }
            }
            return IsDirectionValid;
        }
        public bool Move(Direction direction)
        {
           return  internalMove(direction);
           // internalMove(direction);
        }
        private bool IsValidPosition(int row , int column)
        {
            return (row >= 0
                && row < RowSize
                && column >= 0
                && column < ColSize);
           
            /*
            if (row < 0 
                || row >= RowSize 
                || column < 0
                || column >= ColSize)
            {
                return false;
            }

            return true;
            */
        }
        private static readonly Random getrandom = new Random();

        public static int GetRandomNumber(int min, int max)
        {
            lock (getrandom) // synchronize
            {
                return getrandom.Next(min, max);
            }
        }
        public void RandomPopupInitial()
        {
             RandomPopupNewValue(2,2);
        }
        public void RandomPopUpNext()
        {

            int randomNumber =GetRandomNumber(0, 10);
            // Some time we would like to random 4 number
            int numberofRandomTile = randomNumber != 5
                                    ? 2
                                    : 4;
           
            RandomPopupNewValue(1, numberofRandomTile);

        }
        public void RandomPopupNewValue(int numberofRandomTile,int value)
        {
            int newRandomTile = 0;
            HashSet<String> hshRandom = new HashSet<string>();
            while (newRandomTile < numberofRandomTile)
            {
                int rowRandom = GetRandomNumber(0, RowSize);
                int colRandom = GetRandomNumber(0, ColSize);
                if(Matrix [rowRandom ,colRandom ] != 0)
                {
                    continue;
                }
                string rowColumnString = rowRandom + "_" + colRandom;
                if(hshRandom.Contains(rowColumnString))
                {
                    continue;
                }
                hshRandom.Add(rowColumnString);
                Matrix[rowRandom, colRandom] = value;
                newRandomTile++;
            }


        }

    }
}
