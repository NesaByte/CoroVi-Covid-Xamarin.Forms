using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net.Http;
using System.Net;

namespace CoroVi
{
    public partial class HomePage : ContentPage
    {
        public ObservableCollection<CountriesClass> summary_list;
        public SummaryNetworkingManager summaryNetworkingManager = new SummaryNetworkingManager();

        //url for global values
        private string url_worldTotal = "https://corona.lmao.ninja/v3/covid-19/all";

        //url for list of country names
        private string url_country = "https://corona.lmao.ninja/v3/covid-19/countries/";

        private HttpClient client = new HttpClient();

        public HomePage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        protected async override void OnAppearing()
        {
            // Displays countries
            allCountries.ItemsSource = null;

            var list = await summaryNetworkingManager.GetCountriesCovid();
            summary_list = new ObservableCollection<CountriesClass>(list);

            allCountries.ItemsSource = summary_list;

            // Quick console logs
            var res_worldTotal = await client.GetStringAsync(url_worldTotal);
            CovidAllClass cs = JsonConvert.DeserializeObject<CovidAllClass>(res_worldTotal);
            
            Console.WriteLine(cs.cases);
            Console.WriteLine(cs.deaths);
            Console.WriteLine(cs.recovered);

            // XAML Sets and Displays the Global Data

            string tc = cs.cases.ToString();
            int itc = Convert.ToInt32(tc);
            TotalConfirmed.Text = itc.ToString("N0");

            string td = cs.deaths.ToString();
            int itd = Convert.ToInt32(td);
            TotalDeaths.Text = itd.ToString("N0");

            string tr = cs.recovered.ToString();
            int itr = Convert.ToInt32(tr);
            TotalRecovered.Text = itr.ToString("N0");

            string tdc = cs.todayCases.ToString();
            int itdc = Convert.ToInt32(tdc);
            TodayCases.Text = itdc.ToString("N0");

            string tdd = cs.todayDeaths.ToString();
            int itdd = Convert.ToInt32(tdd);
            TodayDeaths.Text = itdd.ToString("N0");

            string tdr = cs.todayRecovered.ToString();
            int itdr = Convert.ToInt32(tdr);
            TodayRecovered.Text = itdr.ToString("N0");
            //countries

            base.OnAppearing();
        } 

        public async void Btn_country_clicked(System.Object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(countryName.Text))
            {
                await DisplayAlert("Error ", "You have to type in a country name", "OK");
            }
            else
            {
                var url_toFind = url_country + countryName.Text;

                Console.WriteLine(url_toFind);

                var res = await client.GetAsync(url_toFind);
                
                if (res.StatusCode == HttpStatusCode.NotFound || res.StatusCode == HttpStatusCode.ServiceUnavailable || res.StatusCode == HttpStatusCode.BadGateway) {
                    country.Text = "";
                    TotalConfirmed.Text = "";
                    TotalDeaths.Text = "";
                    TotalRecovered.Text = "";
                    TodayCases.Text = "";
                    TodayDeaths.Text = "";
                    TodayRecovered.Text = "";

                    await DisplayAlert("Error", "Please give me a correct country name", "OK");
                    
                } else {
                    var res_worldTotal = await client.GetStringAsync(url_toFind);
                    CovidAllClass cs = JsonConvert.DeserializeObject<CovidAllClass>(res_worldTotal);

                    Console.WriteLine(cs.cases);
                    Console.WriteLine(cs.deaths);
                    Console.WriteLine(cs.recovered);

                    country.Text = countryName.Text;

                    // XAML Sets and Displays the Country Data
                    string tc = cs.cases.ToString();
                    int itc = Convert.ToInt32(tc);
                    TotalConfirmed.Text = itc.ToString("N0");

                    string td = cs.deaths.ToString();
                    int itd = Convert.ToInt32(td);
                    TotalDeaths.Text = itd.ToString("N0");

                    string tr = cs.recovered.ToString();
                    int itr = Convert.ToInt32(tr);
                    TotalRecovered.Text = itr.ToString("N0");

                    string tdc = cs.todayCases.ToString();
                    int itdc = Convert.ToInt32(tdc);
                    TodayCases.Text = itdc.ToString("N0");

                    string tdd = cs.todayDeaths.ToString();
                    int itdd = Convert.ToInt32(tdd);
                    TodayDeaths.Text = itdd.ToString("N0");

                    string tdr = cs.todayRecovered.ToString();
                    int itdr = Convert.ToInt32(tdr);
                    TodayRecovered.Text = itdr.ToString("N0");

                }
            }
        }

        public async void Btn_countryFind_clicked(System.Object sender, System.EventArgs e)
        {
            /*
            if (string.IsNullOrEmpty(countryName.Text))
            {
                await DisplayAlert("Error ", "You have to type in a country name", "OK");
            }
            else
            {
                var url_toFind = url_country + countryName.Text;

                Console.WriteLine(url_toFind);

                var res = await client.GetAsync(url_toFind);

                if (res.StatusCode == HttpStatusCode.NotFound || res.StatusCode == HttpStatusCode.ServiceUnavailable || res.StatusCode == HttpStatusCode.BadGateway)
                {
                    //country.Text = "";
                    //TotalConfirmed.Text = "";
                    //TotalDeaths.Text = "";
                    //TotalRecovered.Text = "";

                    await DisplayAlert("Error", "Please give me a correct country name", "OK");

                }
                else
                {
                    var res_worldTotal = await client.GetStringAsync(url_toFind);
                    CovidAllClass cs = JsonConvert.DeserializeObject<CovidAllClass>(res_worldTotal);

                    Console.WriteLine(cs.cases);
                    Console.WriteLine(cs.deaths);
                    Console.WriteLine(cs.recovered);

                    country.Text = countryName.Text;

                    // XAML Sets and Displays the Country Data
                    TotalConfirmed.Text = cs.cases.ToString();
                    TotalDeaths.Text = cs.deaths.ToString();
                    TotalRecovered.Text = cs.recovered.ToString();

                    await DisplayAlert("Error", "Please give me a correct country name", "OK");


                }
            }
            */
        }
    }
    
}