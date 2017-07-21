using System;
using System.Collections.Generic;
using System.Text;

using ArticulateOnlineConsole.Articulate;

namespace ArticulateOnlineConsole
{
    class AoConsole
    {

        static bool ensureArgs(string[] args, int extra)
        {
            if (args.Length < 5 + extra)
            {
                PrintUsage();
                return false;
            }
            else
            {
                return true;
            }
        }

        static bool listUsers(string url, Credentials c)
        {
            Console.WriteLine("Listing users...");

            ArticulateOnline ao = new ArticulateOnline();
            ao.Url = url;
            ListUsersRequest request = new ListUsersRequest();
            request.Credentials = c;
            ListUsersResponse response = ao.ListUsers(request);
            if (response.Success)
            {
                foreach (UserProfile up in response.Profiles)
                {
                    Console.WriteLine(String.Format("{0} {1} {2} {3}", up.UserID, up.EmailAddress, up.FirstName, up.LastName));
                }
            }
            return response.Success;
        }

        static bool listGroups(string url, Credentials c)
        {
            Console.WriteLine("Listing groups...");

            ArticulateOnline ao = new ArticulateOnline();
            ao.Url = url;
            ListGroupsRequest request = new ListGroupsRequest();
            request.Credentials = c;
            ListGroupsResponse response = ao.ListGroups(request);
            if (response.Success)
            {
                foreach (GroupSummary gs in response.Groups)
                {
                    Console.WriteLine(String.Format("{0} {1} {2}", gs.GroupID, gs.Name, gs.Description));
                }
            }
            return response.Success;
        }

        static bool updateUserProfile(string url, Credentials c, string userId, string firstName, string lastName, string company)
        {
            ArticulateOnline ao = new ArticulateOnline();
            ao.Url = url;
            UpdateUserProfileRequest request = new UpdateUserProfileRequest();
            request.Credentials = c; 
            request.UserID = userId;
            request.FirstName = firstName;
            request.LastName = lastName;
            request.Company = company;
            return ao.UpdateUserProfile(request).Success;
        }

        static bool listDocuments(string url, Credentials c)        
        {
            Console.WriteLine("Listing documents...");

            ArticulateOnline ao = new ArticulateOnline();
            ao.Url = url;
            ListDocumentsRequest request = new ListDocumentsRequest();
            request.Credentials = c;
            ListDocumentsResponse response = ao.ListDocuments(request);
            if (response.Success)
            {
                foreach (DocumentSummary ds in response.Documents)
                {
                    Console.WriteLine(String.Format("{0} {1} {2}", ds.DocumentID, ds.Name, ds.Description));
                }
            }
            return response.Success;
        }

        static bool addUserToGroup(string url, Credentials c, string userId, string groupId)
        {
            Console.WriteLine("Adding user to group...");

            ArticulateOnline ao = new ArticulateOnline();
            ao.Url = url;
            AddUserToGroupRequest request = new AddUserToGroupRequest();
            request.Credentials = c;
            request.UserID = userId;
            request.GroupID = groupId;


            AddUserToGroupResponse response = ao.AddUserToGroup(request);
            Console.WriteLine("Error: "+response.ErrorMessage);
            return response.Success;

        }

        static bool removeUserFromGroup(string url, Credentials c, string userId, string groupId)
        {
            Console.WriteLine("Removing user from group...");

            ArticulateOnline ao = new ArticulateOnline();
            ao.Url = url;
            RemoveUserFromGroupRequest request = new RemoveUserFromGroupRequest();
            request.Credentials = c;
            request.UserID = userId;
            request.GroupID = groupId;

            return ao.RemoveUserFromGroup(request).Success;
        }

        static bool getUserInformation(string url, Credentials c, string userId)
        {
            Console.WriteLine("Get user information...");

            ArticulateOnline ao = new ArticulateOnline();
            ao.Url = url;
            GetUserInformationRequest request = new GetUserInformationRequest();
            request.Credentials = c;
            request.UserID = userId;
            GetUserInformationResponse response = ao.GetUserInformation(request);
            if (response.Success)
            {
                Console.WriteLine(String.Format("{0} {1} {2}", response.Profile.EmailAddress, response.Profile.FirstName, response.Profile.LastName));

                Console.WriteLine("Member of:");
                foreach (string groupID in response.MemberOfGroupIDs)
                {
                    Console.WriteLine("\t" + groupID);
                }
            }

            return response.Success;            
        }

        static bool getDocumentSecurity(string url, Credentials c, string documentId)
        {
            Console.WriteLine("Getting document security...");

            ArticulateOnline ao = new ArticulateOnline();
            ao.Url = url;
            GetDocumentSecurityRequest request = new GetDocumentSecurityRequest();
            request.Credentials = c;
            request.DocumentID = documentId;

            GetDocumentSecurityResponse response = ao.GetDocumentSecurity(request);
            if (response.Success)
            {
                Console.WriteLine("Privacy: {0}", response.PrivacyOption);
                Console.WriteLine("Allowed users & groups: ");
                foreach (string allowedAccountId in response.AllowedAccountIDs)
                {
                    Console.WriteLine("\t"+allowedAccountId);
                }
            }

            return response.Success;
        }

