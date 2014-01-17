using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ogrenci_Isleri
{
    public class RFSocket
    {
        Thread Channel;
        OgrenciIsleri pMain;

        const int Port = 15000;

        public RFSocket(OgrenciIsleri main)
        {
            pMain = main;

            Channel = new Thread(new ThreadStart(Parsing));
            Channel.Start();
            Channel.Priority = ThreadPriority.Highest;

        }

        private void Parsing()
        {
            TcpListener PortReader = new TcpListener(Port);
            byte[] read_Data = new byte[255];

            while (true)
            {
                read_Data = new byte[50000];

                PortReader.Start();

                Socket soc = PortReader.AcceptSocket();
                soc.Receive(read_Data, read_Data.Length, 0);
                Packet pkt = new Packet(read_Data, soc);

                pMain.Parsing(pkt);


                PortReader.Stop();

            }
        }

    }
}
