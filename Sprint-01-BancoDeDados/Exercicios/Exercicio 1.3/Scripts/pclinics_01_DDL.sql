create database pclinics;
go

use pclinics;
go

create table clinica(
	idClinica int primary key identity(1,1),
	nomeClinica varchar(30) not null unique,
	endClinica varchar(30) not null
);

create table especie(
	idEspecie int primary key identity(1,1),
	nomeEspecie varchar(30) not null unique
);

create table raca(
	idRaca int primary key identity(1,1),
	idEspecie int foreign key references especie(idEspecie),
	nomeRaca varchar(30) not null unique
);

create table dono(
	idDono int primary key identity(1,1),
	nomeDono varchar(30) not null
);

create table pet(
	idPet int primary key identity(1,1),
	idEspecie int foreign key references especie(idEspecie),
	idRaca int foreign key references raca(idRaca),
	idDono int foreign key references dono(idDono),
	nomePet varchar(30) not null,
	dataNasc date not null
);

create table veterinario(
	idVeterinario int primary key identity(1,1),
	idClinica int foreign key references clinica(idClinica),
	nomeVeterinario varchar(30) not null
);

create table atendimento(
	idAtendimento int primary key identity(1,1),
	idClinica int foreign key references clinica(idClinica),
	idVeterinario int foreign key references veterinario(idVeterinario),
	idPet int foreign key references pet(idPet),
	dataAtendimento datetime not null
);

drop table atendimento