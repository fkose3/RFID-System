using System;
using System.Collections.Generic;
using System.Text;

namespace Client.OkumaYazma
{
    public class ByteValue : System.Attribute
    {
        byte _Value;

        public ByteValue(byte value)
        {
            _Value = value;
        }

        public byte Value
        {
            get { return _Value; }
        }
    }
}
