using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CoroVi
{
    public class Assessment : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public DateTime dateTaken { set; get; }

        public bool bq1 { set; get; }
        public bool bq2 { set; get; }
        public bool bq3 { set; get; }
        public bool bq4 { set; get; }
        public bool bq5 { set; get; }
        public bool bq6 { set; get; }
        public bool bq7 { set; get; }
        public bool bq8 { set; get; }
        public bool bq9 { set; get; }
        public bool bq10 { set; get; }
        public bool bq11 { set; get; }
        public bool bq12 { set; get; }


        public string sb1 {
            get {
                if (bq1) return "You have fever and/or chills";
                else return "You have NO fever and/or chills";
            }
            set { }
        }

        public string sb2
        {
            get
            {
                if (bq2) return "You have Cough or barking cough";
                else return "You have NO Cough or barking cough";
            }
            set { }
        }
        public string sb3
        {
            get
            {
                if (bq3) return "You have Shortness of breath";
                else return "You have NO Shortness of breath";
            }
            set { }
        }

        public string sb4
        {
            get
            {
                if (bq4) return "You have Sore throat";
                else return "You have NO Sore throat";
            }
            set { }
        }

        public string sb5
        {
            get
            {
                if (bq5) return "You have Difficulty swallowing";
                else return "You have NO Difficulty swallowing";
            }
            set { }
        }
        public string sb6
        {
            get
            {
                if (bq6) return "You have Runny or stuffy/congested nose";
                else return "You have NO Runny or stuffy/congested nose";
            }
            set { }
        }

        public string sb7
        {
            get
            {
                if (bq7) return "You have Decreased or lost your taste or smell";
                else return "You have NO Decrease or loss of taste or smell";
            }
            set { }
        }
        public string sb8
        {
            get
            {
                if (bq8) return "You have Pink eye";
                else return "You have NO Pink eye";
            }
            set { }
        }

        public string sb9
        {
            get
            {
                if (bq9) return "You have a Headache";
                else return "You have NO a Headache";
            }
            set { }
        }
        public string sb10
        {
            get
            {
                if (bq10) return "You have Digestive issues";
                else return "You have NO Digestive issues";
            }
            set { }
        }

        public string sb11
        {
            get
            {
                if (bq11) return "You have Muscle aches";
                else return "You have NO Muscle aches";
            }
            set { }
        }
        public string sb12
        {
            get
            {
                if (bq12) return "You have Extreme tiredness";
                else return "You have NO Extreme tiredness";
            }
            set { }
        } 

    }
}
