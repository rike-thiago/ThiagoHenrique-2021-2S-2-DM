USE INLOCK_MANHA_TT
GO

--Listar todos os USUÁRIOS
SELECT * FROM usuario
GO


--Listar todos os ESTÚDIOS
SELECT * FROM estudio
GO


--Listar todos os JOGOS
SELECT * FROM jogo
GO

--Listar todos os Tipos de Usuários
SELECT * FROM tipoUsuario
GO


--Listar todos os JOGOS e seus respectivos ESTÚDIOS
SELECT idJogo, nomeJogo, descricao, dataLancamento, valor, estudio.idEstudio, nomeEstudio FROM jogo
LEFT JOIN estudio
ON jogo.idEstudio = estudio.idEstudio
GO


--Buscar e trazer na lista todos os ESTÚDIOS com os respectivos JOGOS
--Obs.: Listar todos os ESTÚDIOS mesmo que eles não contenham nenhum JOGO de referência
SELECT estudio.idEstudio, nomeEstudio, idJogo, nomeJogo, descricao, dataLancamento, valor FROM estudio
LEFT JOIN jogo
ON estudio.idEstudio = jogo.idEstudio
GO


--Buscar um usuário por e-mail e senha (login)
SELECT * FROM usuario
WHERE email = 'admin@admin.com' AND senha = 'admin'

SELECT * FROM usuario
WHERE email = 'cliente@cliente.com' AND senha = 'cliente'
GO


--Buscar um jogo por idJogo;
SELECT * FROM jogo
WHERE idJogo = 1

SELECT * FROM jogo
WHERE idJogo = 2
GO


--Buscar um estúdio por idEstudio;
SELECT * FROM estudio
WHERE idEstudio = 1

SELECT * FROM estudio
WHERE idEstudio = 2

SELECT * FROM estudio
WHERE idEstudio = 3
GO

SELECT nomeEstudio, idEstudio FROM estudio 
WHERE idEstudio = 1
/*                |
                  |
				  |
             @idEstudio
*/

SELECT * FROM jogo

--UPDATE usuario SET idTipoUsuario = @novoIdTipoUsuario, email = @novoEmail, nomeUsuario = @novoNomeUsuario, senha = @novaSenha WHERE idUsuario = @idUsuarioAtualizado"

SELECT  idUsuario, idTipoUsuario, email, senha FROM usuario WHERE email  = @email AND senha = @senha