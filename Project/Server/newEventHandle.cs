using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    public static class newEventHandle
    {
        private static _SQL_Command m_Command = null;
        private static ServerDLG m_pMain = null;


        public newEventHandle(_SQL_Command comm,ServerDLG main)
        {

            m_Command = comm;
            m_pMain = main;
        }

        public static void InsertNewStudent( Student pStd )
        {
            
            int status = m_Command.InsertStudent(pStd.StudentName,pStd.StudentSurn,pStd.StudentNum,pStd.StudentCartCode,pStd.BirthDay,pStd.Tel1,pStd.Tel2,pStd.Adress);

            switch (status)
            {
                case 1: // Number Error
                    break;
                case 2: // Card Number Error
                    break;
                case 3: // Succesfully
                    break;
                default:// Not Executable
                    break;
            }

            m_pMain.m_StudentArray.Add(pStd);
        }

    }
}
