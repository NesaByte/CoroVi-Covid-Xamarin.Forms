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


namespace CoroVi
{
    public partial class HomePage : ContentPage
    {
        public ObservableCollection<CountriesSummaryClass> summary_list;
        public SummaryNetworkingManager summaryNetworkingManager = new SummaryNetworkingManager();

        //url for global values
        private string url_worldTotal = "https://api.covid19api.com/world/total";

        //url for list of country names
        private string url_dayone_country = "https://api.covid19api.com/dayone/country/south-africa";


        private HttpClient client = new HttpClient();

        public HomePage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            // Displays countries
            summaryList.ItemsSource = null;

            var list = await summaryNetworkingManager.GetCountriesCovid();
            summary_list = new ObservableCollection<CountriesSummaryClass>(list);

            summaryList.ItemsSource = summary_list;

            // Quick console logs
            var res_worldTotal = await client.GetStringAsync(url_worldTotal);
            CovidSummaryClass cs = JsonConvert.DeserializeObject<CovidSummaryClass>(res_worldTotal);
            
            Console.WriteLine(cs.TotalConfirmed);
            Console.WriteLine(cs.TotalDeaths);
            Console.WriteLine(cs.TotalRecovered);


            // Displays the Global Data
            TotalConfirmed.Text = cs.TotalConfirmed.ToString();
            TotalDeaths.Text = cs.TotalDeaths.ToString();
            TotalRecovered.Text = cs.TotalRecovered.ToString();




            //countries


            base.OnAppearing();

        }


        /*public async void GetTotalCases()
        {
            // create new http client to handle the request
            HttpClient client = new HttpClient();

            // send GET request to return totals for all countries and store response in TotalData object

        var totals_json = await client.GetStringAsync("https://corona.lmao.ninja/v2/all");

            // deserialize the json response to a TotalData object 
            TotalData totals = JsonConvert.DeserializeObject<TotalData>(totals_json);

            // API returns an 'updated' field with the UNIX TIME of last update received 
            // create a new DateTime object to represent 1/1/1970
            DateTime lastUpdate = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);

            // add the unix time elapsed since 1/1/1970 and convert to current local time
            lastUpdate = lastUpdate.AddMilliseconds(totals.updated).ToLocalTime();

            // set the time label to display current local time
            updatelabel.Text = $"Last Update: {lastUpdate.ToString()}";

            // set total data display labels with COVID-19 data returned from API call
            caseslabel.Text = $"Total # of Cases: {totals.cases.ToString()}";
            todaycaseslabel.Text = $"Total # of Cases Today: {totals.todayCases.ToString()}";
            deathslabel.Text = $"Total # of Deaths: {totals.deaths.ToString()}";
            todaydeathslabel.Text = $"Total # of Deaths Today: {totals.todayDeaths.ToString()}";
            recoveredlabel.Text = $"Total # of Recovered: {totals.recovered.ToString()}";
            activelabel.Text = $"Total # of Active: {totals.active.ToString()}";
            criticallabel.Text = $"Total # of Critical: {totals.critical.ToString()}";
            countriesaffectedlabel.Text = $"Total # of Countries Affected: {totals.affectedCountries.ToString()}";

            // make the view visible
            totalscroll.IsVisible = true;
        }*/




        async void Btn_country_clicked(System.Object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(countryName.Text))
            {
                await DisplayAlert("Error ", "You have to type in a country name", "OK");
            }
            else
            {

                Lbl_country.Text = countryName.Text;

            }
        }
    }
    
}