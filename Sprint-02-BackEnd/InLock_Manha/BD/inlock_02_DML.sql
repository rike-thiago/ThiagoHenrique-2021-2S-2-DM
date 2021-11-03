USE INLOCK_MANHA_TT
GO

INSERT INTO estudio (nomeEstudio)
VALUES ('Blizzard'), ('Rockstar Studios'), ('Square Enix')
GO

INSERT INTO jogo (idEstudio, nomeJogo, descricao, dataLancamento, valor)
VALUES (1,'Diablo 3','é um jogo que contém bastante ação e é viciante, seja você um novato ou um fã.','2012-05-15','99.00'), 
(2,'Red Dead Redemption II','jogo eletrônico de ação-aventura western.','2018-10-26','120.00')
GO

INSERT INTO tipoUsuario (titulo)
VALUES ('Administrador'), ('Cliente')
GO

INSERT INTO usuario (idTipoUsuario, nomeUsuario, email, senha)
VALUES (1,'A.Saulo','admin@admin.com','admin'), (2,'C.Lucas','cliente@cliente.com','cliente')
GO