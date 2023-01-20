
/*Ususario: root - Password:root*/
create database sisvent;
use sisvent;

create table organizacion(
	id_organizacion int not null auto_increment primary key,
    descripcion varchar(70),
    mision varchar(70),
    vision varchar(70),
    valores varchar(70)
);

create table personal(
	id_personal int not null auto_increment primary key,
    identificacion varchar(12) unique,
    nombres varchar(70),
    apellidos varchar(70),
    direccion varchar(70),
    telefono varchar(70)
);

create table productos(
	id_productos int not null auto_increment primary key,
    nombre varchar(70),
    codigo varchar(5) unique,
    descripcion varchar(70)
);

create table mensajes(
	id_mensajes int not null auto_increment primary key,
    remitente varchar(70),
    telefono varchar(70),
    asunto varchar(70),
    cuerpo varchar(250)
);
