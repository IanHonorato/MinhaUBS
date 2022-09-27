Create table unidade

(
    id_unidade serial primary key,
    nome varchar(200),
   	endereco varchar(100),
	localizacao varchar(50),
	horario_funcionamento varchar(200),
	ativa bool
)

Create table vacina

(
    id_vacina serial primary key,
    nome varchar(200)
)

Create table funcionario
(
    id_funcionario serial primary key,
	id_unidade int not null,
    nome varchar(200),
   	login varchar(100),
	senha varchar(50),
	especialidade varchar(50),
	FOREIGN KEY (id_unidade) REFERENCES unidade (id_unidade)
)

Create table servicos
(
    id_servicos serial primary key,
    nome varchar(50)
)

Create table unidade_vacina
(
    id_unidade int not null,
	id_vacina int not null,
    disponivel bool,
	FOREIGN KEY (id_unidade) REFERENCES unidade (id_unidade),
	FOREIGN KEY (id_vacina) REFERENCES vacina (id_vacina)
)

Create table unidade_servico

(
    id_unidade int not null,
	id_servicos int not null,
    disponivel bool,
	FOREIGN KEY (id_unidade) REFERENCES unidade (id_unidade),
	FOREIGN KEY (id_servicos) REFERENCES servicos (id_servicos)
)

