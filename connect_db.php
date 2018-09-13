<?php 
 $server_name = "localhost";
 $user_name = "HNDSOFTSA15";
 $password = "wK35r5a96G";
 $db_name = "HNDSOFTSA15";

$link = mysqli_connect($server_name, $user_name, $password, $db_name);

if(mysqli_connect_errno())
{
	echo "Connection to DB error: " . mysqli_connect_errno();
}
?> 



