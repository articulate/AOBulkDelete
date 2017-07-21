<html>
<head>
<title>Bulk User Deleter
</title><link href="css/bootstrap.min.css" rel="stylesheet"><link href="css/jumbotron.css" rel="stylesheet">
</html>
<body>


<form name="login" action="delete_users.php" method="post">
    <center>
<h4>Login to your account</h4>
    <table class="formtable"><tr>
    <td style="padding:20px;">E-mail:</td>
    <td>
        <input name="emailAddress" type="text" class="form-control" style="width:250px; padding:10px;" />
    </td></tr>
    <tr><td style="padding:20px;">Password:</td>
    <td><input name="password" type="password" class="form-control" style="width:250px;" />
    </td>
    </tr>
    <tr><td style="padding:20px;">Account URL:</td>
    <td><input name="URL" type="text" value="http://" class="form-control" style="width:250px;" />
    </td>
    </tr>
    <tr><td style="padding:20px;">Customer ID:</td>
    <td><input name="custID" type="text" class="form-control" style="width:250px;" />
    </td>
    </tr>
    </table>  
<input type="submit" name="login" class="btn btn-success" value="Login"/> 
</form>

</body>
</html>
