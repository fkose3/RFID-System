using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgretimGorevlisi
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
        public const byte WIZ_ACC_LOGIN = 0x03;

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

        public const byte WIZ_LOGIN_SAffairs = 0xAA;
        public const byte WIZ_LOGIN_TLogin = 0xBB;
        public const byte WIZ_LOGIN_Client = 0xCC;

        public const byte ACCOUNT_BANNET = 255;
        public const byte ACCOUNT_MASTER = 0;
        public const byte ACCOUNT_C_USER = 1;

        public const byte LOGIN_INCORRENT = 3;
        public const byte LOGIN_BANNET = 2;
        public const byte LOGIN_LOGIN = 1;
        public const byte LOGIN_NOT_LOGIN = 230;

        public static float TimeGet()
        {
            float time = 0;

            time += (DateTime.Now.Hour * 60) * 60; // hour in secont
            time += DateTime.Now.Minute * 60; // minute in secont
            time += DateTime.Now.Second;

            return time;
        }

    }
}
