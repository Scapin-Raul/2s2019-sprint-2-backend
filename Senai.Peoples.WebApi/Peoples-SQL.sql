CREATE DATABASE M_Peoples

USE M_PEOPLES


CREATE TABLE Funcionarios(
	IdFuncionario INT IDENTITY PRIMARY KEY,
	Nome VARCHAR(200),
	Sobrenome VARCHAR(200)
)
ALTER TABLE Funcionarios
ADD DataNascimento DATE;

INSERT Funcionarios(Nome,Sobrenome)
	VALUES('Catarina','Strada'),('Tadeu','Vitelli')

	INSERT INTO Funcionarios(Nome,Sobrenome) VALUES ('kkk','jjj')


SELECT * FROM Funcionarios 
WHERE IdFuncionario = 1


SELECT IdFuncionario, (Nome +' '+Sobrenome) AS 'Nome completo'
FROM Funcionarios

UPDATE Funcionarios SET Nome = 'Xesque' WHERE Idfuncionario = 4 UPDATE Funcionarios Set Sobrenome = 'Dele' WHERE IdFuncionario = 4

UPDATE Funcionarios SET DataNascimento = '01.02.1998'

DELETE Funcionarios
WHERE IdFuncionario = 5

INSERT INTO Funcionarios(Nome,Sobrenome,DataNascimento) VALUES ('kkkkkk','jjjjjjj','2019-03-12')


SELECT * FROM Funcionarios WHERE Nome LIKE '%cata%'

SELECT * FROM Funcionarios ORDER BY Nome DESC