create database NFBook
go
use NFBook
go
create table UserInfo
(
	ID int primary key identity(1000,1),					--用户编号
	LoginName nvarchar(20) not null,						--帐号
	Password nvarchar(50) not null,							--密码
	UsertName nvarchar(20) not null,						--用户姓名
	[State] int null,										--用户状态
	Email nvarchar(30) not null,							--电子邮件
	Question nvarchar(128) null,							--密保问题
	Answer nvarchar(128) null,								--密保答案
	LastLogDate datetime null,								--最后一次登录时间
	Phone nvarchar(32) null,								--联系电话
	QQMSN nvarchar(64) null,								--QQ或MSN帐号
	Gender nvarchar(2) null,								--性别
	Birthday datetime null,									--出生日期
	[Address] nvarchar(256) null,							--通讯地址
)
go
