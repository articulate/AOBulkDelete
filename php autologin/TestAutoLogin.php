<?php
ini_set('display_errors',1);

function showXML($xml){
	return '<pre>'.str_replace('<','&lt;',str_replace("><",">\r\n<",$xml)).'</pre>';
}


if($_GET){
	$action = @$_GET['soap_action'];
	$soapUrl = "https://yourdomain.articulate-online.com/services/api/1.0/articulateonline.asmx?wsdl"; 

	$soapUser = "admin@email.com";  //  username
	$soapPassword = "adminpass"; // password
	$soapId = "01234"; //cust id
	$url = 'http://yourcontent.articulate-online.com/0824000000';
//	$lookupUser = 'some@email.com';
//	$lookupId = '046c96cc-fcaf-439e-83ce-6bfdc28d9e67';

	if($action=='GetAutoLoginUrl'){
		$requestName = 'AutoLogin';
		
	}else{
		$requestName = $action;
	}
	$xml_post_string = '<?xml version="1.0" encoding="utf-8"?>
	<soap:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/">
	<soap:Body>
	<'.$requestName.'Request xmlns="http://www.articulate-online.com/services/api/1.0/">
	<Credentials>
	<EmailAddress>'.$soapUser.'</EmailAddress>
	<Password>'.$soapPassword.'</Password>
	<CustomerID>'.$soapId.'</CustomerID>
	</Credentials>
	<Url>'.$url.'</Url>

	</'.$requestName.'Request>
	</soap:Body>
	</soap:Envelope>';

	$headers = array(
		"Content-type: text/xml; charset=\"utf-8\"",
		"Content-length: ".strlen($xml_post_string),
		"SOAPAction: http://www.articulate-online.com/services/api/1.0/".$action 
	);

	$url = $soapUrl;

	echo "POSTING: ".showXML($xml_post_string);

	$ch = curl_init();
	curl_setopt($ch, CURLOPT_SSL_VERIFYPEER, 0);
	curl_setopt($ch, CURLOPT_URL, $url);
	curl_setopt($ch, CURLOPT_RETURNTRANSFER, true);
	curl_setopt($ch, CURLOPT_USERPWD, $soapUser.":".$soapPassword);
	curl_setopt($ch, CURLOPT_HTTPAUTH, CURLAUTH_ANY);
	curl_setopt($ch, CURLOPT_TIMEOUT, 10);
	curl_setopt($ch, CURLOPT_POST, true);
	curl_setopt($ch, CURLOPT_POSTFIELDS, $xml_post_string);
	curl_setopt($ch, CURLOPT_HTTPHEADER, $headers);
	//die();
	$response = curl_exec($ch); 

	curl_close($ch);

	$parser = simplexml_load_string($response);
	// user $parser to get your data out of XML response and to display it.

	echo '<hr>RESPONSE: '. showXML($response);
        
}else{
?>
<form action="./" method="get">
	<select name="soap_action">
		<option name ="GetUserInformation" value="GetUserInformation">GetUserInformation</option>
		<option name ="ListDocuments" value="ListDocuments">ListDocuments</option>
		<option name ="GetAutoLoginUrl" value="GetAutoLoginUrl">GetAutoLoginUrl</option>
		<input type="submit">
	</select>
</form>
<?php
}
?>

