use AUS
select * from Final_Table

select * from tbl_Country
select * from tbl_state
select * from tbl_City
truncate table Final_Table

alter procedure SP_ALL_CURD
@id int=0,
@Name varchar(225) =null,
@Country varchar(225) =null,
@State varchar(225)=null,
@City varchar(225)=null,
@Gender varchar(225)=null,
@Hobbies varchar(225)=null,
@Image_Upload varchar(225)=null,
@Action varchar(25)

as
begin
if(@Action='Insert')
begin
Insert into Final_Table values(@Name,@Country,@State,@City,@Gender,@Hobbies,@Image_Upload)
end

else if(@Action='ShowData')
begin
select * from Final_Table join tbl_country on Final_Table.country=tbl_country.country_id join tbl_state on Final_Table.state=tbl_state.state_id join tbl_city on Final_Table.city=tbl_city.city_id
end

else if(@Action='Edit')
begin
select * from Final_Table where id=@id
end


else if(@Action='Delete')
begin
delete  from Final_Table where id=@id
end

else if(@Action='Update')
begin
update  Final_Table set Name=@Name,Country=@Country,State=@State,City=@City,Gender=@Gender,Hobbies=@Hobbies,Image_Upload=@Image_Upload where id=@id
end

end



