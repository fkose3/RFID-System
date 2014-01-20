using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    public class StudentAffairs
    {
        private Packet pkt;
        private string Uid;
        public int m_Sid;

        public StudentAffairs(Packet pkt)
        {
            byte command = pkt.GetByte();

            switch (command)
            {

            }
        }

        public StudentAffairs(string Uid, int m_AffairsSid)
        {
            // TODO: Complete member initialization
            this.Uid = Uid;
            this.m_Sid = m_AffairsSid;
        }
    }
}
