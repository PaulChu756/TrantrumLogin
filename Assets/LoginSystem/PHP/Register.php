<?php
include("connect.php");
$connect = connectDB();

//post information
$employeeIDEnter = $_POST["employeeIDPost"];
$emailEnter = $_POST["emailPost"];

$userSql = "INSERT INTO Users (employeeID, email)
	        VALUES('".$employeeIDEnter."', '".$emailEnter."')";

$result = mysqli_query($connect ,$userSql);

if(!result) echo "there was an error";
else echo "Everything ok.";
?>