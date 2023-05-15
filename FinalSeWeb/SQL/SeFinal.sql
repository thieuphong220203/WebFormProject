Create database FINAL_SE
GO

USE FINAL_SE
GO

--DROP database FINAL_SE
-------------TABLE----------------
CREATE TABLE [TYPE_PRODUCT](
	TypeProduct_ID varchar(300) PRIMARY KEY,
	TypeProductName varchar(500),
)
GO

CREATE TABLE [MOBILE_PRODUCT](
	Product_ID varchar(300) PRIMARY KEY,
	Product_Name varchar(500),
	TypeProduct_ID varchar(300),
	Supplier_ID varchar(300),
	Unit varchar(20),
	Price money,
	Quantities int,
	Image_Product varchar(200),
)
GO

CREATE TABLE [SUPPLIER] (
	Supplier_ID varchar(300) PRIMARY KEY,
	Supplier_Name varchar(500),
	Supplier_Address varchar(200),
	Supplier_Email varchar(100),
	Suppler_Phone varchar(20),
)
GO


CREATE TABLE [AGENT](
	Agent_ID varchar(300) PRIMARY KEY,
	Agent_Name varchar(500),
	Agent_Address varchar(200),
	Agent_Email varchar(100),
	Agent_Phone varchar(20),
)
GO

CREATE TABLE [AGENT_ACCOUNT] (
	UserName varchar(300) primary key,
	Agent_ID varchar(300),
	Account_Password varchar(200),
	Agent_Level INT,
)
GO

CREATE TABLE [ORDER_LIST](
	OrderList_ID varchar(300) PRIMARY KEY,
	UserName_Agent varchar(300),
	UserName_Customer varchar(300),
	Date_Created_OrderList date,
	Note varchar(500),
	Status_OrderList varchar(20),
)
GO

CREATE TABLE [ORDER_LIST_DETAILS](
	Product_ID varchar(300),
	OrderList_ID varchar(300),
	Quantities int,
	Delivery_Date date,
	Total_Money money,
	Remain_Quantities int,
	PRIMARY KEY(Product_ID, OrderList_ID),
)
GO

CREATE TABLE [INVOICE](
	Invoice_ID varchar(300) PRIMARY KEY,
	OrderList_ID varchar(300),
	Date_Created_Invoice date,
	Status_Invoice varchar(20),
)
GO

CREATE TABLE [PAYMENT_METHOD](
	PaymentMethod_ID varchar(100) PRIMARY KEY,
	Method_Name varchar(500),
)
GO

CREATE TABLE [TRANSACTION] (
	Transaction_ID varchar(300) PRIMARY KEY,
	PaymentMethod_ID varchar(100),
	Date_Created_Transaction date,
	Status_Transaction varchar(20),
	Invoice_ID varchar(300),
)
GO

CREATE TABLE [ACCOUNTANT] (
	Accountant_ID varchar(300) PRIMARY KEY,
	Accountant_Name varchar(500),
	Gender varchar(6),
	Accountant_Birth date,
	Accountant_Address varchar(200),
	Accountant_Email varchar(100),
	Accountant_Phone varchar(20),
	Accountant_UserName varchar(100),
	Accountant_Password varchar(100),
	Accountant_Image varbinary(MAX),
)
GO

CREATE TABLE [GOOD_DELIVERY](
	Good_Delivery_ID varchar(300) PRIMARY KEY,
	Transaction_ID varchar(300),
	Accountant_ID varchar(300),
	OrderList_ID varchar(300),
	Date_Created_Good_Delivery date,
)
GO

CREATE TABLE [WAREHOUSE_RECEIPT](
	Receipt_ID varchar(300) PRIMARY KEY,
	Accountant_ID varchar(300),
	Date_Created_Receipt date,
	Driver_Name varchar(100),
	WareHouse_Address varchar(100),
	Total money,
)
GO

CREATE TABLE [RECEIPT_DETAILS](
	Receipt_ID varchar(300),
	Product_ID varchar(300),
	Price money,
	Quantities int,
	PRIMARY KEY (Receipt_ID, Product_ID),
)
GO

CREATE TABLE [CUSTOMER](
	Customer_ID varchar(300) PRIMARY KEY,
	Customer_Name varchar(100),
	Customer_Birth date,
	Customer_Gender varchar(6),
	Customer_Address varchar(200),
	Customer_Email varchar(100),
	Customer_Phone varchar(20),	
)
GO

