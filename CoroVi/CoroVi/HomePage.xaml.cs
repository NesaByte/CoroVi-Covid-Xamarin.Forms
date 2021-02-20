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
        private string url_worldTotal = "https://api.covid19api.com/world/total";

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

            // XAML Sets and Displays the Global Data
            TotalConfirmed.Text = cs.TotalConfirmed.ToString();
            TotalDeaths.Text = cs.TotalDeaths.ToString();
            TotalRecovered.Text = cs.TotalRecovered.ToString();

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

                //
                
                //var url_country = "https://api.covid19api.com/country/";
                //var today_date = "&to=" + DateTime.Now.ToString("yyyy-MM-dd") + "T00:00:00Z";
                //var yesterday_date = "?from=" + DateTime.Today.AddDays(-1).ToString("yyyy-MM-dd") + "T00:00:00Z";

                //var url_find = url_country + countryName.Text + yesterday_date + today_date;
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