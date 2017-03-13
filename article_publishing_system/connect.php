<?php
	//包含配置文件
	require_once('config.php');
	//连接数据库
	if(!($con = mysql_connect(HOST, USERNAME, PASSWORD))){
		echo mysql_error();
	}
	//选择数据库，本系统用到的数据库名称为php
	if(!mysql_select_db('php')){
		echo mysql_error();
	}
	//设置字符集
	if(!mysql_query('set names utf8')){
		echo mysql_error();
	}
?>