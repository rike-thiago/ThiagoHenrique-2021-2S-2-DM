use optusMusic
go

insert into album (nomeAlbum, quantMusicas)
values ('astroworld','17'), ('back in black','10')

insert into estilo (nomeEstilo)
values ('rap'), ('rock')

insert into estiloDoAlbum (idEstilo, idAlbum)
values (1,1), (2,2)

insert into permissao (tipoPermissao)
values ('administrador'), ('comum')

insert into usuario (idPermissao, nomeUsuario, email, senha)
values (2,'Lucas','luqueta@email.com','777'), (2,'Saulo','saulove@email.com','888')

insert into artista (idEstiloDoAlbum, nomeArtista, idPermissao)
values (1,'Travis Scott',1), (2,'AC/DC',1)

insert into cadastro (idArtista, idUsuario)
values (1,NULL), (2,NULL), (NULL,1), (NULL,2)

insert into empresa (idCadastro)
values (1), (2), (3), (4)