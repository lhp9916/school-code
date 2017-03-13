<?php
	//本程序用于处理article.manage.php提交过来的删除请求
	//包含数据库连接文件
	require_once('../connect.php');
	//获取表单中要删除的文章的id
	$id = $_GET['id'];
	$deletesql = "delete from article where id=$id";
	//执行sql语句
	if(mysql_query($deletesql)){
		//执行成功，提示信息，页面跳转至article.manage.php
		echo "<script>alert('删除文章成功');window.location.href='article.manage.php';</script>";
	}else{
		//执行失败，提示信息，页面跳转至article.manage.php
		echo "<script>alert('删除文章失败');window.location.href='article.manage.php';</script>";
	}
?>