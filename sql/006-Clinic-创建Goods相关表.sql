

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
	CreateTime datetime not null default(getdate()),
	IsEnable int not null default(1),
	IsDelete int not null default(1) 
)



Create Table Purchases
(

)






