using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Client.OkumaYazma
{
    public static class ReadConfig
    {
        public static bool ReadBasicConfig(cMainForm m_pMain = null)
        {
            try
            {
                if (m_pMain == null) return false;

                StreamReader MyReader = new StreamReader("Config.MBSPWD");

                string reading = "";
                bool[] reads = new bool[3];
                for (int i = 0; i < reads.Length; i++)
                    reads[i] = false;

                while ((reading = MyReader.ReadLine()) != null)
                {
                    TextPassWord TxtNone = new TextPassWord();

                    string[] SplitNonPassText = TxtNone.GetNoPass(reading).Split(':');

                    switch (SplitNonPassText[0])
                    {
                        case "Soket":
                            m_pMain.soket = int.Parse(SplitNonPassText[1]);
                            if (reads[0])
                            {
                                ErrorSend.Parsing(ErrorSend.ErrorType.wrongConfig, m_pMain);
                                return false;
                            }
                            reads[0] = !reads[0];
                            break;
                        case "Dil":
                            m_pMain.language = SplitNonPassText[1];
                            if (reads[1])
                            {
                                ErrorSend.Parsing(ErrorSend.ErrorType.wrongConfig, m_pMain);
                                return false;
                            }
                            reads[1] = !reads[1];
                            break;
                        case "Server":
                            m_pMain.MAIN_SERVER_IP = SplitNonPassText[1];
                            if (reads[2])
                            {
                                ErrorSend.Parsing(ErrorSend.ErrorType.wrongConfig, m_pMain);
                                return false;
                            }
                            reads[2] = !reads[2];
                            break;
                    }
                }       
            }
            catch
            {
                ErrorSend.Parsing(ErrorSend.ErrorType.NotConfig, m_pMain);
                return false;
            }
            return true;
        }
    }
}
