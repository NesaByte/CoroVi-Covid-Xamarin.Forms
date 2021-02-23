using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;

namespace CoroVi
{
    [DesignTimeVisible(false)]
    public partial class SelfcarePage : ContentPage
    {
        public static DBManager dbModel2 = new DBManager();
        public static ObservableCollection<Assessment> allAssesments;

        public SelfcarePage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

        }

        protected async override void OnAppearing()
        {

            allAssesments = await dbModel2.CreateTable();
            base.OnAppearing();

        }

        public async void startSelfAssessment(object sender, EventArgs e) {

            Assessment newAssessment = await AssessmentManager.InputBox(this.Navigation, null);
            if (newAssessment != null)
            {
                //allAssesmentTable.ItemsSource = null;
                allAssesments.Add(newAssessment);
                //allAssesmentTable.ItemsSource = allAssesments;
                dbModel2.insertNewToDo(newAssessment);

                if (newAssessment.bq1 || newAssessment.bq2 || newAssessment.bq3 || newAssessment.bq4 || newAssessment.bq5 || newAssessment.bq6 || newAssessment.bq7 || newAssessment.bq8 || newAssessment.bq9 || newAssessment.bq10 || newAssessment.bq11 || newAssessment.bq12)
                {
                    await DisplayAlert("Be Warned!", "You might be COVID-19 positive, we advice you to take the swab test", "OK");

                }
                else { 
                    await DisplayAlert("Good Job!", "You are COVID-free, please continue to follow COVID guidelines", "OK");
                }
            }
        } 
    } 
}