CREATE TABLE [CUSTOMER_ACCOUNT](
	UserName varchar(300) primary key,
	Customer_ID varchar(300),
	Account_Password varchar(200),
	Customer_Level INT, 
)
GO
--------------FOREIGN KEY--------------------
ALTER TABLE [MOBILE_PRODUCT]
ADD CONSTRAINT FK_MOBILEPRODUCT_TYPEPRODUCT
FOREIGN KEY (TypeProduct_ID)
REFERENCES [TYPE_PRODUCT](TypeProduct_ID);
GO

ALTER TABLE [MOBILE_PRODUCT]
ADD CONSTRAINT FK_MOBILEPRODUCT_Supplier
FOREIGN KEY (Supplier_ID)
REFERENCES [SUPPLIER](Supplier_ID);
GO

ALTER TABLE [AGENT_ACCOUNT]
ADD CONSTRAINT FK_AGENTACCOUNT_AGENT
FOREIGN KEY (AGENT_ID)
REFERENCES [AGENT](AGENT_ID);
GO

ALTER TABLE [ORDER_LIST]
ADD CONSTRAINT FK_ORDERLIST_AGENTACCOUNT
FOREIGN KEY (UserName_Agent)
REFERENCES [AGENT_ACCOUNT](UserName);
GO

ALTER TABLE [ORDER_LIST]
ADD CONSTRAINT FK_ORDERLIST_CUSTOMERACCOUNT
FOREIGN KEY (UserName_Customer)
REFERENCES  [CUSTOMER_ACCOUNT](UserName);
GO

ALTER TABLE [ORDER_LIST_DETAILS]
ADD CONSTRAINT FK_ORDERLISTDETAILS_MOBILEPRODUCTS
FOREIGN KEY (Product_ID)
REFERENCES [MOBILE_PRODUCT](Product_ID);
GO

ALTER TABLE [ORDER_LIST_DETAILS]
ADD CONSTRAINT FK_ORDERLISTDETAILS_ORDER_LIST
FOREIGN KEY (OrderList_ID)
REFERENCES [ORDER_LIST](OrderList_ID);
GO

ALTER TABLE [INVOICE]
ADD CONSTRAINT FK_INVOICE_ORDERLIST
FOREIGN KEY (OrderList_ID)
REFERENCES [ORDER_LIST](OrderList_ID);
GO

ALTER TABLE [TRANSACTION]
ADD CONSTRAINT FK_TRANSACTION_PAYMENTMETHOD
FOREIGN KEY (PaymentMethod_ID)
REFERENCES [PAYMENT_METHOD](PaymentMethod_ID);
GO

ALTER TABLE [TRANSACTION]
ADD CONSTRAINT FK_TRANSACTION_INVOICE
FOREIGN KEY (Invoice_ID)
REFERENCES [INVOICE](Invoice_ID);
GO
ALTER TABLE [GOOD_DELIVERY]
ADD CONSTRAINT FK_GOODDELIVERY_ACCOUNTANT
FOREIGN KEY (Accountant_ID)
REFERENCES [ACCOUNTANT](Accountant_ID);
GO

ALTER TABLE [GOOD_DELIVERY]
ADD CONSTRAINT FK_GOODDELIVERY_ORDERLIST
FOREIGN KEY (OrderList_ID)
REFERENCES [ORDER_LIST](OrderList_ID);
GO

ALTER TABLE [GOOD_DELIVERY]
ADD CONSTRAINT FK_GOODDELIVERY_TRANSACTION
FOREIGN KEY (Transaction_ID)
REFERENCES [TRANSACTION](Transaction_ID);
GO

ALTER TABLE [WAREHOUSE_RECEIPT]
ADD CONSTRAINT FK_WAREHOUSERECEIPT_ACCOUNTANT
FOREIGN KEY(Accountant_ID)
REFERENCES [ACCOUNTANT](Accountant_ID);
GO


ALTER TABLE [RECEIPT_DETAILS]
ADD CONSTRAINT FK_RECEIPTDETAILS_MOBILEPRODUCTS
FOREIGN KEY(Product_ID)
REFERENCES [MOBILE_PRODUCT](Product_ID);
GO

ALTER TABLE [RECEIPT_DETAILS]
ADD CONSTRAINT FK_RECEIPTDETAILS_WAREHOUSE_RECEIPT
FOREIGN KEY(Receipt_ID)
REFERENCES [WAREHOUSE_RECEIPT](Receipt_ID);
GO

ALTER TABLE [CUSTOMER_ACCOUNT]
ADD CONSTRAINT FK_CUSTOMERACCOUNT_CUSTOMER
FOREIGN KEY (Customer_ID)
REFERENCES [CUSTOMER](Customer_ID);
GO


