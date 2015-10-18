using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrimeTables.Web.Services.Number
{
    public class OptimisedPrimesSequenceGenerator : ISequenceGenerator
    {
        public IEnumerable<int> CreateSequence(int length)
        {
            if (length < 0)
            {
                throw new ArgumentOutOfRangeException("length");
            }

            if (length == 0)
            {
                return new int[0];
            }

            var upperBound = GetUpperLimitOfPrime(length);
            var roundedUpUpperBound = (int)Math.Ceiling(upperBound);

            return Sieve(roundedUpUpperBound).Take(length);
        }

        // Uses prime number theorem to create an upper bound of nth prime (see https://en.wikipedia.org/wiki/Prime_number_theorem#Approximations_for_the_nth_prime_number)
        private double GetUpperLimitOfPrime(int n)
        {
            if (n < 6)
            {
                return 12;
            }
            else
            {
                return n * (Math.Log(n) + Math.Log(Math.Log(n)));
            }
        }

        // Sieve of Eratosthenes to find all primes less than n (see https://en.wikipedia.org/wiki/Sieve_of_Eratosthenes#Algorithm_and_variants)
        // complexity O(n log(log(n)))
        private IEnumerable<int> Sieve(int limit)
        {
            var possibleValues = Enumerable.Repeat(true, limit + 1).ToArray(); // +1 as arrays start at 0
            possibleValues[0] = false;
            possibleValues[1] = false;

            for(int i = 2; i*i<= limit; i++) // Only need to itterate up to the sqrt of the limit (if no factor found by then, it doesn't exist)
            {
                if(possibleValues[i])
                {
                    for(int j = i*i; j <= limit; j += i) // start at i^2 as all smaller multiples have already been set by previous itterations
                    {
                        possibleValues[j] = false;
                    }
                }
            }

            return possibleValues
                .Select((value, index) => new { value, index })
                .Where(x => x.value)
                .Select(x => x.index);
        }
    }
}