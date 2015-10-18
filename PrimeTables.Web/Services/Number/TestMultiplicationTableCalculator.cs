using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrimeTables.Web.Services.Number
{
    public class TestMultiplicationTableCalculator : IMultiplicationTableCalculator
    {
        public int[,] CreateTable(IEnumerable<int> factors)
        {
            var tableSize = factors.Count();
            return new int[tableSize + 1, tableSize + 1];
        }
    }
}