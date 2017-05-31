<?php
include("connect.php");
$connect = connectDB();

//create table
$userTable = "CREATE TABLE IF NOT EXISTS Users
(
id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
employeeID INT(20) NOT NULL,
email varchar(40) NOT NULL
)";

//check table
if($connect->query($userTable) === TRUE)
{
	echo "User Table created successfully \n ";
}
else
{
	echo "User Table wasn't created \n " . $connect->error;
}

//insert test data
$insertData =  "INSERT INTO Users (employeeID, email)
                VALUES ('120', 'paulchu756@gmail.com');";
$insertData .= "INSERT INTO Users (employeeID, email)
				VALUES ('777', 'paulchu756@gmail.com');";
$insertData .= "INSERT INTO Users (employeeID, email)
				VALUES ('123', 'paul@potenzacreative.com');";

if($connect->multi_query($insertData) === TRUE)
{
	$lastID = $connect->insert_id;
	echo "insertData create successfully. Last inserted ID is: \n " . $lastID;
}
else
{
	echo "Error: \n" . $connect->error;
}

?>