using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrimeTables.Web.Services.Number
{
    public class NaturalsSequenceGenerator : ISequenceGenerator
    {
        public IEnumerable<int> CreateSequence(int length)
        {
            if(length < 0)
            {
                throw new ArgumentOutOfRangeException("length");
            }

            return Enumerable.Range(1, length);
        }
    }
}