using System;
using System.Collections.Generic;

namespace ShafiqWebAppAccess2RDS.Models
{
    public partial class Users
    {
        public Users()
        {
            Appointments = new HashSet<Appointments>();
            Doctors = new HashSet<Doctors>();
        }

        public int IdUser { get; set; }
        public string NameOfUser { get; set; }
        public string LoginName { get; set; }
        public string Pw { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }

        public ICollection<Appointments> Appointments { get; set; }
        public ICollection<Doctors> Doctors { get; set; }
    }
}
