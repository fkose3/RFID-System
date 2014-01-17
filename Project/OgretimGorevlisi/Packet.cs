using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgretimGorevlisi
{
    public class Packet
    {
        Socket skt;
        byte[] send_byte;
        int send_index = 0;
        int get_index = 0;

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

        public Int32 GetShort()
        {
            byte[] byt = new byte[4];
            for (int i = 0; i < byt.Length; i++)
                byt[i] = GetByte();

            return (Int32)BitConverter.ToInt32(byt, 0);
        }

        public Int64 GetShort()
        {
            byte[] byt = new byte[8];
            for (int i = 0; i < byt.Length; i++)
                byt[i] = GetByte();

            return (Int64)BitConverter.ToInt64(byt, 0);
        }
    }
}
