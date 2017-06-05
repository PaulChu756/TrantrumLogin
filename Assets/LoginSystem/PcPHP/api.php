<?php
include("connect.php");
$connect = connectDB();
$requestMethod = $_SERVER["REQUEST_METHOD"];

//get information
$resultSql = "SELECT * FROM Users";
$query = mysqli_query($connect, $resultSql) or die(mysqli_error($connect));
while($row = mysqli_fetch_array($query))
{
	echo " Employee ID : " . $row['employeeID'] . " , Email : " . $row['email'] . " <br> ";
}

//post information
$employeeID = ($_POST["employeeID"]);
$email = ($_POST["email"]);

if(empty($employeeID) || empty($email))
{
	throw new Exception("Please fill out all the inputs", 1);
	echo ("Please fill out all the inputs");
}

else
{
	$userSql = "INSERT INTO Users(employeeID, email)
	VALUES('$employeeID', '$email')";

	//check if insert is good
	if(mysqli_query($connect, $userSql))
	{
		echo "New user inserted : EmployeeID : "  . $employeeID . " and Email : " . $email;
	}
	else
	{
		echo "error : " . $userSql . " : " . $connect->error;
	}
}