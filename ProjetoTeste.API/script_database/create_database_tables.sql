DROP SCHEMA `baseteste` ;
CREATE SCHEMA `baseteste` ;

use baseteste;

create table Categoria(
    idcategoria char(38) not null primary key,
    nome CHAR(30) NOT NULL,
    situacao boolean not null default 1
);

create table Produto(
    idproduto char(38) not null primary key,
    nome CHAR(30) NOT NULL,
    descricao CHAR(30) NOT NULL,
    idcategoria char(38) NOT NULL,
    preco double not null,
    situacao boolean not null default 1,
    FOREIGN KEY (idcategoria) REFERENCES Categoria(idcategoria)
)