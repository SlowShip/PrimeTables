using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrimeTables.Web.Services.Number
{
    public interface IMultiplicationTableCalculator
    {
        int[][] CreateTable(IEnumerable<int> factors);
    }
}