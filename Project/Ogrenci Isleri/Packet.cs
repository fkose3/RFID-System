using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Ogrenci_Isleri
{
    public class Packet
    {
        Socket skt;
        byte[] send_byte;
        int send_index = 0;
        int get_index = 0;
        private byte p1;
        private int p2;

        public Packet(byte[] read_data, Socket skt)
        {
            this.skt = skt;
            send_byte = read_data;
            get_index = 0;
        }

        public Packet(int len)
        {
            send_index = 0;
            send_byte = new byte[len];
        }

        public Packet(byte p1, int p2 = 64)
        {
            // TODO: Complete member initialization
            send_index = 0;
            send_byte = new byte[p2];
            AddParameter(p1);
        }

        public void AddParameter(byte param)
        {
            send_byte[send_index++] = param;
        }

        public void AddParameter(Int16 param)
        {
            byte[] byt = BitConverter.GetBytes(param);

            for (int i = 0; i < byt.Length; i++)
                AddParameter(byt[i]);
        }

        public void AddParameter(Int32 param)
        {
            byte[] byt = BitConverter.GetBytes(param);

            for (int i = 0; i < byt.Length; i++)
                AddParameter(byt[i]);
        }

        public void AddParameter(Int64 param)
        {
            byte[] byt = BitConverter.GetBytes(param);

            for (int i = 0; i < byt.Length; i++)
                AddParameter(byt[i]);
        }

        public void AddParameter(string param)
        {
            byte[] txtByte = Encoding.ASCII.GetBytes(param);

            AddParameter((Int16)txtByte.Length);

            for (int i = 0; i < txtByte.Length; i++)
                AddParameter(txtByte[i]);
        }

        public byte GetByte()
        {
            return send_byte[get_index++];
        }

        public Int16 GetShort()
        {
            byte[] byt = new byte[2];
            byt[0] = GetByte();
            byt[1] = GetByte();

            return Convert.ToInt16(BitConverter.ToInt16(byt, 0));
        }

        public Int32 GetDWORD()
        {
            byte[] byt = new byte[4];
            for (int i = 0; i < byt.Length; i++)
                byt[i] = GetByte();

            return (Int32)BitConverter.ToInt32(byt, 0);
        }

        public Int64 GetInt64()
        {
            byte[] byt = new byte[8];
            for (int i = 0; i < byt.Length; i++)
                byt[i] = GetByte();

            return (Int64)BitConverter.ToInt64(byt, 0);
        }

        public string GetString()
        {
            byte[] txtByte = new byte[GetShort()];
            for (int i = 0; i < txtByte.Length; i++)
                txtByte[i] = GetByte();

            return Encoding.ASCII.GetString(txtByte);
        }

        public void Send()
        {
            try
            {
                TcpClient Client = new TcpClient("127.0.0.1", 15000);

                NetworkStream Stream = Client.GetStream();

                if (Stream.CanRead)
                    Stream.Write(send_byte, 0, send_index + 1);
            }
            catch
            {
                // ErrorSend.Parsing(ErrorSend.ErrorType.NotConnect, m_pMain);
            }
        }

        internal void Clean()
        {
            send_index = 0;
            get_index = 0;
        }
    }
}
