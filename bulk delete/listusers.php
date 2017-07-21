<?php

set_time_limit(3600);
require_once('config.php');

$useCURL = isset($_POST['usecurl']) ? $_POST['usecurl'] : '0';

$params = "<ListUsersRequest xmlns='http://www.articulate-online.com/services/api/1.0/'>
      <Credentials>
        <EmailAddress>$myEmail</EmailAddress>
        <Password>$myPassword</Password>
        <CustomerID>$myCustomerID</CustomerID>
      </Credentials>
    </ListUsersRequest>";

$client = new soapclient($myAccountURL.'/services/api/1.0/ArticulateOnline.asmx?wsdl',array('encoding'=>'UTF-8'));
  ini_set("soap.wsdl_cache_enabled", "0"); 
 
$err = $client->getError();
echo $err;

$client->setUseCurl($useCURL);
$client->loadWSDL();

$usersListed = $client->call('ListUsers',$params);

//find out if it worked
$userListedStatus = $usersListed['Success'];
?>

<html>

<head>
<title>Bulk User Deleter
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
<br>
<div>
<form name="delete" action="delete_users.php" method="post">
        <h2>
            Bulk User Deleter<br />
        </h2>
        <p>This lists the first 150 users on your account including <strong>Admins</strong> and <strong>Publishers.</strong></p>
        <br />

<table class='GridMain' cellspacing='0' rules='all' border='1' id='StatusGrid' style='border-collapse:collapse;'>
<tr class='GridHeader'><th scope='col'><a href="#" onclick="SetAllCheckBoxes('delete', 'user[]', true);">All</a>,  
<a href="#" onclick="SetAllCheckBoxes('delete', 'user[]', false);">None</a></th><th scope='col'>Email Address</th><th scope='col'>First Name</th><th scope='col'>Last Name</th></tr>
<?php

if ($userListedStatus == "true"){
	
    $count = count($usersListed['Profiles']['UserProfile']);
//	foreach ($usersListed['Profiles']['UserProfile'] as $key => $value) {
	for ($i=0; $i < 500 && $i < $count; $i++){
    	echo "<tr>";
		echo "<td align=center> <input type=checkbox name='user[]' value=". $usersListed['Profiles']['UserProfile'][$key]['UserID'] ."></td>";
        echo "<td>" . $usersListed['Profiles']['UserProfile'][$i]['EmailAddress'] . "</td>";
		echo "<td>" . $usersListed['Profiles']['UserProfile'][$i]['FirstName'] . "</td>";
		echo "<td>" . $usersListed['Profiles']['UserProfile'][$i]['LastName'] . "</td>";
		echo "<tr>";
	}

?>

</div></table><br />

<input type="submit" name="btnDelete" value="Delete Selected Users" id="btnDelete" onClick="return confirm(
  'Tracking information will be permanently erased.\nAre you sure you want to delete these users?');" /><br />

</form>
</body></html>
<?php
	
}else{
	$csvList = "Oops!  Something went wrong...make sure that: \n";
	$csvList = $csvList . ", The AO API is enabled on your account\n";
	$csvList = $csvList . ", The account credentials from the previous page are correct";
	print $csvList;

	}	

    //echo '<h2>Request</h2><pre>' . htmlspecialchars($client->request, ENT_QUOTES) . '</pre>';
    //echo '<h2>Response</h2><pre>' . htmlspecialchars($client->response, ENT_QUOTES) . '</pre>';

?>