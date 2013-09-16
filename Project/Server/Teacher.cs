using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    public class Teacher
    {
        private int teacher_id;
        private string teacher_name, teacher_surn;

       
        public int TeacherID
        {
            get { return teacher_id; }
            set { teacher_id = value; }
        }


        public string TeacherName
        {
            get { return teacher_name; }
            set { teacher_name = value; }
        }

        public string TeacherSurn
        {
            get { return teacher_name; }
            set { teacher_name = value; }
        }

        public string TeacherFullName
        {
            get { return teacher_name+" "+teacher_surn; }
        }
    }
}
