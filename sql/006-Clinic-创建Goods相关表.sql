select * From Goods

--������Ʒ
Create Table Goods
(
	GoodId int primary key,
	TenantId int,
	GoodName nvarchar(400),
	Norm nvarchar(100),	
	Factory nvarchar(200),	
	GoodType int,
	GoodSort int,
	GoodStandard nvarchar(100),
	InsuranceCode nvarchar(100),
	CustomerCode nvarchar(100),
	BarCode nvarchar(50),
	SearchKey nvarchar(100),
	SalesUnit nvarchar(100),
	StockUnit nvarchar(100),	
	Ratio int,
	CreateTime datetime ,
	IsEnable int ,
	IsDelete int  
)


--��Ʒ�ɹ�
Create Table Purchases
(
	PurchaseId int primary key,
	TenantId int,
	
)






