<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"

	"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"> 
 
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en" lang="en"> 
<head><meta http-equiv="Content-Type" content="text/html; charset=utf-8" /><title> 
	Registration
</title> 
	
<style type="text/css" media="screen"> 
	@import url(http://beta.articulate-online.com/css/default.css);
	@import url(http://beta.articulate-online.com/css/additional.css);
	@import url(http://beta.articulate-online.com/css/nonadmin.css);
	@import url(http://beta.articulate-online.com/css/lightbox.css);
</style> 

<script language="JavaScript" type="text/javascript">
///////////////////////////////////////////////////////////////////////////
// Script to make sure the fields are valid.
///////////////////////////////////////////////////////////////////////////
function isEmailAddress(string) {
return /^[^@]+@[^.]+(\.[^.]+)+$/.test(string);
}

function checkform ( form )
{
emailAddress = form.emailAddress.value;

  if (!isEmailAddress(emailAddress)) {
    alert('Please enter a valid E-mail address.');
	form.emailAddress.focus();
    return false;
  }
  if (emailAddress != form.emailAddress.value) {
    alert('You may have mistyped your E-mail address.'
    + ' Please check both fields carefully and try again.');
	form.emailAddress.focus();
    return false;
  }
    if (form.password.value.length < 4) {
    alert( "Passwords must be at least 4 characters." );
    form.password.focus();
    return false ;
  }
  if (form.password.value == "" || form.confirmPassword.value == "") {
    alert( "Please enter your Password and confirm your Password." );
    form.password.focus();
    return false ;
  }
  if (form.password.value != form.confirmPassword.value) {
    alert( "Password and confirm password do not match." );
    form.confirmPassword.focus();
    return false ;
  }
  
  return true ;
}
//-->
</script>
</head>
<body>
<form action="register.php" method="post" onsubmit="return checkform(this);">
<div id="wrap"> 
<div id="header"> 
<a href="http://www.articulate.com" target="_new"><img class="logo" src="http://beta.articulate-online.com/images/logo.gif" width="170" height="16" alt="Articulate Online" /></a> 
<div class="clear"> </div> 
<div id="primaryContent"> 
<div id="activation"> 
<div id="boxwrap"> 
<div id="loginboxnew"> 
<div id="form"> 
<div id="box"> 
<h1 class="activationtitle">Registration</h1>
 
 
<div class="clearline"> </div> 
<p class="subheader">Fill out the form below to register.</p> 
<div class="setting"><p class="wide">E-mail:&nbsp; </p><input type="text" name="emailAddress" class="textbox"/></div>
<div class="setting"><p class="wide">Password:&nbsp;</p><input name="password" type="password" class="textbox" /></div>
<div class="setting"><p class="wide">Password (Confirm):&nbsp;</p><input name="confirmPassword" type="password" class="textbox" /></div>
<div class="buttons"><input type="submit" value="Register" /></div>
</div> <!-- END BUTTONS --> 
 
<div class="clear"> </div> 
</div> <!-- END BOX --> 
 
<br /> 
<br /> 
 
</div> <!-- END FORM --> 
 
</div> <!-- END LOGINBOX --> 
 
</div> <!-- END BOXWRAP --> 

</div> <!-- END PRIMARY CONTENT --> 
 
  
  
          
 
</div> <!-- END WRAP --> 
</form>

</body>
</html>
