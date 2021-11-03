create database optusMusic
go

use optusMusic
go

create table album(
	idAlbum int primary key identity(1,1),
	nomeAlbum varchar(30) not null unique,
	quantMusicas tinyint not null
);

create table estilo(
	idEstilo int primary key identity(1,1),
	nomeEstilo varchar(20) not null unique
);

create table estiloDoAlbum(
	idEstiloDoAlbum int primary key identity(1,1),
	idEstilo int foreign key references estilo(idEstilo),
	idAlbum int foreign key references album(idAlbum)
);

create table permissao(
	idPermissao int primary key identity(1,1),
	tipoPermissao varchar(13) not null unique
);

create table usuario(
	idUsuario int primary key identity(1,1),
	idPermissao int foreign key references permissao(idPermissao),
	nomeUsuario varchar(20) not null unique,
	email varchar(30) not null unique,
	senha varchar(16) not null
);

create table artista(
	idArtista int primary key identity(1,1),
	idEstiloDoAlbum int foreign key references estiloDoAlbum(idEstiloDoAlbum),
	idPermissao int foreign key references permissao(idPermissao),
	nomeArtista varchar(20) not null unique
);

create table cadastro(
	idCadastro int primary key identity(1,1),
	idArtista int foreign key references artista(idArtista),
	idUsuario int foreign key references usuario(idUsuario)
);

create table empresa(
	idEmpresa int primary key identity(1,1),
	idCadastro int foreign key references cadastro(idCadastro)
);