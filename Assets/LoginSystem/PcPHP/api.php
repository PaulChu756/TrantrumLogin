<?php
include("connect.php");
$connect = connectDB();
$requestMethod = $_SERVER["REQUEST_METHOD"];

//get information
$resultSql = "SELECT * FROM Users";
$query = mysqli_query($connect, $resultSql) or die(mysqli_error($connect));
while($row = mysqli_fetch_array($query))
{
	echo " ID : " . $row['id'] . " : " . " Employee ID : " . $row['employeeID'] . " , Email : " . $row['email'] . " <br> ";
}
?>