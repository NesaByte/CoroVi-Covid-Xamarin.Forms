using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CoroVi
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AccountPage : ContentPage
    {
        public AccountPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        protected async override void OnAppearing()
        {

            SelfcarePage.allAssesments = await SelfcarePage.dbModel2.CreateTable();
            allAssesmentTable.ItemsSource = SelfcarePage.allAssesments;
            base.OnAppearing();

        }

        async public void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) return;

            //Assessment a = e.SelectedItem as Assessment;

            Assessment a = (Assessment)((ListView)sender).SelectedItem;

            await Navigation.PushAsync(new AssessmentDetails(a));
            ((ListView)sender).SelectedItem = null;
        }
    }
}