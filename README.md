# aliyun-ddns
基于阿里云解析服务API的DDNS服务。将本机IP更新至指定域名的DNS A记录，可以达到花生壳动态域名解析的效果。

## 使用方法
1. 在阿里云申请一个域名，将此域名添加一个子域（如www），并设置为A类型记录，IP地址随便填写一个（程序会自动修改）
2. 到阿里云域名控制台申请AccessId Key和Secrect
3. Clone本项目代码到本机，使用VS2013或更高版本编译 (或直接下载release)
4. 将生成的debug目录拷贝到服务器上，修改config.yml文件，然后用管理员权限运行install.bat

## 配置说明
`config.yml`

```
# 检测外网ip地址的网站
IPUrl: http://2019.ip138.com/ic.asp
# 阿里云接口地址
APIUrl: http://alidns.aliyuncs.com
DomainName: 域名 例如 google.com
FirstName: 前缀，例如www,空则为 @
AccessKey: Access Id Key
AccessKeySecret: Access Id Secret
```

## 环境
使用 vs2015+C# 开发 .NET 4.0
