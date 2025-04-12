create table notifications(
	id int primary key identity(1,1),
	user_id int foreign key references users(id),
	delivery_datetime datetime,
	message varchar(256)
)

INSERT INTO notifications (user_id, delivery_datetime, message) VALUES
(5, '2025-03-31 10:00:00', 'Tomorrow 2025-04-01 10:00:00, you have an appointment with Dr. Bogdan at location City Clinic.'),
(6, '2025-04-05 11:30:00', 'Tomorrow 2025-04-06 11:30:00, you have an appointment with Dr. Maria at location City Clinic.'),
(5, '2025-04-04 11:30:00', 'Tomorrow 2025-04-05 11:30:00, you have an appointment with Dr. Bogdan at location City Clinic.')



select * from notifications

create table appointment_notifications(
	id int primary key identity(1,1),
	notification_id int foreign key references notifications(id) on delete cascade,
	appointment_id int foreign key references appointments(id)

)


insert into appointment_notifications values (12, 1), (13, 2), (14, 3)

delete notifications
where id = 16