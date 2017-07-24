using System;
using ArticulateOnlineConsole.Articulate;

namespace ArticulateOnlineConsole
{
    class AoConsole
    {

        static bool EnsureArgs(string[] args, int extra, string param, string command)
        {
            if (args.Length < 5 + extra)
            {
                PrintUsage(param, command);
                return false;
            }
            else
            {
                return true;
            }
        }

        static bool ListUsers(string url, Credentials c)
        {
            Console.WriteLine("Listing users...");

            ArticulateOnline ao = new ArticulateOnline {Url = url};
            ListUsersRequest request = new ListUsersRequest {Credentials = c};
            ListUsersResponse response = ao.ListUsers(request);
            if (response.Success)
            {
                foreach (UserProfile up in response.Profiles)
                {
                    Console.WriteLine("{0} {1} {2} {3}", up.UserID, up.EmailAddress, up.FirstName, up.LastName);
                }
            }
            return response.Success;
        }

        static bool ListGroups(string url, Credentials c)
        {
            Console.WriteLine("Listing groups...");

            ArticulateOnline ao = new ArticulateOnline {Url = url};
            ListGroupsRequest request = new ListGroupsRequest {Credentials = c};
            ListGroupsResponse response = ao.ListGroups(request);
            if (response.Success)
            {
                foreach (GroupSummary gs in response.Groups)
                {
                    Console.WriteLine("{0} {1} {2}", gs.GroupID, gs.Name, gs.Description);
                }
            }
            return response.Success;
        }


        static bool AutoLogin(string url, Credentials c, string autoLoginUrl)
        {
           
            
            Console.WriteLine("Getting AutoLogin Link...");

            ArticulateOnline ao = new ArticulateOnline {Url = url};
            AutoLoginRequest request = new AutoLoginRequest
            {
                Credentials = c,
                Url = autoLoginUrl
            };

            AutoLoginResponse response = ao.GetAutoLoginUrl(request);
            if (response.Success)
            {
                Console.WriteLine(response.Url);
            }
            return response.Success;
        }

        static bool ListDocuments(string url, Credentials c)        
        {
            Console.WriteLine("Listing documents...");

            ArticulateOnline ao = new ArticulateOnline {Url = url};
            ListDocumentsRequest request = new ListDocumentsRequest {Credentials = c};
            ListDocumentsResponse response = ao.ListDocuments(request);
            if (response.Success)
            {
                foreach (DocumentSummary ds in response.Documents)
                {
                    Console.WriteLine("{0} {1} {2}", ds.DocumentID, ds.Name, ds.Description);
                }
            }
            return response.Success;
        }

        static bool AddUserToGroup(string url, Credentials c, string userId, string groupId)
        {
            Console.WriteLine("Adding user to group...");

            ArticulateOnline ao = new ArticulateOnline {Url = url};
            AddUserToGroupRequest request = new AddUserToGroupRequest
            {
                Credentials = c,
                UserID = userId,
                GroupID = groupId
            };


            AddUserToGroupResponse response = ao.AddUserToGroup(request);
            Console.WriteLine("Error: "+response.ErrorMessage);
            return response.Success;

        }

        static bool RemoveUserFromGroup(string url, Credentials c, string userId, string groupId)
        {
            Console.WriteLine("Removing user from group...");

            ArticulateOnline ao = new ArticulateOnline {Url = url};
            RemoveUserFromGroupRequest request = new RemoveUserFromGroupRequest
            {
                Credentials = c,
                UserID = userId,
                GroupID = groupId
            };

            return ao.RemoveUserFromGroup(request).Success;
        }

        static bool GetUserInformation(string url, Credentials c, string userId)
        {
            Console.WriteLine("Get user information...");

            ArticulateOnline ao = new ArticulateOnline {Url = url};
            GetUserInformationRequest request = new GetUserInformationRequest
            {
                Credentials = c,
                UserID = userId
            };
            GetUserInformationResponse response = ao.GetUserInformation(request);
            if (response.Success)
            {
                Console.WriteLine("{0} {1} {2}", response.Profile.EmailAddress, response.Profile.FirstName, response.Profile.LastName);

                Console.WriteLine("Member of:");
                foreach (string groupId in response.MemberOfGroupIDs)
                {
                    Console.WriteLine("\t" + groupId);
                }
               
            }

            return response.Success;            
        }

