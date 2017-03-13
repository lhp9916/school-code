use php;
--创建管理员表
create table admin(
id int auto_increment primary key,
username varchar(10) not null unique,
password varchar(32) not null
);

--创建文章表
create table article(
id int auto_increment primary key,
title char(100) not null,
author char(50) not null,
description varchar(255) not null,
content text not null,
dateline int not null
);