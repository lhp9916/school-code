<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>管理员登录</title>
</head>
<style type="text/css">
#content{
	margin:20px auto auto auto;
	width:600px;
	height:auto;
	text-align:center;
}
#loginBox{
	margin:10px auto auto auto;
	height:auto;
	width:400px;
	text-align:left;
	font-size:18px;
}
#imageCode{
	height:30px;
	width:100px;
	border:#000 solid 1px;
}
form{
	line-height:2;
}
</style>
<body>
<div id="content">
	<h1>欢迎登录本系统</h1>
    <div id="loginBox">
    <form action="doLogin.php" method="post">
    <p>用户名：<input type="text" name="username" /></p>
    <p>密 码： <input type="password" name="passwd" /></p>
    <p>验证码：<img id="imageCode" src="checkCode.php" />
    <a href="javascript:void(0)" 
		onclick="document.getElementById('imageCode').src='checkCode.php'">换一张</a>
    </p>
    <p>请输入验证码：<input type="text" name="checkCode" /></p>
    <input type="submit" value="提交" />
    <input type="reset" value="重置" />
    </form>
    </div>
</div>
</body>
</html>