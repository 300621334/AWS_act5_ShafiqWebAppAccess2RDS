using System;
using System.Collections.Generic;

namespace ShafiqWebAppAccess2RDS.Models
{
    public partial class Login
    {
        public string LoginName { get; set; }
        public string Password { get; set; }

        public Student LoginNameNavigation { get; set; }
    }
}
