create database locadora_M;
go

use locadora_M;
go

create table empresa(
	idEmpresa int primary key identity(1,1),
	nomeEmpresa varchar(20) not null unique
);

create table marca(
	idMarca int primary key identity(1,1),
	nomeMarca varchar(30) not null unique
);

create table modelo(
	idModelo int primary key identity(1,1),
	idMarca int foreign key references marca(idMarca),
	nomeModelo varchar(20) not null unique
);

create table veiculo(
	idVeiculo int primary key identity(1,1),
	idModelo int foreign key references modelo(idModelo),
	idMarca int foreign key references marca(idMarca),
	idEmpresa int foreign key references empresa(idEmpresa),
	placaVeiculo char(7) not null unique
);

create table cliente(
	idCliente int primary key identity(1,1),
	nomeCliente varchar(20) not null,
	cpfCliente char(11) not null unique
);

create table aluguel(
	idAluguel int primary key identity(1,1),
	idVeiculo int foreign key references veiculo(idVeiculo),
	idCliente int foreign key references cliente(idCliente),
	dataAluguel smalldatetime not null
);