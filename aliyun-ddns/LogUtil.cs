using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace aliyun_ddns
{
    public class LogUtil
    {
        public static void Log(string msg)
        {
            string logPath = AppDomain.CurrentDomain.BaseDirectory + "Log/";
            if (!System.IO.Directory.Exists(logPath))
                System.IO.Directory.CreateDirectory(logPath);
            string logFile = logPath + "aliyun-ddns-" + DateTime.Now.ToString("yyyy-MM-dd") + ".log";
            System.IO.File.AppendAllLines(logFile, new string[] { DateTime.Now.ToString(), msg });
        }
    }
}
