
create table medicalrecords(
	id int primary key,
	doctor_id int foreign key references doctors(id),
	patient_id int foreign key references patients(id),
	medicalrecord_datetime datetime
	)


create table treatments(
	id int primary key,
	medicalrecord_id int foreign key references medicalrecords(id),
	)


create table drugs(
	id int primary key,
	name varchar(100),
	description varchar(256)
	)


create table treatments_drugs(
	id int primary key,
	treatment_id int foreign key references treatments(id),
	drug_id int foreign key references drugs(id),
	quantity decimal(10,2),
	starttime time,
	endtime time,
	startdate date,
	nrdays int
	)
