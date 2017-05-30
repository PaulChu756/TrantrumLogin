<?php
$trantrumDB = "trantrumDB";
$host = "localhost";
$username = "root";
$password = "root";
$gameKey = "Trantrum300!";
$serverKey = "Trantrum300!";

function connectDB()
{
  global $trantrumDB;
  global $host;
  global $username;
  global $password;

  //connection
  $connection = mysqli_connect($host, $username, $password);
  //check connection
  if(!$connection)
  {
    die("Could not connect: " . mysqli_connect_error());
  }
  else
  {
    echo "Connect successfully";
  }

  //select database
  $connection->select_db($trantrumDB) or die(mysql_error());

  return $connection;
}

function safe($var)
{
  $var = addslashes(trim($var));
  return $var;
}

function fail($error)
{
  echo $error;
}
?>
