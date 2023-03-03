use STUDENT_MARKS;

CREATE TABLE STUDENT(
 StudentId INT not null auto_increment  ,
 StudentFirstName varchar(20) not null,
 StudentLastName varchar(20) not null,
 primary key(StudentId)
);

CREATE TABLE SCORECARD
(
StudentId INT NOT NULL ,
Subject1 INT check( Subject1>=0 and Subject1<=100),
Subject2 INT check( Subject2>=0 and Subject2<=100),
Subject3 INT check( Subject3>=0 and Subject3<=100),
Subject4 INT check( Subject4>=0 and Subject4<=100),
Total INT as (Subject1+Subject2+Subject3+Subject4),
FOREIGN KEY (StudentID) REFERENCES STUDENT(StudentID)
);