using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Client
{
    public class Packet
    {
        public Thread Channel;

        cMainForm m_pMain;

        int Port = 15002;

        public Packet( cMainForm pMain = null)
        {
            m_pMain = pMain;
            Port = m_pMain.soket;
            Channel = new Thread(new ThreadStart(Parsing));
            Channel.Start();
            Channel.Priority = ThreadPriority.Highest;

        }

        private void Parsing()
        {
            TcpListener PortReader = new TcpListener(Port);
            byte[] read_Data = new byte[80000];

            while (true)
            {
                read_Data = new byte[80000];
                int run = 0;
            rerun:
                run++;
            if (run > 10) return;
                try
                {
                    PortReader.Start();

                    Socket soc = PortReader.AcceptSocket();
                    soc.Receive(read_Data, read_Data.Length, 0);
                    m_pMain.Parsing(read_Data);
                    PortReader.Stop();
                }
                catch
                {
                    PortReader.Stop();
                    goto rerun;
                }
            }
        }

        public void Send_Packet( byte[] pData, Socket soc )
        {
            try
            {
                soc.Send(pData, pData.Length, 0);
            }
            catch
            {
                
            }
        }
    }
}
