using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    class StudentAffairs
    {
        private Packet pkt;

        public StudentAffairs(Packet pkt)
        {
            byte command = pkt.GetByte();

            switch (command)
            {

            }
        }
    }
}
