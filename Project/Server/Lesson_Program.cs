using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    public class Lesson_Program
    {
        private int lesson_id, teacher_id;
        private string lesson_name, teacher_name;
        private string Date;
        private int student_grade;
        private string branch;

        public int Grade
        {
            get { return student_grade; }
            set { student_grade = value; }
        }

        public int LessonID
        {
            set { lesson_id = value; }
            get { return lesson_id; }
        }

        public int TeacherID
        {
            set { teacher_id = value; }
            get { return teacher_id; }
        }
        
        public string LessonName
        {
            set { lesson_name = value; }
            get { return lesson_name; }
        }

        public string TeacherNane
        {
            set { teacher_name = value; }
            get { return teacher_name; }
        }

        public string Branch
        {
            get { return branch; }
            set { branch = value; }
        }

        public string isDate
        {
            get { return Date; }
            set { Date = value; }
        }
    }
}
