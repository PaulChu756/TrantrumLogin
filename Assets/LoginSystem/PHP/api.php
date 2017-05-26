<?php
$trantrumDB = "trantrumDB";
$host = "localhost";
$username = "root";
$password = "root";

$gameKey = "trantrum300!";
$serverKey = "TrantrumUSA!";

//connection
$connection = mysqli_connect($host, $username, $password);
//check connection
if(!$connection){
die("Could not connect: " . mysqli_connect_error());
}
//select database
$connection->select_db($trantrumDB);

function connectDB()
{
  global $trantrumDB;
  global $host;
  global $username;
  global $password;


}
 ?>
