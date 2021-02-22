using System;
using System.Collections.Generic;
using System.Text;

namespace CoroVi
{
    public class CountriesClass
    {
        public string country { get; set; }

        public int cases { get; set; }
        public int todayCases { get; set; }

        public int deaths { get; set; }
        public int todayDeaths { get; set; }

        public int recovered { get; set; }
        public int todayRecovered { get; set; }


        public CountriesClass() { }
    }
}
