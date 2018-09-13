<?php
 $server_name = "localhost";
 $user_name = "root1";
 $password = "";
 $db_name = "haxadecimal";

$con = mysqli_connect($server_name, $user_name, $password, $db_name);

if(mysqli_connect_errno())
{
	echo "Connection to DB error: " . mysqli_connect_errno();
}
?>
