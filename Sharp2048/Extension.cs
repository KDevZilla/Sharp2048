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
    }
}
