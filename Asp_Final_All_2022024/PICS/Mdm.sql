use DB1782022
create table AllQuery
(
id int primary key identity,
Year varchar(50),
Data varchar(50),
 Topic varchar (50),
Upload_File varchar(100),
State varchar(50),
Details varchar(100),
)

create table fin_year
(
id int primary key identity,
fin_year varchar(50),
states varchar(10)
)
insert into fin_year values('2011-2012','Active')

create table pab_data_type
(
data_tpye_id int primary key identity,
data_type_name varchar(50),
states varchar(10)
)
insert into pab_data_type values('Other','Active')

create table state
(
statecode_id int primary key identity,
state_name varchar(50),
states varchar(10)
)
insert into state values('Dehradun','Active')

create table pab_topic
(
topic_id  int primary key identity,
topic_name varchar(50),
states varchar(10)
)
insert into pab_topic values('state ppt','Active')

select * from fin_year y  inner join AllQuery a
 on y.id=a.Year State

 select * from fin_year Year inner join AllQuery
   on Year.id=AllQuery.Year

--SELECT column names
--FROM table1
--LEFT JOIN table2
--ON table1.matching_column = table2.matching_column;

select * from AllQuery
select * from fin_year
select * from pab_data_type
select * from state
select * from pab_topic
select * from newuser1
select * from login
select * from Student
select * from Employeetable
select * from Register



--join one or more table
  select fin_year Year,data_type_name,state_name,topic_name,AllQuery.Upload_File,AllQuery.Details 
  from AllQuery inner join fin_year on fin_year.id=AllQuery.Year
  left join pab_data_type on pab_data_type.data_tpye_id=AllQuery.Data
  left join state on  state.statecode_id=CONVERT (int, AllQuery.State)
  left join pab_topic on pab_topic.topic_id=AllQuery.Topic

select  data_type_name Data  from AllQuery inner join pab_data_type on pab_data_type.data_tpye_id=AllQuery.Data
select state_name State from AllQuery  inner join state on  state.statecode_id=CONVERT (int, AllQuery.State)
select topic_name Topic from AllQuery inner join pab_topic on pab_topic.topic_id=AllQuery.Topic

	

	