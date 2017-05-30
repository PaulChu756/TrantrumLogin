<?php
include("connect.php");
$connect = connectDB();
$requestMethod = $_SERVER["REQUEST_METHOD"];

//get request
if($requestMethod == "GET")
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
elseif($requestMethod == "POST")
{
    global $connection;
    $employeeID = safe($_POST["employeeID"]);
    $email = safe($_POST["email"]);

    if(empty($employeeID) || empty($email))
    {
        throw new Exception("Please fill out all the inputs", 1);
    }

    else
    {
        $userSql = "INSERT INTO Users(employeeID, email)
        VALUES('$employeeID', '$email')";

        //check if insert is good
        if(mysqli_query($connection, $userSql))
        {
            echo "New user inserted : EmployeeID : "  . $employeeID . " and Email : " . $email;
        }
        else
        {
            echo "error : " . $userSql . " : " . $connection->error;
        }
    }
}
else
{
    echo "undefined request method";
}