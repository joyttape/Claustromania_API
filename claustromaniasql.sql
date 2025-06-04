CREATE DATABASE claustromania;
USE claustromania;

## DROP DATABASE claustromania;
# DROP TABLE IF EXISTS jogo;

CREATE TABLE sala (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Numero CHAR(10) NOT NULL,
    Capac_Jogadores INT NOT NULL,
    Status_Sala BOOLEAN NOT NULL
);

CREATE TABLE caixa (
    id CHAR(36) NOT NULL PRIMARY KEY, -- UUID em formato string
    data_hora_abertura DATETIME NOT NULL,
    data_hora_fechamento DATETIME,
    valor_inicial DECIMAL(10,2) NOT NULL,
    valor_final DECIMAL(10,2),
    total_transacoes DECIMAL(10,2),
    status VARCHAR(50), -- Ex: "Aberto", "Fechado", "Conferência pendente", etc.
    funcionario_nome VARCHAR(100), -- Nome do funcionário que abriu o caixa
    observacoes TEXT
);
CREATE TABLE caixa (
    id CHAR(36) NOT NULL PRIMARY KEY, -- UUID em formato string
    data_hora_abertura DATETIME NOT NULL,
    data_hora_fechamento DATETIME,
    valor_inicial DECIMAL(10,2) NOT NULL,
    valor_final DECIMAL(10,2),
    total_transacoes DECIMAL(10,2),
    status VARCHAR(50), -- Ex: "Aberto", "Fechado", "Conferência pendente", etc.
    funcionario_nome VARCHAR(100), -- Nome do funcionário que abriu o caixa
    observacoes TEXT
);

# Select * FROM funcionario;

CREATE TABLE unidade(
	Id INT AUTO_INCREMENT PRIMARY KEY,
    NomeUnidade VARCHAR(100) NOT NULL,
    Capacidade INT NOT NULL,
    Horario_Func VARCHAR(10) NOT NULL,
    Telefone VARCHAR(20) NOT NULL,
    Status_uni BOOLEAN NOT NULL DEFAULT TRUE
);

CREATE TABLE funcionario(
	Id INT AUTO_INCREMENT PRIMARY KEY,
    Cargo VARCHAR(50) NOT NULL,
    Salario DOUBLE(10,2) NOT NULL,
    Data_Contratacao VARCHAR(10) NOT NULL,
    Turno VARCHAR(20) NOT NULL
);

CREATE TABLE jogo (
    id INTEGER PRIMARY KEY NOT NULL AUTO_INCREMENT,
    nome VARCHAR(255) NOT NULL,
    descricao VARCHAR(100),
    duracao VARCHAR(15),
    dificuldade VARCHAR(50),
    preco DOUBLE(10, 2)
);

CREATE TABLE endereco (
    Id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    Logradouro CHAR(100),
    CEP CHAR(10),
    Cidade CHAR(50),
    Numero CHAR(10),
    Estado CHAR(50),
    Bairro CHAR(50),
    Complemento CHAR(100)
);