        static bool GetDocumentSecurity(string url, Credentials c, string documentId)
        {
            Console.WriteLine("Getting document security...");

            ArticulateOnline ao = new ArticulateOnline {Url = url};
            GetDocumentSecurityRequest request = new GetDocumentSecurityRequest
            {
                Credentials = c,
                DocumentID = documentId
            };

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

        static bool UpdateDocumentSecurity(string url, Credentials c, string documentId, PrivacyOption privacyOption, string[] allowedAccountIds)
        {
            Console.WriteLine("Updating document security...");

            ArticulateOnline ao = new ArticulateOnline {Url = url};
            UpdateDocumentSecurityRequest request = new UpdateDocumentSecurityRequest
            {
                Credentials = c,
                DocumentID = documentId,
                AllowedAccountIDs = allowedAccountIds,
                PrivacyOption = privacyOption
            };

            UpdateDocumentSecurityResponse response = ao.UpdateDocumentSecurity(request);            
            return response.Success;
        }       

        static bool GetGroupInformation(string url, Credentials c, string groupId)
        {
            Console.WriteLine("Get group information...");

            ArticulateOnline ao = new ArticulateOnline {Url = url};
            GetGroupInformationRequest request = new GetGroupInformationRequest
            {
                Credentials = c,
                GroupID = groupId
            };
            GetGroupInformationResponse response = ao.GetGroupInformation(request);

            if (response.Success)
            {
                Console.WriteLine("{0} {1} {2}", response.Group.GroupID, response.Group.Name, response.Group.Description);
                Console.WriteLine("Group members:");
                foreach (string userId in response.UserMemberIDs)
                {
                    Console.WriteLine("\t"+userId);
                }
            }
            return response.Success;
        }

        static bool DeleteUser(string url, Credentials c, string userId)
        {
            Console.WriteLine("Deleting user...");

            ArticulateOnline ao = new ArticulateOnline {Url = url};
            DeleteUserRequest request = new DeleteUserRequest
            {
                Credentials = c,
                UserID = userId
            };
            return ao.DeleteUser(request).Success;
        }

        static bool DeleteGroup(string url, Credentials c, string groupId)
        {
            Console.WriteLine("Deleting group...");

            ArticulateOnline ao = new ArticulateOnline {Url = url};
            DeleteGroupRequest request = new DeleteGroupRequest
            {
                Credentials = c,
                GroupID = groupId
            };
            return ao.DeleteGroup(request).Success;
        }

        static bool CreateGroup(string url, Credentials c, string name, string description)        
        {
            Console.WriteLine("Creating group...");

            ArticulateOnline ao = new ArticulateOnline {Url = url};
            CreateGroupRequest request = new CreateGroupRequest
            {
                Credentials = c,
                Name = name,
                Description = description
            };

            CreateGroupResponse response = ao.CreateGroup(request);
            return response.Success;        
        }

        static bool SetUserPassword(string url, Credentials c, string userId, string password)
        {
            Console.WriteLine("Set user password...");

            ArticulateOnline ao = new ArticulateOnline {Url = url};
            SetUserPasswordRequest request = new SetUserPasswordRequest
            {
                Credentials = c,
                UserID = userId,
                Password = password
            };

            return ao.SetUserPassword(request).Success;         
        }


        static bool UpdateGroup(string url, Credentials c, string groupId, string name, string description)
        {
            Console.WriteLine("Update group...");

            ArticulateOnline ao = new ArticulateOnline {Url = url};

            UpdateGroupRequest request = new UpdateGroupRequest
            {
                Credentials = c,
                GroupID = groupId,
                Name = name,
                Description = description
            };

            return ao.UpdateGroup(request).Success;
        }


        static void Main(string[] args)
        {
            if (args.Length < 5)
            {
                var param = "";
                PrintUsage(param, "");
            }
            else
            {
                string url = args[0] + "/services/api/1.0/articulateonline.asmx";
                string command = args[1];
                
                Credentials c = GetCredentials(args);
                bool success = false;
                if (c == null)
                {
                    Console.WriteLine("Credentials were not specified");
                }
                else
                {
                    string extraParams;
                    switch (command)
                    {
                        case "CreateUsers":
                            Console.WriteLine("Not implemented");
                            break;
                        case "UpdateUserProfile":
                            Console.WriteLine("Not implemented");
                            break;
                        case "GetUserInformation":
                            extraParams = " {UserID}";
                            if (EnsureArgs(args, 1, extraParams, command))
                            {
                                success = GetUserInformation(url, c, args[5]);
                            }
                           
                            break;
                        case "SetUserPassword":
                            extraParams = " {UserID} {Password}";
                            if (EnsureArgs(args, 2, extraParams, command))
                            {
                                success = SetUserPassword(url, c, args[5], args[6]);
                            }
                            break;
                        case "ListUsers":
                            success = ListUsers(url, c);
                            break;
                        case "AutoLogin":
                            extraParams = " {URL}";
                            if (EnsureArgs(args, 1, extraParams, command))
                            {
                                success = AutoLogin(url, c, args[5]);
                            }
                            break;
                        case "DeleteUser":
                            extraParams = " {UserID}";
                            if (EnsureArgs(args, 1, extraParams, command))
                            {
                                success = DeleteUser(url, c, args[5]);
                            }                            
                            break;


                        case "CreateGroup":
                            extraParams = " {Name} {Description}";
                            if (EnsureArgs(args, 2, extraParams, command))
                            {
                                success = CreateGroup(url, c, args[5], args[6]);
                            }
                            break;
                        case "DeleteGroup":
                            extraParams = " {GroupID}";
                            if (EnsureArgs(args, 1, extraParams, command))
                            {
                                success = DeleteGroup(url, c, args[5]);
                            }
                            break;
                        case "UpdateGroup":
                            extraParams = " {GroupId} {Name} {Description}";
                            if (EnsureArgs(args, 3, extraParams, command))
                            {
                                success = UpdateGroup(url, c, args[5], args[6], args[7]);
                            }
                            break;
                        case "GetGroupInformation":
                            extraParams = " {GroupID}";
                            if (EnsureArgs(args, 1, extraParams, command))
                            {
                                success = GetGroupInformation(url, c, args[5]);
                            }
                            break;
                        case "ListGroups":
                            success = ListGroups(url, c);
                            break;
                        case "AddUserToGroup":
                            extraParams = " {UserID} {GroupID}";
                            if (EnsureArgs(args, 2, extraParams, command))
                            {
                                success = AddUserToGroup(url, c, args[5], args[6]);
                            }
                            break;
                        case "RemoveUserFromGroup":
                            extraParams = " {UserID} {GroupID}";
                            if (EnsureArgs(args, 2, extraParams, command))
                            {
                                success = RemoveUserFromGroup(url, c, args[5], args[6]);
                            }
                            break;
                            
                        case "InviteUsersToDocument":
                            Console.WriteLine("Not implemented");
                            break;
                        case "ListDocuments":
                            success = ListDocuments(url, c);
                            break;
                        case "GetDocumentSecurity":
                            extraParams = " {DocumentID}";
                            if (EnsureArgs(args, 1, extraParams, command))
                            {
                                success = GetDocumentSecurity(url, c, args[5]);
                            }
                            break;
                        case "UpdateDocumentSecurity":
                            extraParams = " {DocumentId} {PrivacyOption({0}-None)({1}-Public)({2}-Private)} {allowedAccountIds(comma-seperated)}";
                            if (EnsureArgs(args, 3, extraParams, command))
                            {
                                success = UpdateDocumentSecurity(url, c, args[5], (PrivacyOption)Enum.Parse(typeof(PrivacyOption), args[6]), args[7].Split(',') );
                            }
                            break;
                    }

                    if (!success)
                    {
                        Console.WriteLine("An error occured.  Please make sure the request params data is accurate for this request.");
                    }

                    //return success ? 0 : -1;
                }
            }
               
            //return -1;

            Console.Read();  
        }

        static Credentials GetCredentials(string[] arguments)
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

        static void PrintUsage(string param, string command)
        {
            if (command != "")
            {
                Console.WriteLine("The proper params for the " + command + " request are:");
                Console.WriteLine("articulateonlineconsole.exe server_url " + command + " /EmailAddress={youremail@domain.com} /Password={password} /CustomerID={customer_id}" + param);
            }
            {
                Console.WriteLine("The proper params for a request are:");
                Console.WriteLine("articulateonlineconsole.exe server_url request /EmailAddress={youremail@domain.com} /Password={password} /CustomerID={customer_id}" + param);
            }

        }
    }
}