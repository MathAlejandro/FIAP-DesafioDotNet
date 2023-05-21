DECLARE @defaultPass VARCHAR(60) = '$2a$11$aUfF.vf8t9fHWz.uUaZmGuuAeEX.5uKKqOnBaPXAID.jQKohKqieu'

INSERT INTO aluno (nome, usuario, senha, ativo)
VALUES
('Matheus Leite', 'matheus.leite', @defaultPass, 1),
('Henrique Mendonça', 'henrique.mendonca', @defaultPass, 1),
('Douglas Cabral', 'douglas.cabral', @defaultPass, 1),
('Jose Augusto', 'jose.augusto', @defaultPass, 1)

INSERT INTO turma (curso_id, turma, ano, ativo)
VALUES
(1, '1ADS-A', 2023, 1),
(1, '1ADS-B', 2023, 1),
(1, '2ADS-A', 2022, 1),
(2, '1-ENG-A', 2023, 1)

INSERT INTO aluno_turma (aluno_id, turma_id, ativo)
VALUES
(1, 2, 1),
(2, 1, 1),
(3, 1, 1),
(4, 3, 1),
(4, 4, 1)




/**/