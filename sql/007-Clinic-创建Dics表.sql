Create Table Dics
(
	DicId int primary key,
	TenantId int,
	DicKey nvarchar(50),
	DicValue nvarchar(50),
	DicTypeid int,
	DicType nvarchar(50),
	SearchKey nvarchar(200),
	CreateTime datetime ,
	IsEnable int ,
	IsDelete int 
)



Insert into Dics(DicId,TenantId,DicKey,DicValue,DicTypeid,DicType,CreateTime,IsEnable,IsDelete)
Values(1,0,1,'����Ⱦ��ҩ��',1,'Drug.West',GETDATE(),1,1),
(2,0,2,'����ҩ',1,'Drug.West',GETDATE(),1,1),
(3,0,3,'��ϵͳ��ҩ��',1,'Drug.West',GETDATE(),1,1),
(4,0,4,'��Ѫ��ϵͳ��ҩ��',1,'Drug.West',GETDATE(),1,1),
(5,0,5,'ѪҺϵͳ��ҩ��',1,'Drug.West',GETDATE(),1,1),
(6,0,6,'����ϵͳ��ҩ��',1,'Drug.West',GETDATE(),1,1),
(7,0,7,'����ϵͳ��ҩ��',1,'Drug.West',GETDATE(),1,1),
(8,0,8,'����ϵͳ��ҩ��',1,'Drug.West',GETDATE(),1,1)

