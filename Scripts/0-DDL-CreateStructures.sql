CREATE TABLE aluno
(
	id INT IDENTITY,
	nome varchar(255),
	usuario varchar(45),
	senha char(60),
	ativo bit not null
	PRIMARY KEY(id)
)

CREATE TABLE turma
(
	id INT IDENTITY,
	curso_id INT,
	turma VARCHAR(45),
	ano INT,
	ativo bit not null
	PRIMARY KEY(id)
)

CREATE TABLE aluno_turma
(
	aluno_id INT,
	turma_id INT,
	ativo bit not null
	CONSTRAINT PK_aluno_turma PRIMARY KEY (aluno_id, turma_id),
	FOREIGN KEY (aluno_id) REFERENCES dbo.[aluno](id),
	FOREIGN KEY (turma_id) references dbo.[turma](id)
)



/*
DROP TABLE aluno_turma
DROP TABLE aluno
DROP TABLE turma
*/