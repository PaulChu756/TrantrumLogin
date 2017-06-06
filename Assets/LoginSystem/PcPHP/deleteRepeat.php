<?php
include("connect.php");
$connect = connectDB();

//delete repeated data
$deleteSql = "DELETE * FROM Users WHERE column=NULL";
$deleteQuery = mysqli_query($connect, $resultSql) or die(mysqli_error($connect));
?>