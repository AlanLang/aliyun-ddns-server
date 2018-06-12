using SharpYaml.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace aliyun_ddns
{
    public class Config
    {
       public string IPUrl { get; set; }
        public string AccessKey { get; set; }
        public string AccessKeySecret { get; set; }
        public string APIUrl { get; set; }
        public string DomainName { get; set; }
        public string FirstName { get; set; }
    }
    public class ConfigHelper
    {
        public bool SetConfig()
        {
            try
            {
                string filepath = AppDomain.CurrentDomain.BaseDirectory + "config.yml";
                FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read);
                var serializer = new Serializer();
                var config = serializer.Deserialize<Config>(fs);

                if (string.IsNullOrEmpty(config.IPUrl) || string.IsNullOrEmpty(config.AccessKey) || string.IsNullOrEmpty(config.AccessKeySecret) || string.IsNullOrEmpty(config.APIUrl) || string.IsNullOrEmpty(config.DomainName))
                {
                    LogUtil.Log("读取配置异常，参数不全");
                    return false;
                }
                CGlobalConfig.IPUrl = config.IPUrl;
                CGlobalConfig.AccessKey = config.AccessKey;
                CGlobalConfig.AccessKeySecret = config.AccessKeySecret;
                CGlobalConfig.APIUrl = config.APIUrl;
                CGlobalConfig.DomainName = config.DomainName;
                CGlobalConfig.FirstName = string.IsNullOrEmpty(config.FirstName)?"@":config.FirstName;

                return true;
            }
            catch (Exception ex)
            {
                LogUtil.Log("读取配置异常：" + ex.Message);
                return false;
            }

        }
    }
}
