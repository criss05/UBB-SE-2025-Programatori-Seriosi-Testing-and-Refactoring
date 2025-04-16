
drop table appointments

CREATE TABLE  appointments (
    id INT PRIMARY KEY IDENTITY(1,1),
    doctor_id INT foreign key references doctors(id),
    patient_id INT foreign key references patients(id),
    appointment_datetime DATETIME,
    location VARCHAR(255),
);

-- Insert Appointments
INSERT INTO appointments (doctor_id, patient_id, appointment_datetime, location)
VALUES (1, 2, '2025-05-01 14:30:00', 'Room A');
update appointments set id = 1 where id = 2

select * from appointments

delete appointments
where id = 4