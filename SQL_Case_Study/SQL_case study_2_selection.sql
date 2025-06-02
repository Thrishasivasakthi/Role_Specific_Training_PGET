create database AutoAccessDB
use AutoAccessDB

--1

select * from customers order by first_name desc

--2

select first_name, last_name, city from customers order by city,first_name

--3

select top 3 * from products order by list_price desc

--4

select product_id,product_name,brand_id,category_id,model_year,list_price from products where list_price >= 300 and model_year = 2018

--5

select product_id,product_name,brand_id,category_id,model_year,list_price from products where list_price >= 300 or model_year = 2018

--6

select product_id,product_name,brand_id,category_id,model_year,list_price from products where list_price between 1899 and 1999.99

--7

select product_id,product_name,brand_id,category_id,model_year,list_price from products where list_price in (299.99,489.99,466.99)

--8

select * from customers where last_name LIKE 'A%' OR last_name LIKE 'B%' OR last_name LIKE 'C%';

--9

select * from customers where first_name not like 'A%'

--10

select state,city,count(*) as number_of_cust from customers group by state, city

--11

select customer_id, year(shipped_date) as year, count(*) as number_of_orders from orders group by customer_id,year(shipped_date)

--12

select category_id,max(list_price) as max_list_price,min(list_price) as min_list_price from products group by category_id having max(list_price) > 4000 or min(list_price) < 500

