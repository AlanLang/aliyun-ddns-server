using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace aliyun_ddns
{
    public partial class Service1 : ServiceBase
    {
        private System.Timers.Timer timer = new System.Timers.Timer();
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            LogUtil.Log("aliyun-ddns服务已启动");
            ConfigHelper help = new ConfigHelper();
            help.SetConfig();
            timer.Elapsed += new System.Timers.ElapsedEventHandler(SendTest_Elapsed);
            timer.Interval = 60*1000;
            timer.Start();
        }

        public void SendTest_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            CDomainHelper aliyun = new CDomainHelper();
            var record = aliyun.DescribeDomains();
            string ipAddr = aliyun.GetIpAddr();
            if (ipAddr != record.Value)
            {
                aliyun.UpdateDomainRecords(ipAddr,record.RecordId);
                LogUtil.Log("更新ddns为：" + ipAddr);
            }
        }

        protected override void OnStop()
        {
            LogUtil.Log("aliyun-ddns服务已停止");
        }
    }
}
