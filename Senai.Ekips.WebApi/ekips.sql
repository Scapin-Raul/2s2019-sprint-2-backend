CREATE DATABASE M_Ekips

USE M_EKIPS


CREATE TABLE Cargos(
	IdCargo INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(200) UNIQUE,
	Ativo BIT
	)

CREATE TABLE Departamentos(
	IdDepartamento INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(200) UNIQUE
)

CREATE TABLE Usuarios(
	IdUsuario INT PRIMARY KEY IDENTITY,
	Email VARCHAR(200) UNIQUE,
	Senha VARCHAR(200),
	Permissao VARCHAR(200)
)


CREATE TABLE Funcionarios(
	IdFuncionario INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(200),
	Cpf BIGINT UNIQUE,
	DataNascimento DATE,
	Salario INT,
	IdDepartamento INT FOREIGN KEY REFERENCES Departamentos(IdDepartamento),
	IdCargo INT FOREIGN KEY REFERENCES Cargos(IdCargo),
	IdUsuario INT FOREIGN KEY REFERENCES Usuarios(IdUsuario)
)



INSERT Departamentos(Nome)
	VALUES('Jurídico'),('Tecnologia')

INSERT Cargos(Nome,Ativo)
	VALUES('Advogado Trabalhista',1),('Product Owner',1)

	select * from cargos
	select * from Departamentos
	select * from usuarios
	SELECT * FROM Funcionarios

insert usuarios(Email,Senha,Permissao)
	values('bob@email.com','123456','COMUM'),('fernando@email.com','123456','COMUM'),('admin@email.com','123456','ADMINISTRADOR')


INSERT Funcionarios(Nome,cpf,DataNascimento,Salario,IdDepartamento,IdCargo,IdUsuario)
	VALUES('Bob',111111,'1975-03-20',4000,1,1,1),('Fernando',222222,'1969-12-12',7000,2,2,2)


	SELECT F.IdFuncionario, F.Nome, U.Email, F.CPF, F.Salario, D.Nome, C.Nome
	FROM Funcionarios F
	FULL JOIN Departamentos D ON D.IdDepartamento = F.IdDepartamento
	FULL JOIN Cargos C ON C.IdCargo = F.IdCargo
	full JOIN Usuarios U ON U.IdUsuario = F.IdUsuario
	