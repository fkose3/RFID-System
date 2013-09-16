using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Client.OkumaYazma
{
    public static class byteEnum
    {
        public static byte GetByteValue(Enum value)
        {
            byte output = 0x00;

            Type type = value.GetType();

            FieldInfo fi = type.GetField(value.ToString());

            ByteValue[] attrs =
               fi.GetCustomAttributes(typeof(ByteValue),
                                       false) as ByteValue[];

            output = attrs[0].Value;

            return output;
        }
    }
}
