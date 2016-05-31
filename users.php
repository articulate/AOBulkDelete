<?php
//require_once('../../lib/nusoap.php');
$useCURL = isset($_POST['usecurl']) ? $_POST['usecurl'] : '0';

function print_users($email, $password, $customerID, $AccountURL){
    
$params = "<ListUsersRequest xmlns='http://www.articulate-online.com/services/api/1.0/'>
      <Credentials>
        <EmailAddress>$email</EmailAddress>
        <Password>$password</Password>
        <CustomerID>$customerID</CustomerID>
      </Credentials>
    </ListUsersRequest>";

$client = new nusoap_client($AccountURL.'/services/api/1.0/ArticulateOnline.asmx?wsdl',array('encoding'=>'UTF-8'));
  ini_set("soap.wsdl_cache_enabled", "0"); 
 
$err = $client->getError();
echo $err;

$client->setUseCurl($useCURL);
$client->loadWSDL();

$usersListed = $client->call('ListUsers',$params);

//find out if it worked
$userListedStatus = $usersListed['Success'];

if ($userListedStatus == "true"){
    
?>
<table class='GridMain' cellspacing='0' rules='all' border='1' id='StatusGrid' style='border-collapse:collapse;'>
<tr class='GridHeader'><th scope='col'><a href="#" onclick="SetAllCheckBoxes('delete', 'user[]', true);">All</a>,  
<a href="#" onclick="SetAllCheckBoxes('delete', 'user[]', false);">None</a></th><th scope='col'>Email Address</th><th scope='col'>First Name</th><th scope='col'>Last Name</th></tr>
 
<?php
	
    $count = count($usersListed['Profiles']['UserProfile']);
//	foreach ($usersListed['Profiles']['UserProfile'] as $key => $value) {
	for ($i=0; $i < 500 && $i < $count; $i++){
    	echo "<tr>";
		echo "<td align=center> <input type=checkbox name='user[]' value=". $usersListed['Profiles']['UserProfile'][$i]['UserID'] ."></td>";
        echo "<td>" . $usersListed['Profiles']['UserProfile'][$i]['EmailAddress'] . "</td>";
		echo "<td>" . $usersListed['Profiles']['UserProfile'][$i]['FirstName'] . "</td>";
		echo "<td>" . $usersListed['Profiles']['UserProfile'][$i]['LastName'] . "</td>";
		echo "<tr>";
	}
?>
</table>
<?php    
}else{
	$csvList = "Oops!  Something went wrong...make sure that: \n";
	$csvList = $csvList . ",The AO API is enabled on your account\n";
	$csvList = $csvList . ",The account credentials from the previous page are correct";
	print $csvList;

	}
}



?>