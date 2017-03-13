<?php
//本程序用来处理登录页面提交过来的表单信息
session_start();//开启session
require_once '../connect.php';//包含数据库连接文件
header('content-type:text/html;charset=utf-8');
$username=$_POST["username"];
$passwd=md5($_POST["passwd"]);
$checkCode=$_POST["checkCode"];
$sql="select password from admin where username='".$username."'";
$result = mysql_query($sql);
$array = mysql_fetch_array($result);
//判断用户名是否为空
if($username=="")
{
	echo "<script>alert('用户名不能为空！');</script>";
	echo "<script>window.location='login.php';</script>";
}
//判断密码是否为空
if($_POST["passwd"]=="")
{
	echo "<script>alert('密码不能为空！');</script>";
	echo "<script>window.location='login.php';</script>";
}
//判断验证码是否为空
if($checkCode=="")
{
	echo "<script>alert('验证码不能为空！');</script>";
	echo "<script>window.location='login.php';</script>";
}
//验证登录密码和验证码是否正确
if($checkCode==$_SESSION['authcode'] && $passwd == $array['password'])
{
	//登录成功
	$_SESSION['id'] = $username;//保存登录的管理员id
	//跳转至文章管理页面（article.manage.php）
	echo "<script>window.location='article.manage.php';</script>";
}else{
	//登录失败，提示信息，并跳转至登录页面（login.php）
	echo "<script>alert('登录失败，请重新登录！');</script>";
	echo "<script>window.location='login.php';</script>";
}