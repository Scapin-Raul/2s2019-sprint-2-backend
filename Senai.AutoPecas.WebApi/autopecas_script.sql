CREATE DATABASE M_AutoPecas

USE M_AUTOPECAS


CREATE TABLE Usuarios(
	IdUsuario INT PRIMARY KEY IDENTITY,
	Email VARCHAR(200) UNIQUE,
	Senha VARCHAR(200) DEFAULT '123456'
)
drop table usuarios

CREATE TABLE Fornecedores(
	IdFornecedor INT PRIMARY KEY IDENTITY,
	Cnpj INT UNIQUE,
	RazaoSocial VARCHAR(200),
	NomeFantasia VARCHAR(200),
	Endereco VARCHAR(200),
	IdUsuario INT FOREIGN KEY REFERENCES Usuarios(IdUsuario)
)

CREATE TABLE Pecas(
	IdPeca INT PRIMARY KEY IDENTITY,
	Codigo VARCHAR(200) UNIQUE,
	Descricao VARCHAR(200),
	Peso INT,
	PrecoCusto INT,
	PrecoVenda INT,
	IdFornecedor INT FOREIGN KEY REFERENCES Fornecedores(IdFornecedor)
)

SELECT * FROM Pecas
SELECT * FROM Fornecedores
SELECT * FROM Usuarios


INSERT Usuarios(Email)
	VALUES('comum@email.com'),('qisso@email.com')


INSERT Fornecedores(Cnpj,RazaoSocial,NomeFantasia,Endereco,IdUsuario)
	VALUES(11111,'Coca cola company','Coca-Cola','Rua kk 123',2),(22222,'Habiber Company','Habibs Comidinhas','Rua kk 122',3)
