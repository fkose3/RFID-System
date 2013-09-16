using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    public class Absenteeism
    {
        private byte day, mount, year;
        private short lessonid;

        /**
         * for the day and the course the 
         * student absenteeism
         */

        public byte isDay
        {
            get { return day; }
            set { day = value; }
        }

        public byte isMount
        {
            get { return mount; }
            set { mount = value; }
        }

        public byte isYear
        {
            get { return year; }
            set { year = value; }
        }

        public short isLesson
        {
            get { return lessonid; }
            set { lessonid = value; }
        }
    }
}
