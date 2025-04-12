create table reviews(
	id int primary key,
	medicalrecord_id int foreign key references medicalrecords(id),
	message varchar(256),
	nrstars int
	)


	insert into reviews values(1,1)



	create table chats(
		id int primary key,
		user1 int,
		user2 int
		)