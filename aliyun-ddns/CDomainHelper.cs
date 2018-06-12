using Aliyun.Api;
using Aliyun.Api.DNS.DNS20150109.Request;
using Aliyun.Api.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace aliyun_ddns
{
    /// <summary>
    /// 域名解析帮助类
    /// </summary>
    public class CDomainHelper
    {
        DefaultAliyunClient aliyunClient;
        public CDomainHelper()
        {
            aliyunClient = new DefaultAliyunClient(CGlobalConfig.APIUrl, CGlobalConfig.AccessKey, CGlobalConfig.AccessKeySecret);
        }
        /// <summary>
        /// 获取当前的解析值
        /// </summary>
        /// <returns></returns>
        public Record DescribeDomains()
        {

            var req = new DescribeDomainRecordsRequest() { DomainName = CGlobalConfig.DomainName };
            var response = aliyunClient.Execute(req);

            var updateRecord = response.DomainRecords.FirstOrDefault(rec => rec.RR == CGlobalConfig.FirstName && rec.Type == "A");
            return updateRecord;

        }
        /// <summary>
        /// 更新域名解析值
        /// </summary>
        /// <param name="ipaddr">新的ip地址</param>
        /// <param name="recordId">解析条目的主键</param>
        public void UpdateDomainRecords(string ipaddr,string recordId)
        {
            var changeValueRequest = new UpdateDomainRecordRequest()
            {
                RecordId = recordId,
                Value = ipaddr,
                Type = "A",
                RR = CGlobalConfig.FirstName
            };
            aliyunClient.Execute(changeValueRequest);
        }
        /// <summary>
        /// 获取外网ip地址
        /// </summary>
        /// <returns></returns>
        public string GetIpAddr()
        {
            HttpWebRequest request = HttpWebRequest.Create(CGlobalConfig.IPUrl) as HttpWebRequest;
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("GB2312"));
                string str = reader.ReadToEnd();
                reader.Close();
                reader.Dispose();
                int start = str.IndexOf("[");
                int end = str.IndexOf("]");
                if (start > -1 && end > -1 && end > start)
                {
                    string ip = str.Substring(start + 1, end - start - 1);
                    return ip;
                }
                return "";
            }
        }
    }
}
