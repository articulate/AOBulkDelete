<html>
<head><title>Registration Status</title>
<style type="text/css" media="screen"> 
	@import url(http://beta.articulate-online.com/css/default.css);
	@import url(http://beta.articulate-online.com/css/additional.css);
	@import url(http://beta.articulate-online.com/css/nonadmin.css);
	@import url(http://beta.articulate-online.com/css/lightbox.css);
</style> 
</head> 
<body> 
 
<div id="wrap"> 
<div id="header"> 
<a href="http://www.articulate.com" target="_new"><img class="logo" src="http://beta.articulate-online.com/images/logo.gif" width="170" height="16" alt="Articulate Online" /></a> 
<div class="clear"> </div> 
<div id="primaryContent"> 
<div id="boxwrap"> 
<div id="loginboxnew"> 
<div id="form"> 
<div id="box"> 

<?php
require_once('../../lib/nusoap.php');
require_once('config.php');
$useCURL = isset($_POST['usecurl']) ? $_POST['usecurl'] : '0';

$newEmail = $_POST['emailAddress'];
$newPassword = $_POST['password'];

$params = "<CreateUsersRequest xmlns='http://www.articulate-online.com/services/api/1.0/'>
      <Credentials>
        <EmailAddress>$emailaddress</EmailAddress>
        <Password>$password</Password>
        <CustomerID>$customerID</CustomerID>
      </Credentials>
      <Emails>
        <string>$newEmail</string>
      </Emails>
      <AutoGeneratePassword>false</AutoGeneratePassword>
      <Password>$newPassword</Password>
      <SendLoginEmail>true</SendLoginEmail>
      <PersonalComment>$comment</PersonalComment>
    </CreateUsersRequest>";

$client = new soapclient($accountURL.'/services/api/1.0/ArticulateOnline.asmx?wsdl',array('encoding'=>'UTF-8'));
  ini_set("soap.wsdl_cache_enabled", "0"); 
 
$err = $client->getError();
echo $err;

$client->setUseCurl($useCURL);
$client->loadWSDL();

$userCreated = $client->call('CreateUsers',$params);

//find out if it worked
$userCreatedStatus = $userCreated['Success'];

//if it works, give feedback.  If it doesn't, explain why...
if ($userCreatedStatus == 'false'){
echo '<h1 class="title">Oops!</h1>';
echo '<p class="subheader">Oops! ' . substr($userCreated['ErrorMessage'],0,strpos($userCreated['ErrorMessage'], "Articulate.KnowledgeFlash")) . '</p>';
}elseif($userCreatedStatus == 'true'){
echo '<h1 class="title">Registration Successful</h1>';
echo '<div class="clearline"> </div>';
echo '<p class="subheader">Great, you have registered succesfully!  You will recieve a confirmation email shortly containing your login details.</p>';
echo '<br><p class="subheader">You can login to your account here <a href="' . $accountURL . '">' . $accountURL . '</a>.</p>';
}else{
echo "For some reason we are unable to the Articulate Online web service.<br><br>There are a couple of reasons this might happen:";
echo "<ul><li>The API might not be enabled on your account</li><li>The configuration options in this page are incorrect.</li><ul>";
}

?>
<div class="clear"> </div> 
</div> <!-- END BOX --> 
<br /> 
<br /> 
</div> <!-- END FORM --> 
</div> <!-- END LOGINBOX --> 
</div> <!-- END BOXWRAP --> 
</div> 
</div> <!-- END WRAP --> 
</body> 
 
</html>