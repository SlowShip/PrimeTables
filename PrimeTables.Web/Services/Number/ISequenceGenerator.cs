using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrimeTables.Web.Services.Number
{
    public interface ISequenceGenerator
    {
        IEnumerable<int> CreateSequence(int length);
    }
}