
Command line arguments

1. Your AO Domain
2. Request ( "GetUserInformation", "SetUserPassword", "ListUsers", "AutoLogin", "DeleteUser", "CreateGroup", "DeleteGroup", "UpdateGroup", "GetGroupInformation", "ListGroups", "AddUserToGroup", "RemoveUserFromGroup", "InviteUsersToDocument", "ListDocuments", "GetDocumentSecurity", "UpdateDocumentSecurity")
3. UserName
4. Password
5. CustomerID

examples
Below will return the params needed for the Request if it is invalid:

articulateonlineconsole.exe https://yourdomain.articulate-online.com AutoLogin

aoconsole.exe server_url command arguments /EmailAddress={youremail@domain.com} /Password={password} /CustomerID={customer_id} {URL}


Sending a Request and getting a response from AO SOAP API Examples:

C:\>articulateonlineconsole.exe https://yourdomain.articulate-online.com ListDocuments /EmailAddress=AOUserName /Password=YourPass /CustomerID=00000

C:\>articulateonlineconsole.exe https://yourdomain.articulate-online.com AutoLogin /EmailAddress=AOUserName /Password=YourPass /CustomerID=00000 https://yourdomain.articulate-online.com/userportal/content.aspx?CustID=00000

