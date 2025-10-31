﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VietLife.Permissions
{
    public static class ExtendedIdentityPermissions
    {
        public static class Users
        {
            public const string View = "AbpIdentity.Users.View";
        }

        public static class Roles
        {
            public const string View = "AbpIdentity.Roles.View";
        }
    }
}
