using PrimeTables.Web.Models;
using System;

namespace PrimeTables.Web.ModelProviders.Number
{
    public interface IMultiplicationTableViewModelFactory
    {
        MultiplicationTableViewModel Create(SequenceType sequenceType, int tableSize);
    }
}
