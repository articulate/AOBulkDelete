<html>
<head>
<title>Bulk User Deleter
</title><link href="style.css" rel="stylesheet" type="text/css" />
</html>
<body>


<form name="login" action="delete_users.php" method="post">
    <center>
<h4>Login to your account</h4>
    <table class="formtable"><tr>
    <td>E-mail:</td>
    <td>
        <input name="emailAddress" type="text" style="width:250px;" />
    </td></tr>
    <tr><td>Password:</td>
    <td><input name="password" type="password" style="width:250px;" />
    </td>
    </tr>
    <tr><td>Account URL:</td>
    <td><input name="URL" type="text" value="http://" style="width:250px;" />
    </td>
    </tr>
    <tr><td>Customer ID:</td>
    <td><input name="custID" type="text" style="width:250px;" />
    </td>
    </tr>
    </table>  
<input type="submit" name="login" value="Login"/> 
</form>

</body>
</html>
