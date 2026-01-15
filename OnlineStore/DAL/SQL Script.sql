create database OnlineStor;
create table AppUser (
UserId serial primary key,
Email varchar(50),
Password varchar(100),
Salt varchar(50),
Status int
);

INSERT INTO appuser ( email, password, status)
VALUES ('man@man.ru' , '12345', 1);

