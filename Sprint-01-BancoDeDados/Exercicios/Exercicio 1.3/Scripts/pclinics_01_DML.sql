use pclinics
go

insert into clinica (nomeClinica, endClinica)
values ('Pet Vet','rua Tamarindo, 21'), ('Pet Supremo','rua Angelina, 74'), ('Santa Luzia','rua Marcolina, 13')

insert into especie (nomeEspecie)
values ('cachorro'), ('gato')

insert into raca (nomeRaca, idEspecie)
values ('poodle',1), ('pinscher',1), ('persa',2)

insert into dono (nomeDono)
values ('Darcy'), ('José'), ('Pedrin')

insert into pet (nomePet, dataNasc, idEspecie, idRaca, idDono)
values ('Cleber','2005-03-29',1,2,2), ('Josenildo','2005-03-30',2,3,3), ('Jurema','2005-03-31',1,1,1)

insert into veterinario (nomeVeterinario, idClinica)
values ('Saulo',2), ('Lucas',3), ('Thiago',1)

insert into atendimento (idClinica, idVeterinario, idPet, dataAtendimento)
values(2,2,1,'04-08-2021 11:10'), (1,3,2,'05-08-2021 11:11'), (3,1,3,'06-08-2021 11:12')

delete from atendimento
where idAtendimento in(1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16)







select * from clinica

select * from especie

select * from raca

select * from dono

select * from pet

select * from veterinario

select * from atendimento