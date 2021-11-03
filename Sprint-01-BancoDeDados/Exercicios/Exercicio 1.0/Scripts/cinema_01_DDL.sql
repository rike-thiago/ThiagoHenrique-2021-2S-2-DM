create database cinema
go

use cinema
go

create table tblGenero (
	idGenero tinyint primary key identity(1,1),
	nomeGenero varchar(30)
);
go

create table tblFilme (
	idFilme smallint primary key identity(1,1),
	idGenero tinyint foreign key references tblGenero(idGenero),
	tituloFilme varchar(70)
);
go