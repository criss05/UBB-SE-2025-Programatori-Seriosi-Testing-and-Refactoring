CREATE TABLE doctors (
    id INT PRIMARY KEY,
    user_id int foreign key references users(id)
);

CREATE TABLE patients (
    id INT PRIMARY KEY  IDENTITY(1,1),
	user_id int foreign key references users(id)
);

drop table Patients


insert into doctors values(1,3), (2,4)

insert into patients values(5), (6)