        static bool updateDocumentSecurity(string url, Credentials c, string documentId, PrivacyOption privacyOption, string[] allowedAccountIds)
        {
            Console.WriteLine("Updating document security...");

            ArticulateOnline ao = new ArticulateOnline();
            ao.Url = url;
            UpdateDocumentSecurityRequest request = new UpdateDocumentSecurityRequest();
            request.Credentials = c;
            request.DocumentID = documentId;
            request.AllowedAccountIDs = allowedAccountIds;
            request.PrivacyOption = privacyOption;

            UpdateDocumentSecurityResponse response = ao.UpdateDocumentSecurity(request);            
            return response.Success;
        }       

        static bool getGroupInformation(string url, Credentials c, string groupId)
        {
            Console.WriteLine("Get group information...");

            ArticulateOnline ao = new ArticulateOnline();
            ao.Url = url;
            GetGroupInformationRequest request = new GetGroupInformationRequest();
            request.Credentials = c;
            request.GroupID = groupId;
            GetGroupInformationResponse response = ao.GetGroupInformation(request);

            if (response.Success)
            {
                Console.WriteLine(String.Format("{0} {1} {2}", response.Group.GroupID, response.Group.Name, response.Group.Description));
                Console.WriteLine("Group members:");
                foreach (string userID in response.UserMemberIDs)
                {
                    Console.WriteLine("\t"+userID);
                }
            }
            return response.Success;
        }

        static bool deleteUser(string url, Credentials c, string userId)
        {
            Console.WriteLine("Deleting user...");

            ArticulateOnline ao = new ArticulateOnline();
            ao.Url = url;
            DeleteUserRequest request = new DeleteUserRequest();
            request.Credentials = c;
            request.UserID = userId;
            return ao.DeleteUser(request).Success;
        }

        static bool deleteGroup(string url, Credentials c, string groupId)
        {
            Console.WriteLine("Deleting group...");

            ArticulateOnline ao = new ArticulateOnline();
            ao.Url = url;
            DeleteGroupRequest request = new DeleteGroupRequest();
            request.Credentials = c;
            request.GroupID = groupId;
            return ao.DeleteGroup(request).Success;
        }

        static bool createGroup(string url, Credentials c, string name, string description)        
        {
            Console.WriteLine("Creating group...");

            ArticulateOnline ao = new ArticulateOnline();
            ao.Url = url;
            CreateGroupRequest request = new CreateGroupRequest();
            request.Credentials = c;
            request.Name = name;
            request.Description = description;

            CreateGroupResponse response = ao.CreateGroup(request);
            return response.Success;        
        }

        static bool setUserPassword(string url, Credentials c, string userId, string password)
        {
            Console.WriteLine("Set user password...");

            ArticulateOnline ao = new ArticulateOnline();
            ao.Url = url;
            SetUserPasswordRequest request = new SetUserPasswordRequest();
            request.Credentials = c;
            request.UserID = userId;
            request.Password = password;

            return ao.SetUserPassword(request).Success;         
        }

        static bool createUsers(string url, Credentials c, string[] emailAddresses, string[] memberOfGroupIds, string password, bool generateRandomPassword, bool sendLoginEmail, string personalComment)
        {
            Console.WriteLine("Create users...");

            ArticulateOnline ao = new ArticulateOnline();
            ao.Url = url;

            CreateUsersRequest request = new CreateUsersRequest();
            request.Credentials = c;
            request.Emails = emailAddresses;
            request.MemberOfGroupIDs = memberOfGroupIds;
            request.Password = password;
            request.AutoGeneratePassword = generateRandomPassword;
            request.PersonalComment = personalComment;
            request.SendLoginEmail = sendLoginEmail;            
            return ao.CreateUsers(request).Success;
        }

        static bool inviteUsersToDocument(string url, Credentials c, string documentId, string[] emails, string[] userIds, string[] groupIds, string personalNote)
        {
            Console.WriteLine("Inviting users...");

            ArticulateOnline ao = new ArticulateOnline();
            ao.Url = url;

            InviteUsersRequest request = new InviteUsersRequest();
            request.Credentials = c;
            request.DocumentID = documentId;
            request.EmailAddresses = emails;
            request.GroupIDs = groupIds;
            request.PersonalComment = personalNote;
            request.UserIDs = userIds;

            return ao.InviteUsers(request).Success;           
        }

