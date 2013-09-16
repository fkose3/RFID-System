using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    public static class Define
    {
        public const int CLIENT_PORT = 15002;
        public const int CHECK_ONLINE_DURATION = 60;
        public const byte WIZ_TRUE = 0x01;
        public const byte WIZ_FALSE = 0x00;

        /* Packet Define        *
         * Creator By KOSE      *
         * Powered MBS System   *
         */

        public const byte WIZ_LOGIN = 0x00;
        public const byte WIZ_SEND_SID = 0x01;
        public const byte WIZ_CLIENT_PROCESS = 0x02;
        

        /* Packet Define   *
         * Client Packet   *
         */

        public const byte WIZ_CLIENT_MESSAGE = 0xA0;
        public const byte WIZ_CLIENT_CLOSE = 0xA1;
        public const byte WIZ_CLIENT_ONLINE = 0xA2;
        public const byte WIZ_STUDENT_PROCESS = 0xA3;


        /** Packet Define 
         * Student Process Packet 
         */

        public const byte WIZ_STUDENT_ABSENTEEISM = 0x00;
        public const byte WIZ_STUDENT_LESSON_LIST = 0x01;
        

        public static float TimeGet()
        {
            float time = 0;

            time += (DateTime.Now.Hour * 60 )* 60; // hour in secont
            time += DateTime.Now.Minute * 60; // minute in secont
            time += DateTime.Now.Second;

            return time;
        }
    }
}
