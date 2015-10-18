using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrimeTables.Web.Models
{
    public class MultiplicationTableViewModel
    {
        public int TableSize { get; set; }
        public int[,] Table { get; set; }
    }
}