CREATE DATABASE mercadoPago;
GO

USE mercadoPago;
GO

create table pessoa(
	idPessoa int primary key identity(1,1),
	nomePessoa varchar(20) not null unique
);
go

create table telefone(
	idTelefone int primary key identity(1,1),
	idPessoa int foreign key references pessoa(idPessoa),
	numeroTelefone char(11) not null 
);
GO

create table email(
	idEmail int primary key identity(1,1),
	idPessoa int foreign key references pessoa(idPessoa),
	endEmail varchar(256) not null unique
);
GO

create table cnh(
	idCnh int primary key identity(1,1),
	idPessoa int foreign key references pessoa(idPessoa),
	descricao char(11) not null unique
);
GO