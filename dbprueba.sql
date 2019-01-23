create tabla categoria (
  id serial primary key,
  nombre varchar(50) not null unique
);

insert into categoria (nombre) values ('categoria 1');
insert into categoria (nombre) values ('categoria 2');
insert into categoria (nombre) values ('categoria 3');

create table cliente (
	id serial primary key,
	nombre varchar(50) not null unique
);

insert into cliente (nombre) values ('cliente 1');
insert into cliente (nombre) values ('cliente 2');
insert into cliente (nombre) values ('cliente 3');

create table pedido (
	id serial primary key,
	fecha ??? not null unique,
	cliente bigint unsigned,
	importe numeric(10,2) not null
);

alter table pedido add foreign key (cliente) references cliente (id);

create table pedidolinea (
	id serial primary key,
	pedido bigint unsigned,
	articulo bigint unsigned,
	precio numeric(10,2) not null,
	unidades numeric(10,2) not null,
	importe numeric(10,2) not null
);

alter table pedidolinea add foreign key (pedido) references pedido (id) on delete cascade;
alter table pedidolinea add foreign key (articulo) references articulo (id); 

