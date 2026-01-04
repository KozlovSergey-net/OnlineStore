create database OnlineStor;
create table AppUser (
UserId serial primary key,
Email varchar(50),
Password varchar(100),
Salt varchar(50),
Status int
);