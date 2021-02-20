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
        public ObservableCollection<CountriesSummaryClass> summary_list;
        public SummaryNetworkingManager summaryNetworkingManager = new SummaryNetworkingManager();

        //url for global values
        private string url_worldTotal = "https://corona.lmao.ninja/v3/covid-19/all";

        //url for list of country names
        private string url_dayone_country = "https://api.covid19api.com/country/canada";

        private HttpClient client = new HttpClient();

        public HomePage()
        {
            InitializeComponent();
        }


        protected async override void OnAppearing()
        {
            // Displays countries
            //summaryList.ItemsSource = null;

            //var list = await summaryNetworkingManager.GetCountriesCovid();
            //summary_list = new ObservableCollection<CountriesSummaryClass>(list);

            //summaryList.ItemsSource = summary_list;

            // Quick console logs
            var res_worldTotal = await client.GetStringAsync(url_worldTotal);
            CovidAllClass cs = JsonConvert.DeserializeObject<CovidAllClass>(res_worldTotal);
            
            Console.WriteLine(cs.cases);
            Console.WriteLine(cs.deaths);
            Console.WriteLine(cs.recovered);

            // XAML Sets and Displays the Global Data
            TotalConfirmed.Text = cs.cases.ToString();
            TotalDeaths.Text = cs.deaths.ToString();
            TotalRecovered.Text = cs.recovered.ToString();

            //countries

            base.OnAppearing();
        }/**/

        void Handle_Focused(object sender, Xamarin.Forms.FocusEventArgs e)
        {
            ((Entry)sender).Text = string.Empty;
        }

        public async void Btn_country_clicked(System.Object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(countryName.Text))
            {
                await DisplayAlert("Error ", "You have to type in a country name", "OK");
            }
            else
            {
                Lbl_country.Text = countryName.Text;

                var country_url = url_dayone_country + summaryNetworkingManager.yesterdaydate + summaryNetworkingManager.todaydate;
                Console.WriteLine(country_url);

                var res = await client.GetAsync(country_url);
                
                
                if (res.StatusCode == HttpStatusCode.NotFound || res.StatusCode == HttpStatusCode.ServiceUnavailable) {
                    await DisplayAlert("Error", "Please give me a correct country name", "OK");
                    Lbl_country.Text = "";
                } else {
                    summaryList.ItemsSource = null;

                    var list = await summaryNetworkingManager.GetOneCountry(countryName.Text);
                    summary_list = new ObservableCollection<CountriesSummaryClass>(list);

                    summaryList.ItemsSource = summary_list;
                    await DisplayAlert("Good", list.ToString(), "OK");

                }
            }
        }

        /**/
    }
    
}