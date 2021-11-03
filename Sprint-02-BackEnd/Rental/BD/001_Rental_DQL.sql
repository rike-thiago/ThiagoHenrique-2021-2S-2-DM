USE Rental_Manha
GO

SELECT * FROM empresa
GO

SELECT * FROM marca
GO

SELECT * FROM modelo
GO

SELECT * FROM veiculo
GO

SELECT * FROM cliente
GO

SELECT * FROM aluguel
GO

SELECT idAluguel, cliente.idCliente, nomeCliente, cpfCliente, veiculo.idVeiculo, empresa.idEmpresa, nomeEmpresa, placaVeiculo, dataAluguel 
FROM aluguel 
INNER JOIN cliente ON cliente.idCliente = aluguel.idCliente 
INNER JOIN veiculo ON veiculo.idVeiculo = aluguel.idVeiculo 
INNER JOIN empresa ON veiculo.idEmpresa = empresa.idEmpresa 
WHERE idAluguel = 1



SELECT idVeiculo, isnull(idModelo,0)idModelo, isnull(idMarca,0)idMarca, empresa.idEmpresa, nomeEmpresa, placaVeiculo FROM veiculo INNER JOIN empresa ON veiculo.idEmpresa = empresa.idEmpresa WHERE idVeiculo = 4
SELECT idVeiculo, isnull(veiculo.idModelo,0)idModelo, isnull(veiculo.idMarca,0)idMarca, nomeModelo, nomeMarca, empresa.idEmpresa, nomeEmpresa, placaVeiculo FROM veiculo INNER JOIN modelo ON veiculo.idModelo = modelo.idModelo INNER JOIN marca ON veiculo.idMarca = marca.idMarca INNER JOIN empresa ON veiculo.idEmpresa = empresa.idEmpresa WHERE idVeiculo = 5