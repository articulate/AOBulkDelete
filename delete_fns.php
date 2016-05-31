<?php
/**
 * Dave Mozealous
 * @copyright 2010
 */
set_time_limit(3600);

function delete_user($userID, $myEmail, $myPassword, $myCustomerID, $myAccountURL) {

    $useCURL = isset($_POST['usecurl']) ? $_POST['usecurl'] : '0';
    
    $params = "<DeleteUserRequest xmlns='http://www.articulate-online.com/services/api/1.0/'>
                  <Credentials>
                    <EmailAddress>$myEmail</EmailAddress>
                    <Password>$myPassword</Password>
                    <CustomerID>$myCustomerID</CustomerID>
                  </Credentials>
                  <UserID>$userID</UserID>
                </DeleteUserRequest>";
     
     //echo $params;
                
     $client = new nusoap_client($myAccountURL.'/services/api/1.0/ArticulateOnline.asmx?wsdl',array('encoding'=>'UTF-8'));
  ini_set("soap.wsdl_cache_enabled", "0"); 
 
    $err = $client->getError();
    echo $err;

    $client->setUseCurl($useCURL);
    $client->loadWSDL();

    $deleteUser = $client->call('DeleteUser',$params);

    //find out if it worked
    $userDeletedStatus = $deleteUser['Success'];
    
   // echo '<h2>Request</h2><pre>' . htmlspecialchars($client->request, ENT_QUOTES) . '</pre>';
    //echo '<h2>Response</h2><pre>' . htmlspecialchars($client->response, ENT_QUOTES) . '</pre>';

    if ($userDeletedStatus == "true"){
        return "success";
    }else{
        return "failure";
    }

}

?>