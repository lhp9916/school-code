<?php
//文章管理主页
    session_start ();//开启session
    //判断管理员是否登录，若未登录则跳转到登录页面
    if($_SESSION['id']=="")
    {
    	echo "<script>alert('请先登录！');</script>";
    	echo "<script>window.location='login.php';</script>";
    }
	require_once('../connect.php');//包含数据连接文件
	$sql = "select * from article order by dateline desc";
	$query  = mysql_query($sql);
	if($query&&mysql_num_rows($query)){
		while($row =mysql_fetch_assoc($query)){
			$data[] = $row;
		}
	}else{
		$data = array();
	}

?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>文章管理主页</title>
<style type="text/css">
body {
	margin-left: 0px;
	margin-top: 0px;
	margin-right: 0px;
	margin-bottom: 0px;
}
</style>
</head>

<body>
	<table width="100%" height="520" border="0" cellpadding="8"
		cellspacing="1" bgcolor="#000000">
		<tr>
			<td height="89" colspan="2" bgcolor="#FFFF99"><strong>后台管理系统</strong></td>
		</tr>
		<tr>
			<td width="156" height="287" align="left" valign="top"
				bgcolor="#FFFF99"><p>
					<a href="article.add.php">发布文章</a>
				</p>
				<p>
					<a href="article.manage.php">管理文章</a>
				</p></td>
			<td width="837" valign="top" bgcolor="#FFFFFF"><table width="743"
					border="0" cellpadding="8" cellspacing="1" bgcolor="#000000">
					<tr>
						<td colspan="3" align="center" bgcolor="#FFFFFF">文章管理列表</td>
					</tr>
					<tr>
						<td width="37" bgcolor="#FFFFFF">编号</td>
						<td width="572" bgcolor="#FFFFFF">标题</td>
						<td width="82" bgcolor="#FFFFFF">操作</td>
					</tr>
	<?php 
		if(!empty($data)){
			foreach($data as $value){
	?>
      <tr>
						<td bgcolor="#FFFFFF">&nbsp;<?php echo $value['id']?></td>
						<td bgcolor="#FFFFFF">&nbsp;<?php echo $value['title']?></td>
						<td bgcolor="#FFFFFF">
						    <!-- 提交到文章删除处理页面（article.del.handle.php）  -->
						    <a href="article.del.handle.php?id=<?php echo $value['id']?>">删除</a>
						    <!-- 提交到文章修改处理页面（article.modify.php）  -->
							<a href="article.modify.php?id=<?php echo $value['id']?>">修改</a></td>
					</tr>
        <?php
        		}
		}
        ?>
    </table></td>
		</tr>
		<tr>
			<td colspan="2" bgcolor="#FFFF99"><strong>版权所有</strong></td>
		</tr>
	</table>
</body>
</html>
