create table Categoria 
(
id int identity,
Nome varchar(50) not null,
constraint PK_id primary key(id))

create table Produto 
(
id int identity,
Data datetime,
DataAlteracao datetime,
Produto  varchar(100) not null,
Quant varchar(50),
precoUnt float not null,
precoTotal float,
constraint PK_idProdutoid primary key(id))

create table Vendas 
(
id int identity,
Data datetime,
DataAlteracao datetime,
Produtoid   int,
Cliente varchar(100),
Quant varchar(50),
precoUnt float not null,
precoTotal float,
constraint PK_idVendas primary key(id),
constraint FK_id FOREIGN KEY (Produtoid) REFERENCES Categoria (id));


create table Pago(
id int primary key identity,
descricao varchar(30)
)