﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class TextLogger : ILoggable
    {

        public void Save(Message message)
        {
            StreamWriter sw = null;
            try
            {
                sw = File.AppendText(@"ChatLog.txt");
                string logLine = String.Format("{0:G}: {1}", DateTime.Now, message.Body);
                sw.WriteLine(logLine);
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: '{0}'", e);
            }
            finally
            {
                if (sw != null)
                {
                    sw.Close();
                }
            }
        }

    }
}
