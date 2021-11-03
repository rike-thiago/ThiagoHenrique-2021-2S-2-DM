USE Rental_Manha
GO

INSERT INTO empresa (nomeEmpresa)
VALUES ('Movida'), ('Localiza')
GO

INSERT INTO marca (nomeMarca)
VALUES ('GM'), ('Ford'), ('Fiat')
GO

INSERT INTO modelo (idMarca, nomeModelo)
VALUES (1,'Onix'), (2,'Fiesta'), (3,'Argo')
GO

INSERT INTO veiculo (idModelo, idMarca, idEmpresa, placaVeiculo)
VALUES (3,3,2,'4444444'), (1,2,1,'5555555'), (2,1,1,'6666666')
GO

INSERT INTO cliente (nomeCliente, cpfCliente)
VALUES ('Saulo','77777777777'), ('Lucas','88888888888')
GO

INSERT INTO aluguel (idVeiculo, idCliente, dataAluguel)
VALUES (2,2,'2021-08-03'), (3,1,'2021-08-04'), (1,2,'2021-08-05')
GO