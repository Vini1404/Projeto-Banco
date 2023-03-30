create database dbProjetoBanco;

use dbProjetoBanco;

create table tbUsuario
(
	UsuId int primary key auto_increment,
	Nome varchar (50) not null,
	Cargo varchar (30) not null,
	Nasc datetime not null
);

select * from tbUsuario;
describe tbUsuario;

Insert into tbUsuario(Nome, Cargo, Nasc)values ('Teste', 'TEste', str_to_date('06/10/2022 00:00:00', '%d/%m/%Y'));

insert into tbUsuario values
(default, 'Leandro', 'Jornalista', '1994-04-24'),
(default, 'Francisca', 'Médica', '1990-05-22'),
(default, 'Luan', 'Escritor', '1944-01-11');

Insert into tbUsuario(Nome, Cargo, Nasc) values ('Teste', 'Cargão', '29/09/2022');

Insert into tbUsuario(Nome, Cargo, Nasc) values ('Franchesco', 'Camarada', str_to_date( '29/09/2022', '%d/%m/%Y' ));

Insert into tbUsuario(Nome, Cargo, Nasc)values ('Sandra', 'Professor', str_to_date('03/11/2022 00:00:00', '%d/%m/%Y % H:% i:% s'));

create user 'Maycon'@'localhost' identified with mysql_native_password by '12345678';
grant all privileges on dbProjetoBanco.* to 'Maycon'@'localhost' with grant option;
