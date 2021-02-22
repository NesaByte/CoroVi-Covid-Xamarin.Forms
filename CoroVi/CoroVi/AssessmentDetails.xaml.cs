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

        }
    }
}