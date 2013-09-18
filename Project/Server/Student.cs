using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    public class Student
    {
        private int student_num;
        private string student_card_num , adress , birth_day, savedate;
        private string student_name, student_surn;
        private string []tel = new string[2];


        public int StudentNum
        {
            get { return student_num; }
            set { student_num = value; }
        }

        public string StudentCartCode
        {
            get { return student_card_num; }
            set { student_card_num = value; }
        }

        public string StudentName
        {
            get { return student_name; }
            set { student_name = value; }
        }

        public string StudentSurn
        {
            get { return student_surn; }
            set { student_surn = value; }
        }

        public string StudentFullName
        {
            get { return student_name + " " + student_surn; }   
        }

        public string Tel1
        {
            get { return tel[0]; }
            set { tel[0] = value; }
        }

        public string Tel2
        {
            get { return tel[1]; }
            set { tel[1] = value; }
        }

        public string Adress
        {
            get { return adress; }
            set { adress = value; }
        }

        public string BirthDay
        {
            get { return birth_day; }
            set { birth_day = value; }
        }

        public string SaveDate
        {
            get { return savedate; }
            set { savedate = value; }
        }

    }
}
