USE LOCADORA
GO

insert into empresa (nomeEmpresa)
values ('movida'), ('localiza')

insert into cliente (nomeCliente, cpfCliente)
values ('Saulo', '777'), ('Lucas', '888')

insert into marca (nomeMarca)
values ('gm'), ('ford'), ('fiat')

insert into modelo (nomeModelo, idMarca)
values ('onix','1'), ('fiesta','2'), ('argo','3')

insert into veiculo (placaVeiculo, idModelo, idMarca, idEmpresa)
values ('444','3','3','2'), ('555','1','2','1'), ('666','2','1','1')

insert into aluguel (idVeiculo, dataAluguel, idCliente)
values ('2','2021-08-03 10:33',5), ('3','2021-08-04 10:34',4), ('1','2021-08-05 10:35',5)