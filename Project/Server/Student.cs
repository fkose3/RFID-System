using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    public class Student
    {
        private int student_num;
        private string student_card_num;
        private string student_name, student_surn;


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
    }
}
