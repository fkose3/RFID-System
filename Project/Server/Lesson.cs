using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    public class Lesson
    {
        private int lesson_id, teacher_id;
        private string lesson_name, teacher_name;

        public int LessonID
        {
            get { return lesson_id; }
            set { lesson_id = value; }
        }

        public int TeacherID
        {
            get { return teacher_id; }
            set { teacher_id = value; }
        }

        public string LessonName
        {
            get { return lesson_name; }
            set { lesson_name = value; }
        }

        public string TeacherName
        {
            get { return teacher_name; }
            set { teacher_name = value; }
        }

    }
}
