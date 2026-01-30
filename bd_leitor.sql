create table controlador(
id_cont int not null auto_increment,
cartao_id_cont varchar(50) not null,
data_cont datetime not null default current_timestamp,
status_cont varchar(10) not null default 'error',
primary key(id_cont)
);