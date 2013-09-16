using System;
using System.Collections.Generic;
using System.Text;

namespace Client
{
    public class TextPassWord
    {
        public TextPassWord()
        { }

        public string GetNoPass(string text)
        {
            string nonpass="";
            int upper = 3;
            foreach (char isn in text.ToCharArray())
            {
                string chr = "";
                for (int i = 0; i < 3; i++)
                {
                    chr = Convert.ToChar(isn - upper).ToString();
                }
                nonpass += chr;
                upper++;
            }
            return nonpass;
        }

        public string SetPass(string text)
        {
            string passtext="";
            int upper = 3;
            foreach (char isn in text.ToCharArray())
            {
                string chr = "";
                for (int i = 0; i < 3; i++)
                {
                    chr = Convert.ToString(isn + upper);
                }
                passtext += chr;
                upper++;
            }

            return passtext;
        }
    }
}
