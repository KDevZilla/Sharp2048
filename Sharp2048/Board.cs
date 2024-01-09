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
        private Position swapFromPosition = null;
        public Board SwapTileValueFrom(int row, int column)
        {
            swapFromPosition = new Position(row, column);
            return this;
        }
        public void To(int row, int column)
        {
            var toPosition = new Position(row, column);
            var temp = Matrix[toPosition.Row, toPosition.Column];
            Matrix[toPosition.Row, toPosition.Column] = Matrix[swapFromPosition.Row, swapFromPosition.Column];
            Matrix[swapFromPosition.Row, swapFromPosition.Column] = temp;
            swapFromPosition = null;
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
                                || (Matrix[neighborRow, neighborCol] == Matrix[i, j]  
                                   && Matrix [i,j] != 4096)
                                   )
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
        public bool IsWon { get; private set; } = false;
        
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
            if(addScore == 4096)
            {
                IsWon = true;
            }
            Score += addScore;
        }
        public List<MovePosition> getListOfMovePosition(Direction direction)
        {
            int rowMoveIndex;
            int columnMoveIndex;
            int deltaRow = 0;
            int deltaCol = 0;
            int firstRow = 0;
            int firstCol = 0;
            int lastRowIndex = 0;
            int lastCol = 0;
            bool IsDirectionValid = false;
            bool[,] IsTileANewMix = new bool[this.RowSize, this.ColSize];
            List<MovePosition> listResult = new List<MovePosition>();
            for (rowMoveIndex = 0; rowMoveIndex < this.RowSize; rowMoveIndex++)
            {
                for (columnMoveIndex = 0; columnMoveIndex < this.ColSize; columnMoveIndex++)
                {
                    IsTileANewMix[rowMoveIndex, columnMoveIndex] = false;
                }
            }
            switch (direction)
            {
                case Direction.Up:
                    deltaRow = -1;
                    firstRow = 0;
                    firstCol = 0;
                    lastRowIndex = RowSize - 1;
                    lastCol = ColSize - 1;
                    break;
                case Direction.Down:
                    deltaRow = 1;
                    firstRow = RowSize - 1;
                    firstCol = ColSize - 1;
                    lastRowIndex = 0;
                    lastCol = 0;

                    break;
                case Direction.Right:
                    deltaCol = 1;
                    firstRow = 0;
                    lastRowIndex = RowSize - 1;

                    firstCol = ColSize - 1;
                    lastCol = 0;
                    break;
                case Direction.Left:
                    deltaCol = -1;
                    firstRow = 0;
                    lastRowIndex = RowSize - 1;
                    firstCol = 0;
                    lastCol = ColSize - 1;
                    break;
            }
            List<Position> listTileCanMoveColumn = new List<Position>();
            List<Position> listTileCanMoveRow = new List<Position>();

            for (rowMoveIndex = 0;rowMoveIndex <=3;rowMoveIndex++)
            {
                Boolean hasAtLeastOneBlankTile = false;
                Boolean hasAtLeastOneNonBlankTile = false;
                hasAtLeastOneBlankTile = Matrix.IsRowContainValue(rowMoveIndex, 0);
                hasAtLeastOneNonBlankTile = !Matrix.IsRowContainValue(rowMoveIndex, 0);

                Boolean CanMoveTileInThisColumn = (hasAtLeastOneBlankTile && hasAtLeastOneNonBlankTile);
                if (CanMoveTileInThisColumn)
                {
                  //  listTileCanMoveRow = Matrix.GetRowIndicesInColumnContainValue 
                  //  listTileCanMoveColumn.Add(new Position(rowMoveIndex, columnMoveIndex));
                }
            }

            for (columnMoveIndex = 0; columnMoveIndex <= 3; columnMoveIndex++)
            {
                Boolean hasAtLeastOneBlankTile = false;
                Boolean hasAtLeastOneNonBlankTile = false;
                hasAtLeastOneBlankTile = Matrix.IsColumnContainValue(columnMoveIndex, 0);
                hasAtLeastOneNonBlankTile = !Matrix.IsColumnContainValue(columnMoveIndex, 0);

                Boolean CanMoveTileInThisRow = (hasAtLeastOneBlankTile && hasAtLeastOneNonBlankTile);
                if (CanMoveTileInThisRow)
                {
                  //  listTileCanMoveRow.Add(new Position(columnMoveIndex, columnMoveIndex));
                }
            }


            int rowIndexChange = firstRow < lastRowIndex
                ? 1
                : -1;
            int columnIndexChange = firstCol < lastCol
                ? 1
                : -1;

            for (rowMoveIndex = firstRow; ; rowMoveIndex += rowIndexChange)
            {
                bool hasReachedTheLastILoop = (rowIndexChange == 1 && rowMoveIndex > lastRowIndex)
                                          || (rowIndexChange == -1 && rowMoveIndex < lastRowIndex);
                if (hasReachedTheLastILoop)
                {
                    break;
                }

                for (columnMoveIndex = firstCol; ; columnMoveIndex += columnIndexChange)
                {
                    bool hasReachedTheLastJLoop = (columnIndexChange == 1 && columnMoveIndex > lastRowIndex)
                                         || (columnIndexChange == -1 && columnMoveIndex < lastRowIndex);
                    if (hasReachedTheLastJLoop)
                    {
                        break;
                    }

                    bool hasFinishedMoving = false;
                    int newRow = rowMoveIndex + deltaRow;
                    int newCol = columnMoveIndex + deltaCol;
                    int tileValue = Matrix[rowMoveIndex, columnMoveIndex];

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
                        if (tileValue == 0)
                        {
                            hasFinishedMoving = true;
                            continue;
                        }

                        if (Matrix[newRow, newCol] == tileValue
                            && !IsTileANewMix[newRow, newCol]
                            && Matrix[newRow, newCol] != 4096)
                        {
                            moveResult = MovingResult.FoundSamevalueTile;
                        }
                        else if (Matrix[newRow, newCol] == 0)
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
                    bool isHitTheSameValue = (Matrix[rowMoveIndex, columnMoveIndex] == Matrix[destinationRow, destinationCol]);

                    if (isHitTheSameValue)
                    {
                        int newValue= Matrix[destinationRow, destinationCol] * 2;
                        listResult.Add(new MovePosition(fromRow: rowMoveIndex,
                            fromColumn: columnMoveIndex,
                            toRow: destinationRow,
                            toPosition: destinationCol,
                            newValue: newValue));

                    }
                    else
                    {
                        Matrix[destinationRow, destinationCol] = Matrix[rowMoveIndex, columnMoveIndex];
                    }
                    Matrix[rowMoveIndex, columnMoveIndex] = 0;
                    IsDirectionValid = true;


                }
            }
            return listResult;
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
            
            for (i = firstRow; ; i+=iChange)
            {
                bool hasReachedTheLastILoop = (iChange ==  1 && i > lastRow)
                                          || (iChange == -1 && i < lastRow);
                if (hasReachedTheLastILoop)
                {
                    break;
                }

                for (j = firstCol;  ; j+=jChange)
                {
                    bool hasReachedTheLastJLoop = (jChange == 1 && i > lastRow)
                                         || (jChange == -1 && i < lastRow);
                    if (hasReachedTheLastJLoop)
                    {
                        break;
                    }

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
                            && !IsTileANewMix [newRow ,newCol ]
                            && Matrix [newRow,newCol] != 4096)
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
        private bool IsValidPosition(int row, int column) => row >= 0
                && row < RowSize
                && column >= 0
                && column < ColSize;

        private static readonly Random getrandom = new Random();

        public static int GetRandomNumber(int min, int max)
        {
            lock (getrandom) // synchronize
            {
                return getrandom.Next(min, max);
            }
        }
        public void RandomPopupInitial() => RandomPopupNewValue(2, 2);

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
            int count = 0;
            while (newRandomTile < numberofRandomTile)
            {
                count++;
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

                if(count > 1000000)
                {
                    throw new Exception("RandomPopNewValue already try to generate a random number 10000000 times still not succeed.");
                }
            }


        }

    }
}
