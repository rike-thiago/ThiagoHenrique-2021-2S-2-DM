insert into pessoa (nomePessoa)
values ('Lucas'), ('Saulo'), ('Thiago')

insert into cnh (idPessoa,descricao)
values (2,'777'), (1,'888'), (3,'999')

insert into telefone (idPessoa,numeroTelefone)
values (3,'333'), (2,'444'), (1,'555')

insert into email (idPessoa,endEmail)
values (1,'luqueta@email.com'), (3,'saulove@email.com'), (2,'thiaguito@email.com')

delete from telefone
where idTelefone in(4,5,6)