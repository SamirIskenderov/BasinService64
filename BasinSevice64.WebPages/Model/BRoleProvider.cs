using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace BasinSevice64.WebPages.Model
{
    public class BRoleProvider : RoleProvider
    {
        public static string AdminName { get; } = "C8671A5B-0ED5-4E07-8A80-1BD1E358364B";

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            if (username == "C8671A5B-0ED5-4E07-8A80-1BD1E358364B")
            {
                return new string[] { "Admins" };
            }

            return new string[] { };
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            if (username == "C8671A5B-0ED5-4E07-8A80-1BD1E358364B")
            {
                return true;
            };

            return false;
        }

        public static bool IsPassValid(string pass)
        {
            if (string.IsNullOrWhiteSpace(pass) || pass != ConfigurationManager.AppSettings["AdminPass"].ToString())
            {
                return false;
            }

            return true;
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}