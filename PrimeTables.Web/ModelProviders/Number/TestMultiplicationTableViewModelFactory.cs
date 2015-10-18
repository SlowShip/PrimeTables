using PrimeTables.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrimeTables.Web.ModelProviders.Number
{
    public class TestMultiplicationTableViewModelFactory : IMultiplicationTableViewModelFactory
    {
        public MultiplicationTableViewModel Create(SequenceType sequenceType, int tableSize)
        {
            return new MultiplicationTableViewModel()
            {
                TableSize = tableSize,
                Table = new int[tableSize + 1, tableSize + 1]
            };
        }
    }
}