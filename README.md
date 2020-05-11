[![Build Status](https://dev.azure.com/asunp/PowershellMSGraphSDK/_apis/build/status/PowershellMSGraphSDK-.NET%20Desktop-CI?branchName=master)](https://dev.azure.com/asunp/PowershellMSGraphSDK/_build/latest?definitionId=12&branchName=master)

# PowerShellGraphSDK

本项目在Microsoft Intune-PowerShell SDK的基础 上，移除了Intune的SDK，针对国内版的Microsoft Graph API进行开发，提供一系列调用Microsoft Graph的PowerShell cmdlets。

## 安装指南

### 1. 从PowerShell Gallery安装

```
Install-Module -Name PowershellGraphSDK
```



### 2. 从Github安装

```
Import-Module $sdkDir/PowerShellGraphSDK.psd1
```



## 使用指南

1. Office 365 E3账号

   试用账号申请请点击[世纪互联蓝云网站](https://www.21vbluecloud.com/office365/)

2. Azure 应用程序（可选）

3. 连接MSGraph

   a.管理员授权

   ```
   Connect-MSGraph -AdminConsent
   ```

   b. 使用PSCredential对象

   ```
   # 1. 创建PSCredential对象
   $adminUPN = Read-Host -Prompt "输入您的账号"
   $adminPwd = Read-Host -AsSecureString -Prompt "输入密码: $adminUPN"
   $creds = New-Object System.Management.Automation.PSCredential ($adminUPN, $adminPwd)
   
   # 2. 登录
   Connect-MSGraph -Credential $creds
   ```

   您也可以使用自己创建的Azure 应用程序，方法如下：

   ```
   # 1. 配置环境
   Update-MSGraphEnvironment -AuthUrl 'https://login.chinacloudapi.cn/common' -GraphBaseUrl 'https://microsoftgraph.chinacloudapi.cn' -GraphResourceId 'https://microsoftgraph.chinacloudapi.cn' -AppId '应用程序ID' -RedirectLink '重定向地址' -SchemaVersion v1.0
   
   # 2. 登录
   Connect-MSGraph -Credential $creds
   
   # 3. 使用
   Invoke-MSGraphRequest -Url me -HttpMethod GET
   ```

   

## 调用方法

1. 获取个人信息

   ```
   Invoke-MSGraphRequest -Url me -HttpMethod GET
   ```

   

## 帮助
