using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Client
{
    public static class  ErrorSend
    {
       

        public enum ErrorType:int
        {
            [StringValue("error1")]    // Bağlantı hatasi
            NotConnect=1   ,
            [StringValue("error2")]    // Disconnet
            Disconnect   ,
            [StringValue("error3")]    // Veri okuma hatası
            DataCould    ,
            [StringValue("error4")]    // Ayar Dosyasi yok
            NotConfig    ,
            [StringValue("error5")]    // Hatalı ayar
            wrongConfig  ,
            [StringValue("error6")]    // Lisans Yetersiz
            InsufficientDegree , 
            [StringValue("error7")]    // Lisans Satın al
            LicenseOrder ,
            [StringValue("error8")]    // Program açik
            OnlineProgram
        }

        public static void Parsing(ErrorType error,cMainForm m_pMain=null)
        {

            StreamReader Sreader = null ;

            if (m_pMain == null) return;

            switch (m_pMain.language)
            {
                case "TRK":
                      Sreader = new StreamReader("Language\\Error\\TRK.MBSPWD");
                      break;
                case "ENG":
                      Sreader = new StreamReader("Language\\Error\\ENG.MBSPWD");
                      break;
            }

            string s = "";

            while ((s = Sreader.ReadLine()) != null)
            {
                try
                {
                    TextPassWord txx = new TextPassWord();
                    string nonpass = txx.GetNoPass(s);
                    string[] prc = nonpass.Split(':');
                    if (prc[0] == StringEnum.GetStringValue(error))
                    {
                        MessageBox.Show(prc[1], "Error..!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch
                {
                    continue;
                }
            }
           
        }

    }
}
