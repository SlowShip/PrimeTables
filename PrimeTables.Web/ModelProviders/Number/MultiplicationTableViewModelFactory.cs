using PrimeTables.Web.Models;
using PrimeTables.Web.Services.Number;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrimeTables.Web.ModelProviders.Number
{
    public class MultiplicationTableViewModelFactory : IMultiplicationTableViewModelFactory
    {
        private readonly IMultiplicationTableCalculator tableCalculator;
        private readonly IDictionary<SequenceType, ISequenceGenerator> sequenceGenerators;
        
        public MultiplicationTableViewModelFactory(IMultiplicationTableCalculator tableCalculator, IDictionary<SequenceType, ISequenceGenerator> sequenceGenerators)
        {
            if (tableCalculator == null)
            {
                throw new ArgumentNullException("tableCalculator");
            }

            if (sequenceGenerators == null)
            {
                throw new ArgumentNullException("sequenceGenerators");
            }

            this.tableCalculator = tableCalculator;
            this.sequenceGenerators = sequenceGenerators;
        }

        public MultiplicationTableViewModel Create(SequenceType sequenceType, int tableSize)
        {
            if(tableSize <= 0)
            {
                throw new ArgumentOutOfRangeException("tableSize", "tableSize must be greater than zero");
            }

            ISequenceGenerator sequenceGenerator;
            if (!sequenceGenerators.TryGetValue(sequenceType, out sequenceGenerator))
            {
                var msg = string.Format("No {0} has been registered for {1}.{2}", typeof(ISequenceGenerator).Name, typeof(SequenceType).Name, sequenceType);
                throw new NotSupportedException(msg);
            }

            var sequence = sequenceGenerator.CreateSequence(tableSize);
            var table = tableCalculator.CreateTable(sequence);

            return new MultiplicationTableViewModel()
            {
                TableSize = tableSize,
                Table = table
            };
        }
    }
}