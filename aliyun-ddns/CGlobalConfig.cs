using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace aliyun_ddns
{
    public static class CGlobalConfig
    {
        public static string IPUrl { get; set; }
        public static string AccessKey { get; set; }
        public static string AccessKeySecret { get; set; }
        public static string APIUrl { get; set; }
        public static string DomainName { get; set; }
        public static string FirstName { get; set; }
    }
}
