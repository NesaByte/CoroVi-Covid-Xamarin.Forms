using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CoroVi 
{
    public class AssessmentManager
    {
        public ObservableCollection<Assessment> getAssessments()
        {
            var assessment = new ObservableCollection<Assessment>();
            return assessment;
        }

        public static Task<Assessment> InputBox(INavigation navigation, Assessment assessment)
        {
            if (assessment == null)
            {
                assessment = new Assessment();
            }
            //wait in this proc, until user did his input 
            var tcs = new TaskCompletionSource<Assessment>();



        Grid grid = new Grid
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Padding = new Thickness(5, 15, 5, 5),
                RowDefinitions =
                {
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = GridLength.Auto },
                    new ColumnDefinition { Width = GridLength.Auto },
                    new ColumnDefinition { Width = GridLength.Auto },
                }
            };

            var q1_switch = new Switch() { IsToggled = assessment.bq1 };
            grid.Children.Add(q1_switch, 0, 0);

            var q2_switch = new Switch() { IsToggled = assessment.bq2 };
            grid.Children.Add(q2_switch, 0, 1);

            var q3_switch = new Switch() { IsToggled = assessment.bq3 };
            grid.Children.Add(q3_switch, 0, 2);

            var q4_switch = new Switch() { IsToggled = assessment.bq4 };
            grid.Children.Add(q4_switch, 0, 3);

            var q5_switch = new Switch() { IsToggled = assessment.bq5 };
            grid.Children.Add(q5_switch, 0, 4);

            var q6_switch = new Switch() { IsToggled = assessment.bq6 };
            grid.Children.Add(q6_switch, 0, 5);

            var q7_switch = new Switch() { IsToggled = assessment.bq7 };
            grid.Children.Add(q7_switch, 0, 6);

            var q8_switch = new Switch() { IsToggled = assessment.bq8 };
            grid.Children.Add(q8_switch, 0, 7);

            var q9_switch = new Switch() { IsToggled = assessment.bq9 };
            grid.Children.Add(q9_switch, 0, 8);

            var q10_switch = new Switch() { IsToggled = assessment.bq10 };
            grid.Children.Add(q10_switch, 0, 9);

            var q11_switch = new Switch() { IsToggled = assessment.bq11 };
            grid.Children.Add(q11_switch, 0, 10);

            var q12_switch = new Switch() { IsToggled = assessment.bq12 };
            grid.Children.Add(q12_switch, 0, 11);


            //Question 1 : Fever and/or chills
            Label q1_title = new Label
            {
                Text = "Fever and/or chills",
                FontAttributes =FontAttributes.Bold,
                FontSize= Device.GetNamedSize(NamedSize.Large, typeof(Label)), 
            };
            Label q1_desc = new Label { Text = "Temperature of 37.8 degrees Celsius/100 degrees Fahrenheit or higher", Margin = new Thickness(-1, -7, -1, -1), };
            StackLayout q1_sl = new StackLayout { Children = { q1_title, q1_desc }, };
            Grid.SetColumnSpan(q1_sl, 2);
            grid.Children.Add(q1_sl, 1, 0);

            //Question 2 : Cough or barking cough
            Label q2_title = new Label
            {
                Text = "Cough or barking cough",
                FontAttributes = FontAttributes.Bold,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
            };
            Label q2_desc = new Label { Text = "Continuous, more than usual, making a whistling noise when breathing", Margin = new Thickness(-1, -7, -1, -1), };
            StackLayout q2_sl = new StackLayout { Children = { q2_title, q2_desc }, };
            Grid.SetColumnSpan(q2_sl, 2);
            grid.Children.Add(q2_sl, 1, 1);

            //Question 3 : Shortness of breath
            Label q3_title = new Label
            {
                Text = "Shortness of breath",
                FontAttributes = FontAttributes.Bold,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
            };
            Label q3_desc = new Label { Text = "Out of breath, unable to breathe deeply", Margin = new Thickness(-1, -7, -1, -1), };
            StackLayout q3_sl = new StackLayout { Children = { q3_title, q3_desc }, };
            Grid.SetColumnSpan(q3_sl, 2);
            grid.Children.Add(q3_sl, 1, 2);

            //Question 4 : Sore throat
            Label q4_title = new Label
            {
                Text = "Sore throat",
                FontAttributes = FontAttributes.Bold,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
            };
            Label q4_desc = new Label { Text = "Not related to seasonal allergies, acid reflux, or other known causes or conditions you already have", Margin = new Thickness(-1, -7, -1, -1), };
            StackLayout q4_sl = new StackLayout { Children = { q4_title, q4_desc }, };
            Grid.SetColumnSpan(q4_sl, 2);
            grid.Children.Add(q4_sl, 1, 3);

            //Question 5 : Difficulty swallowing
            Label q5_title = new Label
            {
                Text = "Difficulty swallowing",
                FontAttributes = FontAttributes.Bold,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
            };
            Label q5_desc = new Label { Text = "Painful swallowing (not related to other known causes or conditions you already have)", Margin = new Thickness(-1, -7, -1, -1), };
            StackLayout q5_sl = new StackLayout { Children = { q5_title, q5_desc }, };
            Grid.SetColumnSpan(q5_sl, 2);
            grid.Children.Add(q5_sl, 1, 4);

            //Question 6 : Runny or stuffy/congested nose
            Label q6_title = new Label
            {
                Text = "Runny or stuffy/congested nose",
                FontAttributes = FontAttributes.Bold,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
            };
            Label q6_desc = new Label { Text = "Not related to seasonal allergies, being outside in cold weather, or other known causes or conditions you already have", Margin = new Thickness(-1, -7, -1, -1), };
            StackLayout q6_sl = new StackLayout { Children = { q6_title, q6_desc }, };
            Grid.SetColumnSpan(q6_sl, 2);
            grid.Children.Add(q6_sl, 1, 5);

            //Question 7 : Decrease or loss of taste or smell
            Label q7_title = new Label
            {
                Text = "Decrease or loss of taste or smell",
                FontAttributes = FontAttributes.Bold,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
            };
            Label q7_desc = new Label { Text = "Not related to seasonal allergies, neurological disorders, or other known causes or conditions you already have", Margin = new Thickness(-1, -7, -1, -1), };
            StackLayout q7_sl = new StackLayout { Children = { q7_title, q7_desc }, };
            Grid.SetColumnSpan(q7_sl, 2);
            grid.Children.Add(q7_sl, 1, 6);

            //Question 8 : Pink eye
            Label q8_title = new Label
            {
                Text = "Pink eye",
                FontAttributes = FontAttributes.Bold,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
            };
            Label q8_desc = new Label { Text = "Conjunctivitis (not related to reoccurring styes or other known causes or conditions you already have)", Margin = new Thickness(-1, -7, -1, -1), };
            StackLayout q8_sl = new StackLayout { Children = { q8_title, q8_desc }, };
            Grid.SetColumnSpan(q8_sl, 2);
            grid.Children.Add(q8_sl, 1, 7);

            //Question  9 : Headache
            Label q9_title = new Label
            {
                Text = "Headache",
                FontAttributes = FontAttributes.Bold,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
            };
            Label q9_desc = new Label { Text = "Unusual, long-lasting (not related to tension-type headaches, chronic migraines, or other known causes or conditions you already have)", Margin = new Thickness(-1, -7, -1, -1), };
            StackLayout q9_sl = new StackLayout { Children = { q9_title, q9_desc }, };
            Grid.SetColumnSpan(q9_sl, 2);
            grid.Children.Add(q9_sl, 1, 8);

            //Question  10 :  Digestive issues like nausea/vomiting, diarrhea, stomach pain
            Label q10_title = new Label
            {
                Text = "Digestive issues like nausea/vomiting, diarrhea, stomach pain",
                FontAttributes = FontAttributes.Bold,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
            };
            Label q10_desc = new Label { Text = "Not related to irritable bowel syndrome, menstrual cramps, or other known causes or conditions you already have", Margin = new Thickness(-1, -7, -1, -1), };
            StackLayout q10_sl = new StackLayout { Children = { q10_title, q10_desc }, };
            Grid.SetColumnSpan(q10_sl, 2);
            grid.Children.Add(q10_sl, 1, 9);

            //Question  11 : Muscle aches
            Label q11_title = new Label
            {
                Text = "Muscle aches",
                FontAttributes = FontAttributes.Bold,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
            };
            Label q11_desc = new Label { Text = "Unusual, long-lasting (not related to a sudden injury, fibromyalgia, or other known causes or conditions you already have)", Margin = new Thickness(-1, -7, -1, -1), };
            StackLayout q11_sl = new StackLayout { Children = { q11_title, q11_desc }, };
            Grid.SetColumnSpan(q11_sl, 2);
            grid.Children.Add(q11_sl, 1, 10);

            //Question  12 : Extreme tiredness
            Label q12_title = new Label
            {
                Text = "Extreme tiredness",
                FontAttributes = FontAttributes.Bold,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
            };
            Label q12_desc = new Label { Text = "Unusual, fatigue, lack of energy (not related to depression, insomnia, thyroid dysfunction, or other known causes or conditions you already have)", Margin = new Thickness(-1, -7, -1, -1), };
            StackLayout q12_sl = new StackLayout { Children = { q12_title, q12_desc }, };
            Grid.SetColumnSpan(q12_sl, 2);
            grid.Children.Add(q12_sl, 1, 11);


            //Submission Button
            Button submit_button = new Button
            {
                Text = "Submit Form",
                BackgroundColor = Color.FromHex("#68CAD7"),
                Margin = new Thickness(60, 10, 80, 10),
            };

            grid.Children.Add(submit_button, 1, 12);



            submit_button.Clicked += async (s, e) =>
            {
                // close page
                assessment.dateTaken = DateTime.Now;
                assessment.bq1 = q1_switch.IsToggled;
                assessment.bq2 = q2_switch.IsToggled;
                assessment.bq3 = q3_switch.IsToggled;
                assessment.bq4 = q4_switch.IsToggled;
                assessment.bq5 = q5_switch.IsToggled;
                assessment.bq6 = q6_switch.IsToggled;
                assessment.bq7 = q7_switch.IsToggled;
                assessment.bq8 = q8_switch.IsToggled;
                assessment.bq9 = q9_switch.IsToggled;
                assessment.bq10 = q10_switch.IsToggled;
                assessment.bq11 = q11_switch.IsToggled;
                assessment.bq12 = q12_switch.IsToggled;

                await navigation.PopModalAsync();
                // pass result
                tcs.SetResult(assessment);
            };

            Button cancel_button = new Button
            {
                Text = "Cancel",
                BackgroundColor = Color.FromHex("#FB9C80"),
                Margin = new Thickness(90, 10, 110, 10)
            };

            grid.Children.Add(cancel_button, 1, 13);

            cancel_button.Clicked += async (s, e) =>
            {
                // close page
                await navigation.PopModalAsync();
                // pass empty result
                tcs.SetResult(null);
            }; 

            // "this" refers to a Page object

            var scroll = new ScrollView
            {
                Content = grid
            };


            var lbl_title = new Label
            {
                Text = "COVID-19 self-assessment",
                FontAttributes = FontAttributes.Bold,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.CenterAndExpand,

            };

            var layout_title = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(5, 5, 5, 5),
                BackgroundColor = Color.FromHex("#00AEC7"),
                Children = { lbl_title },

            };

            //Main StackLayout that holds everyhing
            var layout = new StackLayout
            {
                Padding = new Thickness(5, 5, 5, 5),
                Children = { layout_title, scroll },

            };

            // create and show page
            var page = new ContentPage();
            page.Content = layout;
            navigation.PushModalAsync(page);

            return tcs.Task;
        }
    }
}
