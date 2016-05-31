<html>
<head>
<title>Users Deleted
</title><link href="style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript"> 
<!--
function SetAllCheckBoxes(FormName, FieldName, CheckValue)
{
	if(!document.forms[FormName])
		return;
	var objCheckBoxes = document.forms[FormName].elements[FieldName];
	if(!objCheckBoxes)
		return;
	var countCheckBoxes = objCheckBoxes.length;
	if(!countCheckBoxes)
		objCheckBoxes.checked = CheckValue;
	else
		// set the check value for all check boxes
		for(var i = 0; i < countCheckBoxes; i++)
			objCheckBoxes[i].checked = CheckValue;
}
</script>
</head>
<body>
<?php
set_time_limit(3600);
require_once('delete_fns.php');
require_once('config.php');
require_once('users.php');

$users = $_POST['user'];
$myEmail = $_POST['emailAddress'];
$myPassword = $_POST['password'];
$URL = $_POST['URL'];
$custID = $_POST['custID'];

if (count($users)>0){
    foreach ($users as $userID)
    {
        delete_user($userID, $myEmail, $myPassword, $custID, $URL);
    }
    echo "<h2>" . count($users) . " users deleted. </h2>";
}
?>
<form name="delete" action="delete_users.php" method="post">
        <h2>
            Bulk User Deleter<br />
        </h2>
     <h4>Select users to delete</h4>
   
<p>Displaying first 500 users on your account including <strong>Admins</strong> and <strong>Publishers.</strong></p>

<?php

print_users($myEmail,$myPassword,$custID,$URL);

echo "<input type=hidden name=emailAddress value=" . $myEmail . " /><br>";
echo "<input type=hidden name=password value=" . $myPassword . " /><br>";
echo "<input type=hidden name=URL value=" . $URL . " /><br>";
echo "<input type=hidden name=custID value=" . $custID . " /><br>";

?>
<br />
<input type="submit" name="btnDelete" value="Delete Selected Users" id="btnDelete" onClick="return confirm(
  'Tracking information will be permanently erased.\nAre you sure you want to delete these users?');" /><br />

</form>
</body></html>