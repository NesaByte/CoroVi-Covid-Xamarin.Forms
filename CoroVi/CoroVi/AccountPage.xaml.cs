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

            Assessment a = (Assessment)((ListView)sender).SelectedItem;

            await Navigation.PushAsync(new AssessmentDetails(a));
            ((ListView)sender).SelectedItem = null;
        }
        async public void Details_Clicked(object sender, EventArgs e)
        {
            var a = ((sender as Button).CommandParameter as Assessment);
            await Navigation.PushAsync(new AssessmentDetails(a));
        }

        public void deleteFromDB(object sender, EventArgs e)
        {
            var toDelete = ((sender as Button).CommandParameter as Assessment);
            SelfcarePage.allAssesments.Remove(toDelete);
            SelfcarePage.dbModel2.deleteTask(toDelete);
        }

        public async void updateDB(object sender, EventArgs e)
        {
            var toUpdate = ((sender as Button).CommandParameter as Assessment);
            var updatedTask = await AssessmentManager.InputBox(this.Navigation, toUpdate);
            if (updatedTask != null)
            {
                SelfcarePage.dbModel2.updateTask(updatedTask);
            }
        }
    }
}