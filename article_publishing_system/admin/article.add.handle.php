<?php
	//本程序用来处理文章发布表单提交过来的
	//包含数据库连接文件
	require_once('../connect.php');
	//把传递过来的信息入库,在入库之前对所有的信息进行校验。
	if($_POST['title']==""){
		echo "<script>alert('标题不能为空');</script>";
		echo "<script>window.location='article.add.php';</script>";
		exit();
	}
	$title = $_POST['title'];
	$author = $_POST['author'];
	$description = $_POST['description'];
	$content = $_POST['content'];
	$dateline =  time();
	$insertsql = "insert into article(title, author, description, content, dateline) values('$title', '$author', '$description', '$content', $dateline)";
	if(mysql_query($insertsql)){
		echo "<script>alert('发布文章成功');window.location.href='article.manage.php';</script>";
	}else{
		echo "<script>alert('发布失败');window.location.href='article.manage.php';</script>";
	}
?>