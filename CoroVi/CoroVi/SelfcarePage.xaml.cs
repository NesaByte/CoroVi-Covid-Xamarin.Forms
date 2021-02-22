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
            //allAssesmentTable.ItemsSource = allAssesments;
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
                await DisplayAlert("Success", "Thank you for completing your assessment today, checkout your AccountPage", "OK");
            }
        } 
        }

        /*public void deleteFromDB(object sender, EventArgs e)
        {
            var toDelete = ((sender as MenuItem).CommandParameter as Assessment);
            allAssesments.Remove(toDelete);
            dbModel.deleteTask(toDelete);
        }*/

        /*public async void updateDB(object sender, EventArgs e)
        {


            var toUpdate = allAssesmentTable.SelectedItem as Assessment;
            var updatedTask = await TaskManager.InputBox(this.Navigation, Assessment);
            if (updatedTask != null)
            {
                dbModel.updateTask(updatedTask);
            }
        }*/ 
    }

