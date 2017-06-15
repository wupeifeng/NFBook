create database NFBook
go
use NFBook
go
create table UserInfo
(
	ID int primary key identity(1000,1),					--�û����
	LoginName nvarchar(20) not null,						--�ʺ�
	Password nvarchar(50) not null,							--����
	UsertName nvarchar(20) not null,						--�û�����
	[State] int null,										--�û�״̬
	Email nvarchar(30) not null,							--�����ʼ�
	Question nvarchar(128) null,							--�ܱ�����
	Answer nvarchar(128) null,								--�ܱ���
	LastLogDate datetime null,								--���һ�ε�¼ʱ��
	Phone nvarchar(32) null,								--��ϵ�绰
	QQMSN nvarchar(64) null,								--QQ��MSN�ʺ�
	Gender nvarchar(2) null,								--�Ա�
	Birthday datetime null,									--��������
	[Address] nvarchar(256) null,							--ͨѶ��ַ
)
go
