CREATE DATABASE M_BookStore;

USE M_BookStore;

CREATE TABLE Generos
(
    IdGenero    INT PRIMARY KEY IDENTITY
    ,Descricao  VARCHAR(200) NOT NULL UNIQUE
);

CREATE TABLE Autores 
(
    IdAutor             INT PRIMARY KEY IDENTITY
    ,Nome               VARCHAR(200)
    ,Email              VARCHAR(255) UNIQUE
    ,Ativo              BIT DEFAULT(1) -- BIT/CHAR
    ,DataNascimento     DATE
);

CREATE TABLE Livros
(
    IdLivro             INT PRIMARY KEY IDENTITY
    ,Titulo             VARCHAR(255) NOT NULL UNIQUE
    ,IdAutor            INT FOREIGN KEY REFERENCES Autores (IdAutor)
    ,IdGenero           INT FOREIGN KEY REFERENCES Generos (IdGenero)
);


INSERT Autores(nome,Email,DataNascimento) VALUES ('J.K. Rowling','jk@harrypotter.com','1978-03-01'),('Mauricio de Souza','mauricio@kk.com','1958-12-26')

INSERT Autores(nome,Email,DataNascimento) VALUES (@Nome,@Email,@DataNascimento)

select * from autores
SELECT * FROM Generos

INSERT Generos(Descricao) VALUES ('Ficção'),('Drama'),('Suspense')


INSERT Livros(Titulo,IdAutor,IdGenero)
	VALUES ('Hery Pouter',1,1),('Turma da Monicakkkk',2,5)

SELECT * FROM autores WHERE Ativo = 1
UPDATE Autores
SET Ativo = 0
WHERE IdAutor = 3

SELECT L.IdLivro, L.Titulo, G.Descricao, A.Nome FROM Livros L JOIN Generos G ON G.IdGenero = L.IdGenero JOIN Autores A ON A.IdAutor = L.IdAutor

SELECT L.*, G.Descricao, A.Nome FROM Livros	 L JOIN Generos G ON G.IdGenero = L.IdGenero JOIN Autores A ON A.IdAutor = L.IdAutor WHERE A.Ativo = 1 AND L.Idlivro = @ID
UPDATE Livros SET Titulo = @Titulo WHERE IdLivro = @Id

DELETE FROM Livros WHERE IdLivro = @ID