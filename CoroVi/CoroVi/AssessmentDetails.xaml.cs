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

    public partial class AssessmentDetails : ContentPage
    {

        public string bad = "#FB9C80";
        public string good = "#00AEC7";

        public Color BGColor1 { get; set; } = Color.FromHex("#00AEC7");
        public Color BGColor2 { get; set; } = Color.FromHex("#00AEC7");
        public Color BGColor3 { get; set; } = Color.FromHex("#00AEC7");
        public Color BGColor4 { get; set; } = Color.FromHex("#00AEC7");
        public Color BGColor5 { get; set; } = Color.FromHex("#00AEC7");
        public Color BGColor6 { get; set; } = Color.FromHex("#00AEC7");
        public Color BGColor7 { get; set; } = Color.FromHex("#00AEC7");
        public Color BGColor8 { get; set; } = Color.FromHex("#00AEC7");
        public Color BGColor9 { get; set; } = Color.FromHex("#00AEC7");
        public Color BGColor10 { get; set; } = Color.FromHex("#00AEC7");
        public Color BGColor11 { get; set; } = Color.FromHex("#00AEC7");
        public Color BGColor12 { get; set; } = Color.FromHex("#00AEC7");

        
        public AssessmentDetails(Assessment a)
        {
            InitializeComponent();

            x_sb1.Text = a.sb1.ToString();
            x_sb2.Text = a.sb2.ToString();
            x_sb3.Text = a.sb3.ToString();
            x_sb4.Text = a.sb4.ToString();
            x_sb5.Text = a.sb5.ToString();
            x_sb6.Text = a.sb6.ToString();
            x_sb7.Text = a.sb7.ToString();
            x_sb8.Text = a.sb8.ToString();
            x_sb9.Text = a.sb9.ToString();
            x_sb10.Text = a.sb10.ToString();
            x_sb11.Text = a.sb11.ToString();
            x_sb12.Text = a.sb12.ToString();

            if (a.bq1) { BGColor1 = Color.FromHex("#FB9C80"); }
            if (a.bq2) { BGColor2 = Color.FromHex("#FB9C80"); }
            if (a.bq3) { BGColor3 = Color.FromHex("#FB9C80"); }
            if (a.bq4) { BGColor4 = Color.FromHex("#FB9C80"); }
            if (a.bq5) { BGColor5 = Color.FromHex("#FB9C80"); }
            if (a.bq6) { BGColor6 = Color.FromHex("#FB9C80"); }
            if (a.bq7) { BGColor7 = Color.FromHex("#FB9C80"); }
            if (a.bq8) { BGColor8 = Color.FromHex("#FB9C80"); }
            if (a.bq9) { BGColor9 = Color.FromHex("#FB9C80"); }
            if (a.bq10) { BGColor10 = Color.FromHex("#FB9C80"); } 
            if (a.bq11) { BGColor11 = Color.FromHex("#FB9C80"); }
            if (a.bq12) { BGColor12 = Color.FromHex("#FB9C80"); }

            BindingContext = this;

        }
    }
}