------------DELETE TABLE -----------
--Drop Table [WAREHOUSE_RECEIPT]
--GO
--ALTER TABLE [TRANSACTION]
--DROP CONSTRAINT FK_TRANSACTION_INVOICE

--ALTER TABLE [ACCOUNTANT]
--ALTER COLUMN Gender varchar(6);
--GO
--------------INSERT TABLE ------------
INSERT INTO [ACCOUNTANT] VALUES('AC00000001','Michael Kors','Male','02-22-1992','America','michaelkors@gmail.com','+12019058727','kors123','123',null),
							('AC00000002','John Wick','Male','08-14-1991','America','johnwick23@gmail.com','+12012771413','wick23','456',null),
							('AC00000003','Kylian Mbappe','Male','12-05-1999','France','kylian05@gmail.com','+33644628731','kylian05','678',null),
							('AC00000004','Marleen Lohse','Female','02-28-1984','Germany','lohsemarlen28@gmail.com','+32468799067','marlen28','8910',null)
GO


INSERT INTO [SUPPLIER] VALUES('SP00000001','APPLE','America','support@apple.com','+18002752273'),
							('SP00000002','SAMSUNG','South Korea','support.kr@samsung.com','1800588889'),
							('SP00000003','LG','South Korea','lgcarecenter@lge.com','18001503'),
							('SP00000004','ASUS','Taiwan','asuscenter@gmail.com','+862134074610'),
							('SP00000005','OPPO','Chinese','oppocenter@gmail.com','1800956396'),
							('SP00000006','HUAWEI','Chinese','huaweicenter@gmail.com','1847956396')


INSERT INTO [TYPE_PRODUCT] VALUES('TP00000001','IPHONE X'),
							     ('TP00000002','IPHONE XS MAX'),
								 ('TP00000003','IPHONE 11'),
								 ('TP00000004','IPHONE 12'),
								 ('TP00000005','IPHONE 13'),
								 ('TP00000006','IPHONE 14'),
								 ('TP00000007','SAMSUNG GALAXY S22'),
								 ('TP00000008','SAMSUNG GALAXY S23'),
								 ('TP00000009','SAMSUNG GALAXY S23 ULTRA'),
								 ('TP00000010','SAMSUNG NOTE 8'),
								 ('TP00000011','SAMSUNG NOTE 10'),
								 ('TP00000012','SAMSUNG NOTE 12'),
								 ('TP00000013','SAMSUNG A04'),
								 ('TP00000014','SAMSUNG GALAXY A13'),
								 ('TP00000015','SAMSUNG GALAXY A23'),
								 ('TP00000016','SAMSUNG GALAXY A53'),
								 ('TP00000017','SAMSUNG GALAXY A73'),
								 ('TP00000018','LG V10'),
								 ('TP00000019','LG Q7'),
								 ('TP00000020','LG W30'),
								 ('TP00000021','LG W41'),
								 ('TP00000022','ASUS ZenFone 7'),
								 ('TP00000023','ASUS ZenFone 7 Pro'),
								 ('TP00000024','ASUS Zenfone 8 Flip'),
								 ('TP00000025','ASUS Zenfone 8'),
								 ('TP00000026','ASUS Zenfone 9'),
								 ('TP00000027','ASUS ROG Phone 6'),
								 ('TP00000028','ASUS ROG Phone 6D Ultimate'),
								 ('TP00000029','ASUS ROG Phone 6D'),
								 ('TP00000030','ASUS ROG Phone 7'),
								 ('TP00000031','ASUS ROG Phone 7 Ultimate'),
								 ('TP00000032','OPPO Reno8 T 5G'),
								 ('TP00000033','OPPO A55'),
								 ('TP00000034','OPPO A16K'),
								 ('TP00000035','OPPO Find N2 Flip'),
								 ('TP00000036','HUAWEI P40 Pro'),
								 ('TP00000037','HUAWEI P40 Pro+'),
								 ('TP00000038','Huawei Nova 10 Pro'),
								 ('TP00000039','Huawei Pocket S'),
								 ('TP00000040','Huawei P30'),
								 ('TP00000041','Huawei P30 Lite'),
								 ('TP00000042','Huawei Nova 9 SE')
GO

