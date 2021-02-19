using System;
using System.Collections.Generic;
using System.Text;

namespace CoroVi
{
    public class CountriesSummaryClass
    {
        public string Country { get; set; }
        public int Confirmed { get; set; }

        public int Deaths { get; set; }

        public int Recovered { get; set; }

        public CountriesSummaryClass() { }
    }
}
