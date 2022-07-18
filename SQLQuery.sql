create database CoffeeManagement
go

use CoffeeManagement
go

create table TableCoffee
(
	ID int identity primary key,
	Name nvarchar(100) not null default N'Unnamed',
	Status nvarchar(100) not null default N'Blank'
)

create table AccountType
(
	ID int identity primary key,
	TypeName nvarchar(50) not null
)
go

create table Account
(
	UserName varchar(100) primary key,
	DisplayName nvarchar(100) not null default N'Name',
	Password varchar(500) not null default 0,
	TypeID int not null

	foreign key (TypeID) references AccountType(ID)
)
go

create table CategoryFood
(
	ID int identity not null primary key,
	Name nvarchar(100) not null default N'Unnamed'
)
go

create table Food
(
	ID int identity primary key,
	Name nvarchar(100) not null default N'Unnamed',
	CategoryID int not null,
	Price int not null default 0

	foreign key (CategoryID) references CategoryFood(id)
)
go

create table Bill
(
	ID int identity primary key,
	TableID int not null,
	Discount int not null default 0,
	TotalPrice int default 0,
	Status int not null default 0, -- 1: Da thanh toan, 0: Chua thanh toan
	Name nvarchar(50) not null
	foreign key (TableID) references TableCoffee(ID)
)
go

create table BillInfo
(
	ID int identity primary key,
	BillID int not null,
	FoodID int not null,
	Amount int not null default 0
	
	foreign key (BillID) references Bill(ID),
	foreign key (FoodID) references Food(ID)
)
go

insert AccountType (TypeName) values (N'Manager')
insert AccountType (TypeName) values (N'Staff')

insert into Account (UserName, DisplayName, Password, TypeID)
values ('admin', 'Manager', 'admin', 1)
go

insert into Account(UserName, DisplayName, Password, TypeID)
values ('nhanh', 'Staff (Tài Nhanh)' ,'12345', 2)
go

insert into Account(UserName, DisplayName, Password, TypeID)
values ('anh', 'Staff (Trúc Anh)' ,'12345', 2)
go

insert into Account(UserName, DisplayName, Password, TypeID)
values ('tan', 'Staff (Minh Tân)' ,'12345', 2)
go

-- add information into TableCoffee
declare @i int = 1
while @i <= 30
begin
	insert into TableCoffee(Name)
	values (N'Table ' + CAST(@i as nvarchar(100)))
	set @i = @i + 1
end
go

-- add information into Category
insert into CategoryFood (Name) values (N'Cà phê')
insert into CategoryFood (Name) values (N'Ăn vặt')
insert into CategoryFood (Name) values (N'Thức uống khác')
insert into CategoryFood (Name) values (N'Nước ép trái cây')
insert into CategoryFood (Name) values (N'Trà sữa')
go

-- add information into Food
insert into Food (Name, CategoryID, Price) values (N'Cà phê đá', 1, 10000)
insert into Food (Name, CategoryID, Price) values (N'Cà phê sữa', 1, 12000)
insert into Food (Name, CategoryID, Price) values (N'Cà phê fin (đen)', 1, 8000)
insert into Food (Name, CategoryID, Price) values (N'Cà phê fin (sữa)', 1, 10000)
insert into Food (Name, CategoryID, Price) values (N'Mì cay', 2, 25000)
insert into Food (Name, CategoryID, Price) values (N'Sushi', 2, 15000)
insert into Food (Name, CategoryID, Price) values (N'Bò viên chiên', 2, 10000)
insert into Food (Name, CategoryID, Price) values (N'Xúc xích chiên', 2, 10000)
insert into Food (Name, CategoryID, Price) values (N'Ốc nhồi chiên', 2, 12000)
insert into Food (Name, CategoryID, Price) values (N'Há cảo chiên', 2, 15000)
insert into Food (Name, CategoryID, Price) values (N'7up', 3, 16000)
insert into Food (Name, CategoryID, Price) values (N'Sữa tươi', 3, 16000)
insert into Food (Name, CategoryID, Price) values (N'Sinh tố cam', 4, 14000)
insert into Food (Name, CategoryID, Price) values (N'Sinh tố dâu', 4, 10000)
insert into Food (Name, CategoryID, Price) values (N'Trà sữa truyền thống', 5, 18000)
insert into Food (Name, CategoryID, Price) values (N'Trà sữa Chocolate', 5, 22000)
insert into Food (Name, CategoryID, Price) values (N'Trà sữa Matcha', 5, 20000)
insert into Food (Name, CategoryID, Price) values (N'Trà sữa Việt quất', 5, 24000)
insert into Food (Name, CategoryID, Price) values (N'Capuchino', 5, 25000)
insert into Food (Name, CategoryID, Price) values (N'Macchiato', 5, 25000)
go

-- add information into Bill
insert into Bill (CheckIn, TableID) values (GETDATE(), 1)
insert into Bill (CheckIn, TableID) values (GETDATE(), 2)
insert into Bill (CheckIn, TableID) values (GETDATE(), 3)
go

-- add information into BillInfo
insert into BillInfo (BillID, FoodID, Amount) values (1, 1, 2)
insert into BillInfo (BillID, FoodID, Amount) values (1, 3, 3)
insert into BillInfo (BillID, FoodID, Amount) values (2, 2, 1)
insert into BillInfo (BillID, FoodID, Amount) values (3, 5, 1)
insert into BillInfo (BillID, FoodID, Amount) values (2, 4, 2)
GO

