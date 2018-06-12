%SystemRoot%\Microsoft.NET\Framework\v4.0.30319\installutil.exe %~dp0\aliyun-ddns.exe
Net Start AliyunDDNS
sc config AliyunDDNS start= auto
pause