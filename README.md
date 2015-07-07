# AccountBook
![default](https://cloud.githubusercontent.com/assets/11957202/8506734/43169fb6-2256-11e5-97f5-210056025c56.png)

## 项目概述

本项目是基于 Windows Phone 8 开发的手机本地记账软件。采用的开发语言是 XAML + C# 。记账本采用了独立存储作为数据存储的机制，将对象序列化为 XML 文件。项目中引用了一些开源的 Toolkit，比如 [Coding4Fun](http://coding4fun.codeplex.com/) 、 [Silverlight](http://silverlight.codeplex.com/) 。另外，项目中还包含一个自己编写的 ImageButton 控件，实现了按下时图片按钮发生图片替换的效果。应用现已发布到应用商店：http://www.windowsphone.com/s?appid=4b41d4fc-235b-4594-a113-107b67e99fc1

## 基本功能

1. 流水添加（支出、收入、转账）
2. 流水查询（年报表、月报表、关键字检索）
3. 流水编辑/查看
4. 账户管理（添加、修改金额、查看消费流水）
5. 报表（收入分类表、支出分类表、商家支出表）
6. 收支分类设置
7. 商家设置

##开发环境##
    
* **开发软件：** Visual Studio Community 2013
* **操作系统：** Windows 8.1 专业版 64 位

##目前不足##

+ 没有同步功能
+ 数据存储在本地，将记账数据对象序列化为 XML 文件，对大数据处理效率不高

##作者信息##

* **作者：** 汤和果
* **E-mail：** [hgtang93@hotmail.com](mailto:hgtang93@hotmail.com)
* **地址：** 计算机科学与工程系，数理与信息工程学院，浙江师范大学，浙江省金华市迎宾大道688号