        static bool updateGroup(string url, Credentials c, string groupId, string name, string description)
        {
            Console.WriteLine("Update group...");

            ArticulateOnline ao = new ArticulateOnline();
            ao.Url = url;

            UpdateGroupRequest request = new UpdateGroupRequest();
            request.Credentials = c;
            request.GroupID = groupId;
            request.Name = name;
            request.Description = description;
                        
            return ao.UpdateGroup(request).Success;
        }


        static int Main(string[] args)
        {
            if (args.Length < 5)
            {
                PrintUsage();
            }
            else
            {
                string url = args[0] + "/services/api/1.0/articulateonline.asmx";
                string command = args[1];
                
                Credentials c = getCredentials(args);
                bool success = false;
                if (c == null)
                {
                    Console.WriteLine("Credentials were not specified");
                }
                else
                {
                 
                    switch (command)
                    {
                        case "CreateUsers":
                            Console.WriteLine("Not implemented");
                            break;
                        case "UpdateUserProfile":
                            Console.WriteLine("Not implemented");
                            break;
                        case "GetUserInformation":
                            if (ensureArgs(args, 1))
                            {
                                success = getUserInformation(url, c, args[2]);
                            }
                            break;
                        case "SetUserPassword":
                            if (ensureArgs(args, 2))
                            {
                                success = setUserPassword(url, c, args[2], args[3]);
                            }
                            break;
                        case "ListUsers":
                            success = listUsers(url, c);
                            break;
                        case "DeleteUser":
                            if (ensureArgs(args, 1))
                            {
                                success = deleteUser(url, c, args[2]);
                            }                            
                            break;


                        case "CreateGroup":
                            if (ensureArgs(args, 2))
                            {
                                success = createGroup(url, c, args[2], args[3]);
                            }
                            break;
                        case "DeleteGroup":
                            if (ensureArgs(args, 1))
                            {
                                success = deleteGroup(url, c, args[2]);
                            }
                            break;
                        case "UpdateGroup":
                            if (ensureArgs(args, 3))
                            {
                                success = updateGroup(url, c, args[2], args[3], args[4]);
                            }
                            break;
                        case "GetGroupInformation":
                            if (ensureArgs(args, 1))
                            {
                                success = getGroupInformation(url, c, args[2]);
                            }
                            break;
                        case "ListGroups":
                            success = listGroups(url, c);
                            break;
                        case "AddUserToGroup":
                            if (ensureArgs(args, 2))
                            {
                                success = addUserToGroup(url, c, args[2], args[3]);
                            }
                            break;
                        case "RemoveUserFromGroup":
                            if (ensureArgs(args, 2))
                            {
                                success = removeUserFromGroup(url, c, args[2], args[3]);
                            }
                            break;
                            
                        case "InviteUsersToDocument":
                            Console.WriteLine("Not implemented");
                            break;
                        case "ListDocuments":
                            success = listDocuments(url, c);
                            break;
                        case "GetDocumentSecurity":
                            if (ensureArgs(args, 1))
                            {
                                success = getDocumentSecurity(url, c, args[2]);
                            }
                            break;
                        case "UpdateDocumentSecurity":
                            if (ensureArgs(args, 3))
                            {
                                success = updateDocumentSecurity(url, c, args[2], (PrivacyOption)Enum.Parse(typeof(PrivacyOption), args[3]), args[4].Split(',') );
                            }
                            break;
                        default:
                            break;

                    }

                    if (!success)
                    {
                        PrintUsage();
                    }

                    return success ? 0 : -1;
                }
            }
            return -1;
        }

        static Credentials getCredentials(string[] arguments)
        {
            Credentials c = new Credentials();
            foreach (string arg in arguments)
            {
                string emailStr = "/EmailAddress=";
                string passwordStr = "/Password=";
                string customerIdStr = "/CustomerID=";

                if (arg.StartsWith(emailStr, StringComparison.InvariantCultureIgnoreCase))
                {
                    c.EmailAddress = arg.Substring(emailStr.Length).Trim();
                    if (c.EmailAddress.Length == 0)
                    {
                        c.EmailAddress = null;
                    }
                }
                else if (arg.StartsWith(passwordStr, StringComparison.InvariantCultureIgnoreCase))
                {
                    c.Password = arg.Substring(passwordStr.Length).Trim();
                    if (c.Password.Length == 0)
                    {
                        c.Password = null;
                    }
                }
                else if (arg.StartsWith(customerIdStr, StringComparison.InvariantCultureIgnoreCase))
                {
                    c.CustomerID = arg.Substring(customerIdStr.Length).Trim();
                    if (c.CustomerID.Length == 0)
                    {
                        c.CustomerID = null;
                    }
                }
            }
            if (c.CustomerID != null && c.Password != null && c.EmailAddress != null)
            {
                return c;
            }
            else
            {
                return null;
            }
        }

        static void PrintUsage()
        {
            Console.WriteLine("aoconsole.exe server_url command arguments /EmailAddress={youremail@domain.com} /Password={password} /CustomerID={customer_id}");
            
        }
    }
}