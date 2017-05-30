<?php
include("connect.php");
$connect = connectDB();
$requestMethod = $_SERVER["REQUEST_METHOD"];

//get request
if($requestMethod === "GET")
{
    global $connection;
    $resultSql = "SELECT * FROM Users";
    $query = mysqli_query($connection, $resultSql) or die(mysqli_error($connection));
    while($row = mysqli_fetch_array($query))
    {
        echo "Employee ID : " . $row['employeeID'] . " , Email : " . $row['email'];
    }
}

//post request
elseif($requestMethod === "POST")
{
    global $connection;
    $employeeID = safe($_POST["employeeID"]);
    $email = safe($_POST["email"]);

    if(!empty($employeeID) && !empty($email))
    {
        $userSql = "INSERT INTO Users(employeeID, email)
        VALUES('$employeeID', '$email')";

        if($connection->query($userSql) === TRUE)
        {
            echo $employeeID;
            echo $email;
        }
    }

    else
    {
        $userError = "Input boxes cannot be empty";
    }
}