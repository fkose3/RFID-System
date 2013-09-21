using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgretimGorevlisi
{
    public class Tampon
    {
        // String Value
        public static void SetString(ref byte[] send_buff, byte[] text, int text_len, ref int send_index) // Denendi Tamam
        {
            for (int i = 0; i < text_len; i++)
                send_buff[++send_index] = text[i];
        }
        // String Value
        public static void GetString(byte[] get_buff, ref byte[] text_buff, int text_len, ref int get_index) // Denendi Tamam
        {
            int text_index = -1;
            for (int i = 0; i < text_len; i++)
                text_buff[++text_index] = get_buff[++get_index];
        }

        public static string GetString(byte[] get_buff, int text_len, ref int get_index) // Denendi Tamam
        {
            int text_index = -1;
            byte[] text_buff = new byte[text_len];
            for (int i = 0; i < text_len; i++)
                text_buff[++text_index] = get_buff[++get_index];

            return Encoding.UTF8.GetString(text_buff);
        }

        // Byte Value
        public static void SetByte(ref byte[] send_buff, byte bytes, ref int send_index) // Denendi Tamam
        {
            send_buff[++send_index] = bytes;
        }

        // Byte Value 2
        public static byte GetByte(byte[] get_buff, ref int get_index)
        {
            return get_buff[++get_index];
        }

        // Byte Value
        public static void GetByte(byte[] get_buff, ref byte bytes, ref int get_index) // Denendi Tamam
        {
            bytes = get_buff[++get_index];
        }
        // Short Value
        public static void SetShort(ref byte[] send_buff, Int16 tem, ref int send_index) // Denendi Tamam
        {
            byte[] NewByte = { (byte)(tem & 0x00FF), (byte)((tem & 0xFF00) >> 8) };

            for (int i = 0; i < 2; i++)
                send_buff[++send_index] = NewByte[i];

        }


        // DWORD Value
        public static void SetDWORD(ref byte[] send_buff, Int32 tmp, ref int send_index) // Denendi Tamam
        {
            byte[] NewByte = { (byte)(tmp & 0x000000FF),
                               (byte)((tmp & 0x0000FF00) >> 8), 
                               (byte)((tmp & 0x00FF0000) >> 16), 
                               (byte)((tmp & 0xFF000000) >> 24) };

            for (int i = 0; i < 4; i++)
                send_buff[++send_index] = NewByte[i];

        }
        // Short Value
        public static void GetShort(byte[] send_buff, ref Int16 tmp, ref int send_index) // Denendi Tamam
        {
            tmp = Convert.ToInt16(send_buff[++send_index]
                              | ((send_buff[++send_index]) << 8)
                /*| ((send_buff[++send_index]) << 16) // DWORD
                | ((send_buff[++send_index]) << 24)*/);
        }

        public static short GetShort(byte[] send_buff, ref int send_index) // Denendi Tamam
        {
            Int16 tmp = Convert.ToInt16(send_buff[++send_index]
                              | ((send_buff[++send_index]) << 8));
            return tmp;
        }

        // DWORD Value
        public static void GetDWORD(byte[] send_buff, ref Int32 tmp, ref int send_index) // Denendi Tamam
        {
            tmp = Convert.ToInt32(send_buff[++send_index]
                              | ((send_buff[++send_index]) << 8)
                              | ((send_buff[++send_index]) << 16)
                              | ((send_buff[++send_index]) << 24));
        }

    }
}
