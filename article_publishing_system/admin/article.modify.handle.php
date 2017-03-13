<?php 
	//本程序用于处理article.modify.php提交过来的文章修改请求
	require_once('../connect.php');
	$id = $_POST['id'];
	$title = $_POST['title'];
	$author = $_POST['author'];
	$description = $_POST['description'];
	$content = $_POST['content'];
	$dateline =  time();
	$updatesql = "update article set title='$title',author='$author',description='$description',content='$content',dateline=$dateline where id=$id";
	//执行update语句
	if(mysql_query($updatesql)){
		//更新成功，提示信息，页面调转至article.manage.php
		echo "<script>alert('修改文章成功');window.location.href='article.manage.php';</script>";
	}else{
		//更新失败，提示修改文章失败，页面调转至article.manage.php
		echo "<script>alert('修改文章失败');window.location.href='article.manage.php';</script>";
	}
?>