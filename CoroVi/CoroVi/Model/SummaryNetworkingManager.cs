using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace CoroVi
{
    public class SummaryNetworkingManager
    {

        public string todaydate = "&to=" + DateTime.Now.ToString("yyyy-MM-dd") + "T00:00:00Z";
        public string yesterdaydate = "?from=" + DateTime.Today.AddDays(-1).ToString("yyyy-MM-dd") + "T00:00:00Z";

        private string url_total = "https://api.covid19api.com/world/total";

        // URL for country names
        //private string url_country_names = "https://gist.githubusercontent.com/keeguon/2310008/raw/bdc2ce1c1e3f28f9cab5b4393c7549f38361be4e/countries.json";

        //
        //private string url_dayone_country = "https://api.covid19api.com/dayone/country/south-africa";
        private string url_dayone_country = "https://api.covid19api.com/country/canada";

        //
        private string url_summary = "https://api.covid19api.com/summary";


        private string url_country = "https://api.covid19api.com/country/";


        private HttpClient client = new HttpClient();
         
        public SummaryNetworkingManager()
        {
        }

        public async Task<CovidSummaryClass> GetSummaryCovid()
        {

            var response = await client.GetStringAsync(url_total);
            CovidSummaryClass cs = JsonConvert.DeserializeObject<CovidSummaryClass>(response);
            //Console.WriteLine(cs.TotalConfirmed);

            return JsonConvert.DeserializeObject<CovidSummaryClass>(response);

        }

        public async Task<List<CountriesSummaryClass>> GetCountriesCovid()
        {
            Console.WriteLine(yesterdaydate);
            Console.WriteLine(todaydate);

            var final_url = url_dayone_country  + yesterdaydate + todaydate;
            

            try {
                //var res = await client.GetAsync(final_url);
                var res = client.GetAsync(final_url).GetAwaiter().GetResult();
                if (res.StatusCode == HttpStatusCode.NotFound || res.StatusCode == HttpStatusCode.ServiceUnavailable)
                    return new List<CountriesSummaryClass>();
                try {
                    var response = await client.GetStringAsync(final_url); //long string
                    Console.WriteLine(final_url);
                    return JsonConvert.DeserializeObject<List<CountriesSummaryClass>>(response);
                } catch (Exception e) {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("ERROR: GetCountriesCovid not working");
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("ERROR: GetCountriesCovid not working");
                return null;
            }

            
        }


        public async Task<List<CountriesSummaryClass>> GetOneCountry(string country)
        {
            Console.WriteLine(yesterdaydate);
            Console.WriteLine(todaydate);

            var final_url = url_country + country + yesterdaydate + todaydate;

            

            try { 
                var res = await client.GetAsync(final_url);
                if (res.StatusCode == HttpStatusCode.NotFound)
                    return new List<CountriesSummaryClass>();
                try
                {
                    var response = await client.GetStringAsync(final_url); //long string
                    Console.WriteLine(final_url);
                    return JsonConvert.DeserializeObject<List<CountriesSummaryClass>>(response);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("ERROR: GetCountriesCovid not working");
                    return null;
                }
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("ERROR: GetCountriesCovid not working");
                return null;
            }


            
        }

        public async Task<List<CountriesSummaryClass>> searchForCountries(string country)
        {
            var url_final = url_country + country + yesterdaydate + todaydate;

            Console.WriteLine(url_final);

            var res = await client.GetAsync(url_final);
            if (res.StatusCode == HttpStatusCode.NotFound)
                return new List<CountriesSummaryClass>();
            try
            {
                var response = await client.GetStringAsync(url_final);
                Console.WriteLine(url_final);
                return JsonConvert.DeserializeObject<List<CountriesSummaryClass>>(response);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("ERROR: searchForCountries not working");
                return null;
            }
        }



        //public void GetCountries()
        //{
        //    DataSet dataSet = JsonConvert.DeserializeObject<DataSet>(url_summary);

        //    DataTable dataTable = dataSet.Tables["Country"];

        //    Console.WriteLine(dataTable.Rows.Count);
        //    // 2

        //    foreach (DataRow row in dataTable.Rows)
        //    {
        //        Console.WriteLine(row["Country"] + " - " + row["TotalConfirmed"]);
        //    }

        //}



        //public void PostOneCar()
        //{
        //    var car = new CovidSummaryClass();
        //    car.CarModel = "Tesla";
        //    car.carmodel2 = "Tesla";
        //    car.year = 2021;
        //    car.id = 22;

        //    var content = JsonConvert.SerializeObject(car);
        //    client.PostAsync(url, new StringContent(content));
        //}

        //public async Task<List<Stock>> searchForStock(string key)
        //{
        //    var url = yahoo_url1 + key + yahoo_url2;
        //    var response = await client.GetAsync(url);
        //    if (response.StatusCode == HttpStatusCode.NotFound)
        //        return new List<Stock>();


        //    var stringResponse = await response.Content.ReadAsStringAsync();
        //    var dic = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, object>>>(stringResponse);
        //    var array = dic.ElementAt(0).Value.ElementAt(1).Value;
        //    return JsonConvert.DeserializeObject<List<Stock>>(array.ToString());
        //}


        //public async Task<List<Stock>> searchForStock(string key)
        //{
        //    var url = yahoo_url1 + key + yahoo_url2;
        //    var response1 = await client.GetAsync(url);

        //    return list;
        //}


    }
}