INSERT INTO [MOBILE_PRODUCT] VALUES ('PR00000001','IPHONE X 32GB','TP00000001','SP00000001','USD', 200,25,null),
									('PR00000002','IPHONE X 64GB','TP00000001','SP00000001','USD',250,30,null),
									('PR00000003','IPHONE 12 64GB','TP00000001','SP00000001','USD',400,3,null),
									('PR00000004','IPHONE 12 256GB','TP00000001','SP00000001','USD',450,30,null),
									('PR00000005','IPHONE 13 128GB','TP00000001','SP00000001','USD',550,20,null),
									('PR00000006','IPHONE 14 512GB','TP00000001','SP00000001','USD',799,15,null),
									('PR00000007','SAMSUNG GALAXY S22 256GB','TP00000007','SP00000002','KRW',900000,4,null),
									('PR00000008','SAMSUNG GALAXY S22 512GB','TP00000007','SP00000002','KRW',950000,3,null),
									('PR00000009','SAMSUNG GALAXY S23 128GB','TP00000008','SP00000002','KRW',1200000,2,null),
									('PR00000010','SAMSUNG GALAXY S23 256GB','TP00000008','SP00000002','KRW',1250000,1,null),
									('PR00000011','SAMSUNG GALAXY S23 ULTRA 256GB','TP00000009','SP00000002','USD',700,0,null),
									('PR00000012','SAMSUNG GALAXY S23 ULTRA 512GB','TP00000009','SP00000002','USD',750,25,null),
									('PR00000013','SAMSUNG NOTE 8 64GB','TP00000010','SP00000002','USD',300,100,null),
									('PR00000014','SAMSUNG NOTE 8 32GB','TP00000010','SP00000002','USD',350,200,null),
									('PR00000015','SAMSUNG NOTE 8 128GB','TP00000010','SP00000002','USD',375,50,null),
									('PR00000016','SAMSUNG NOTE 10 64GB','TP00000011','SP00000002','USD',400,150,null),
									('PR00000017','SAMSUNG NOTE 10 128GB','TP00000011','SP00000002','USD',450,12,null),
									('PR00000018','SAMSUNG NOTE 10 256GB','TP00000011','SP00000002','USD',470,18,null),
									('PR00000019','SAMSUNG NOTE 12 256GB','TP00000012','SP00000002','USD',500,9,null),
									('PR00000020','SAMSUNG NOTE 12 512GB','TP00000012','SP00000002','USD',550,26,null)
GO

INSERT INTO[AGENT] VALUES('AG000000001','Mark Co.', 'America','markcompany@gmail.com','18212752273'),
						 ('AG000000002','Lyly Co.', 'America','lylycompany@gmail.com','18245752273'),
						 ('AG000000003','Dat Co.', 'Viet Nam','Datcorp@gmail.com','0913557123'),
						 ('AG000000004','Power Co.', 'Australia','powercompany@gmail.com','97212752273')
GO

INSERT INTO[AGENT_ACCOUNT] VALUES('mark44','AG000000001','123',1),
								 ('lyly@12','AG000000002','423',1),
								 ('dat@09','AG000000003','445',2),
								 ('power_45','AG000000004','667',3)
GO


INSERT INTO[CUSTOMER] VALUES('C000000001','Ta Tien Dat','05-02-2003','Male','Go Vap','tatiendat@gmail.com','0901776891'),
							('C000000002','Tang Thieu Phong','02-22-2003','Male','TPHCM','tangthieuphong123@gmail.com','0938860238'),
							('C000000003','Lam Nguyen Anh Thy','06-01-2003','Female','Tra Vinh','anhthy06@gmail.com','0901876191')
GO

INSERT INTO[CUSTOMER_ACCOUNT] VALUES('tiendat09','C000000001','dat@123',1),
									('phong2202','C000000002','phong@123',2),
									('anhthy06','C000000003','anhthy@123',3)
GO


INSERT INTO [ORDER_LIST] VALUES ('OR00000001',null,'tiendat09','01-22-2023','Note Something Here','Paid'),
								('OR00000002',null,'tiendat09','02-22-2023','Note Something Here','Paid'),
								('OR00000003',null,'phong2202','03-23-2023','Note Something Here','Paid'),
								('OR00000004',null,'anhthy06','03-25-2023','Note Something Here','Paid'),
								('OR00000005',null,'phong2202','04-26-2023','Note Something Here','Paid'),
								('OR00000006','mark44',null,'04-27-2023','Note Something Here','Paid'),
								('OR00000007','lyly@12',null,'04-28-2023','Note Something Here','Paid'),
								('OR00000008','dat@09',null,'04-29-2023','Note Something Here','Paid'),
								('OR00000009','power_45',null,'04-30-2023','Note Something Here','Paid')
