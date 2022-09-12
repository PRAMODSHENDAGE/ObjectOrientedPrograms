using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedPrograms.StockManagementSystem
{
    internal class Company
    {
        public string? Symbol { get; set; }
        public int NoOfShares { get; set; }
        public int PricePerShare { get; set; }
    }
}
