using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrimeTables.Web.Services.Number
{
    public class PrimesSequenceGenerator : ISequenceGenerator
    {
        public IEnumerable<int> CreateSequence(int length)
        {
            if (length < 0)
            {
                throw new ArgumentOutOfRangeException("length");
            }

            if(length == 0)
            {
                return new int[0];
            }

            var candidate = 2; 
            List<int> foundPrimes = new List<int>();
            
            while(foundPrimes.Count() < length)
            {
               if(!DivisorExists(candidate, foundPrimes))
               {
                   foundPrimes.Add(candidate);
               }
               candidate++;
            }

            return foundPrimes;
        }

        public bool DivisorExists(int candidate, IEnumerable<int> potentialDivisors)
        {
            foreach (var potentialDivisor in potentialDivisors)
            {
                if (candidate % potentialDivisor == 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}