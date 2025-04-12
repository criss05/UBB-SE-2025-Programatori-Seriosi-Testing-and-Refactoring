
drop table appointments

CREATE TABLE  appointments (
    id INT PRIMARY KEY,
    doctor_id INT foreign key references doctors(id),
    patient_id INT foreign key references patients(id),
    appointment_datetime DATETIME,
    location VARCHAR(255),
);

-- Insert Appointments
INSERT INTO appointments  VALUES
(1, 1, 1, '2025-04-01 10:00:00', 'Room 101'),
(2, 2, 2, '2025-04-06 11:30:00', 'Room 202'),
(3, 1, 2, '2025-04-05 11:30:00', 'Room 202')


select * from appointments

delete appointments
where id = 4