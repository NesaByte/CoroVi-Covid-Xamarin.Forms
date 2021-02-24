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

        private string url_allCountry = "https://corona.lmao.ninja/v3/covid-19/countries";


        private HttpClient client = new HttpClient();
         
        public SummaryNetworkingManager() { }
         
        public async Task<List<CountriesClass>> GetCountriesCovid()
        {
            try {
                HttpResponseMessage res = await client.GetAsync(url_allCountry);

                if (res.StatusCode == HttpStatusCode.NotFound || res.StatusCode == HttpStatusCode.ServiceUnavailable)
                    return new List<CountriesClass>();
                try {
                    var response = await client.GetStringAsync(url_allCountry); //long string
                    return JsonConvert.DeserializeObject<List<CountriesClass>>(response);
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
    }
}
