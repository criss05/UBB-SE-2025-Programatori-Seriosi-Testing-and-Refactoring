
create table users(
	id int primary key,
	name varchar(100),
	role varchar(100)
);


insert into users values (1,  'Stefan', 'admin'), (2, 'Paul', 'admin'),(3, 'Bogdan', 'medic'),(4, 'Maria', 'medic'),(5, 'Filip', 'patient'), (6, 'Cata', 'patient')