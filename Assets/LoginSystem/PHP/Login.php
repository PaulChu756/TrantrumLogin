<?php
include("connect.php");
$connect = connectDB();

$employeeIDEnter = $_POST["employeeIDPost"];
$emailEnter = $_POST["emailPost"];

$sql = "SELECT * FROM Users WHERE employeeID = '".$employeeIDEnter."' ";
$result = mysqli_query($connect ,$sql);

if(mysqli_num_rows($result) > 0)
{
    while($row = mysqli_fetch_assoc($result))
    {
        if($row['employeeID'] == $employeeIDEnter)
        {
            echo "Login Success";
            echo $row['employeeID'];
            echo $row['email'];
        }
        else
        {
            echo " incorrect login information ";
            echo " login is = " . $row['employeeID'] . " . " . $row['email'];
        }
    }
}
else
{
    echo "User not found";
    echo " login is = " . $row['employeeID'] . " . " . $row['email'];
}

?>
