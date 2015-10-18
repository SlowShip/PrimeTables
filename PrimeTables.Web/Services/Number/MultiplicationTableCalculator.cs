using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrimeTables.Web.Services.Number
{
    public class MultiplicationTableCalculator : IMultiplicationTableCalculator
    {
        public int[,] CreateTable(IEnumerable<int> factors)
        {
            if(factors == null)
            {
                throw new ArgumentNullException("factors");
            }

            var factorsArray = factors.ToArray();
            var tableSize = factors.Count();

            // Size is +1 because first row and column are take up with the factors
            var result = new int[tableSize + 1, tableSize + 1];
            
            // Initalise top row and first column
            for (int index = 1; index <= tableSize; index++)
            {
                var val = factorsArray[index - 1];
                result[0, index] = val;
                result[index, 0] = val;
            }

            // Initalise all other values with the product 
            for (int col = 1; col <= tableSize; col++)
            {
                for (int row = 1; row <= tableSize; row++)
                {
                    var val = result[0, col] * result[row, 0];
                    result[row, col] = val;
                }
            }

            return result;
        }
    }
}