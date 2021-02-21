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
        private string url_country = "https://corona.lmao.ninja/v3/covid-19/countries/";

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
        } 

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
                

                var url_toFind = url_country + countryName.Text;

                Console.WriteLine(url_toFind);

                var res = await client.GetAsync(url_toFind);
                
                
                if (res.StatusCode == HttpStatusCode.NotFound || res.StatusCode == HttpStatusCode.ServiceUnavailable) {
                    Lbl_country.Text = "";
                    await DisplayAlert("Error", "Please give me a correct country name", "OK");
                    
                } else {
                    var res_worldTotal = await client.GetStringAsync(url_toFind);
                    CovidAllClass cs = JsonConvert.DeserializeObject<CovidAllClass>(res_worldTotal);

                    Console.WriteLine(cs.cases);
                    Console.WriteLine(cs.deaths);
                    Console.WriteLine(cs.recovered);

                    Lbl_country.Text = countryName.Text;
                    
                    // XAML Sets and Displays the Country Data
                    FindTotalConfirmed.Text = cs.cases.ToString();
                    FindTotalDeaths.Text = cs.deaths.ToString();
                    FindTotalRecovered.Text = cs.recovered.ToString();

                }
            }
        }
    }
    
}