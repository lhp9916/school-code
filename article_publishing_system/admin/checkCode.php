<?php
//本程序用于生成验证码（字母加数字验证码），存放在$_SESSION['authcode']中
//开启session
session_start();

//生成100*30的白色底图
$image = imagecreatetruecolor(100, 30);
$bgcolor = imagecolorallocate($image, 255, 255, 255);
imagefill($image, 0, 0, $bgcolor);

$captch_code = "";//存放验证码
//生成随机字母数字
for($i=0;$i<4;$i++){
	$fontsize = 6;
	$fontcolor = imagecolorallocate($image, rand(0,120), rand(0,120), rand(0,120));
	$data = 'abcdefghijklmnopqrstuvwxyz3456789';
	$fontcontent = substr($data, rand(0,strlen($data)),1);
	$captch_code.=$fontcontent;
	$x = ($i*100/4)+rand(5, 10);
	$y = rand(5, 10);
	imagestring($image,$fontsize,$x,$y,$fontcontent,$fontcolor);
}
//将生成的随机验证码存放在$_SESSION['authcode']中
$_SESSION['authcode'] = $captch_code;

//下面添加干扰元素

//加点干扰
for($i=0;$i<200;$i++)
{
	$pointcolor = imagecolorallocate($image, rand(50,200),  rand(50,200),  rand(50,200));
	imagesetpixel($image, rand(1,99), rand(1,29), $pointcolor);
}
//加线干扰
for($i=0;$i<3;$i++)
{
	$linecolor = imagecolorallocate($image, rand(80,200), rand(80,200), rand(80,200));
	imageline($image, rand(1,99), rand(1, 29), rand(1,99), rand(1,29), $linecolor);
}

//将图片输出（png)
header('content-type:image/png');
imagepng($image);
imagedestroy($image);
?>