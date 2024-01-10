using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharp2048
{
    public static class Extension
    {


        public static List<int> GetRowIndicesInColumnContainValue<T>(this T[,] array, int column, T containValue)
        {
            // Ensure column index is within bounds
            if (column < 0 || column >= array.GetLength(1))
            {
                throw new IndexOutOfRangeException("Column index out of bounds");
            }

            int i;

            List<int> listRowIndices = new List<int>();
            for (i = 0; i < array.GetLength(0); i++)
            {
                if (array[i, column].Equals(containValue))
                {
                    listRowIndices.Add(i);
                }
            }
            return listRowIndices;
        }
        public static List<int> GetColumnIndicesInRowContainValue<T>(this T[,] array, int row, T containValue)
        {

            if (row < 0 || row >= array.GetLength(0))
            {
                throw new IndexOutOfRangeException("Row index out of bounds");
            }

            int j;
            List<int> listColumnIndices = new List<int>();
            for(j=0;j<array.GetLength(1); j++)
            {
                if(array[row,j].Equals(containValue))
                {
                    listColumnIndices.Add(j);
                }
            }
            return listColumnIndices;
        }
        public static bool IsColumnContainValue<T>(this T[,] array, int column, T valueContain)
        {
            // Ensure column index is within bounds
            if (column < 0 || column >= array.GetLength(1))
            {
                throw new IndexOutOfRangeException("Column index out of bounds");
            }

            // Iterate through the elements of the specified column
            return array.Cast<T>().Where((element, index) => index % array.GetLength(1) == column).Contains(valueContain);
        }
        public static int FirstRowContainValue<T>(this T[,] array, int ofColumn, int valueContain)
        {
            int i;
            for (i = 0; i <= array.GetUpperBound(0); i++)
            {


                if (array[i, ofColumn].Equals(valueContain))
                {
                    return i;
                }
            }
            return -1;
        }

        public static int LastRowContainValue<T>(this T[,] array, int ofColumn, int valueContain)
        {
            int i;
            for (i = array.GetUpperBound(0); i >=0; i--)
            {


                if (array[i, ofColumn].Equals(valueContain))
                {
                    return i;
                }
            }
            return -1;
        }
        public static int FirstColumnContainValue<T>(this T[,] array,int ofRow,int valueContain)
        {
            int i;
            for(i=0;i<=array.GetUpperBound(1); i++)
            {


                if(array[ofRow, i].Equals(valueContain))
                {
                    return i;
                }
            }
            return -1;
        }

        public static int LastColumnContainValue<T>(this T[,] array, int ofRow, int valueContain)
        {
            int i;
            for (i = array.GetUpperBound (1); i>=0;i--)
            {


                if (array[ofRow, i].Equals(valueContain))
                {
                    return i;
                }
            }
            return -1;
        }
        public static bool IsRowContainValue<T>(this T[,] array, int row, T valueContain)
        {
            // Ensure row index is within bounds
            if (row < 0 || row >= array.GetLength(0))
            {
                throw new IndexOutOfRangeException("Row index out of bounds");
            }

            // Iterate through the elements of the specified row
            return array.Cast<T>().Skip(row * array.GetLength(1)).Take(array.GetLength(1)).Contains(valueContain);
        }

        public static bool IsRowContainOtherValueThanThis<T>(this T[,] array, int row, T valueCheck)
        {
            // Ensure row index is within bounds
            if (row < 0 || row >= array.GetLength(0))
            {
                throw new IndexOutOfRangeException("Row index out of bounds");
            }
            int i;
            for(i=0;i<=array.GetUpperBound(1); i++)
            {
                if (!array[row, i].Equals(valueCheck))
                {
                    return true;
                }
            }
            return false;
            // Iterate through the elements of the specified row
            //return array.Cast<T>().Skip(row * array.GetLength(1)).Take(array.GetLength(1)).Contains(valueContain);
        }

        public static bool IsColumnContainOtherValueThanThis<T>(this T[,] array, int column, T valueCheck)
        {
            // Ensure row index is within bounds
            if (column < 0 || column >= array.GetLength(1))
            {
                throw new IndexOutOfRangeException("Column index out of bounds");
            }
            int i;
            for (i = 0; i <= array.GetUpperBound(0); i++)
            {
                if (!array[i, column].Equals(valueCheck))
                {
                    return true;
                }
            }
            return false;
            // Iterate through the elements of the specified row
            //return array.Cast<T>().Skip(row * array.GetLength(1)).Take(array.GetLength(1)).Contains(valueContain);
        }
    }
}