GO

INSERT INTO [ORDER_LIST_DETAILS] VALUES ('PR00000001','OR00000001',3,'01-22-2023',600,0),
									    ('PR00000002','OR00000001',6,'01-22-2023',1500,0),
										('PR00000003','OR00000002',2,'02-22-2023',800,0),
									    ('PR00000004','OR00000002',2,'02-22-2023',1000,0),
										('PR00000001','OR00000003',3,'03-23-2023',750,0),
										('PR00000005','OR00000003',2,'03-23-2023',1100,0),
										('PR00000006','OR00000004',3,'03-25-2023',2397,0),
										('PR00000007','OR00000005',1,'04-26-2023',900000,0),
										('PR00000013','OR00000006',15,'04-26-2023',4500,0),
										('PR00000014','OR00000006',20,'04-26-2023',7000,0),
										('PR00000013','OR00000007',20,'04-28-2023',6000,0),
										('PR00000015','OR00000007',20,'04-28-2023',6000,0),
										('PR00000016','OR00000007',25,'04-28-2023',10000,0),
										('PR00000017','OR00000008',10,'04-29-2023',4500,0),
										('PR00000016','OR00000008',30,'04-29-2023',12000,0),
										('PR00000014','OR00000008',35,'04-29-2023',12250,0),
										('PR00000019','OR00000009',6,'04-30-2023',3000,0),
										('PR00000020','OR00000009',20,'04-30-2023',11000,0)
GO



INSERT INTO [PAYMENT_METHOD] VALUES('PM001','VNPay'),
								   ('PM002','Cash')
GO



INSERT INTO [INVOICE] VALUES ('IV00000001','OR00000001','01-22-2023','Completed'),
							 ('IV00000002','OR00000002','02-22-2023','Completed'),
							 ('IV00000003','OR00000003','03-23-2023','Completed'),
							 ('IV00000004','OR00000004','03-25-2023','Completed'),
							 ('IV00000005','OR00000005','04-26-2023','Completed'),
							 ('IV00000006','OR00000006','04-27-2023','Completed'),
							 ('IV00000007','OR00000007','04-28-2023','Completed'),
							 ('IV00000008','OR00000008','04-29-2023','Completed'),
							 ('IV00000009','OR00000009','04-30-2023','Completed')
GO


INSERT INTO [TRANSACTION] VALUES('TR00000001','PM002','01-22-2023','Finished','IV00000001'),
								('TR00000002','PM002','02-22-2023','Finished','IV00000002'),
								('TR00000003','PM002','03-23-2023','Finished','IV00000003'),
								('TR00000004','PM001','03-25-2023','Finished','IV00000004'),
								('TR00000005','PM001','04-26-2023','Finished','IV00000005'),
								('TR00000006','PM002','04-26-2023','Finished','IV00000006'),
								('TR00000007','PM001','04-28-2023','Finished','IV00000007'),
								('TR00000008','PM002','04-29-2023','Finished','IV00000008'),
								('TR00000009','PM002','04-30-2023','Finished','IV00000009')
GO


--------------------SELECT -------------
SELECT * FROM [ACCOUNTANT]
GO

SELECT * FROM [SUPPLIER]
GO

SELECT * FROM [TYPE_PRODUCT]
GO

SELECT * FROM [AGENT_ACCOUNT]
GO

SELECT * FROM [AGENT]
GO

SELECT * FROM [MOBILE_PRODUCT]
GO

SELECT * FROM [ORDER_LIST]
GO


SELECT * FROM [ORDER_LIST_DETAILS]
GO


SELECT * FROM [INVOICE]
GO

SELECT * FROM [TRANSACTION]
GO

SELECT * FROM [GOOD_DELIVERY]
GO

select * from [CUSTOMER_ACCOUNT]

select * from [CUSTOMER]
---------------------ADD ATTRIBUTE-------------
--ALTER TABLE [ORDER_LIST]
--ADD  Status_OrderList varchar(20);

--ALTER TABLE [INVOICE]
--Drop  COLUMN Transaction_ID

--DELETE FROM [TRANSACTION]

--ALTER TABLE [TRANSACTION]
--ADD Invoice_ID varchar(300)

------------------------------------

create proc checkExistedAgent @user nvarchar(300)
as begin
	select account.UserName,agent.Agent_Email
	from [AGENT_ACCOUNT] account inner join [AGENT] agent on account.Agent_ID = agent.Agent_ID
	where account.UserName = @user
end
 GO




