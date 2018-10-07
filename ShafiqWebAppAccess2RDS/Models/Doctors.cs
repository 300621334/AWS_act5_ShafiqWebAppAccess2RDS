using System;
using System.Collections.Generic;

namespace ShafiqWebAppAccess2RDS.Models
{
    public partial class Doctors
    {
        public int IdDoc { get; set; }
        public int? IdUser { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Specialty { get; set; }

        public Users IdUserNavigation { get; set; }
    }
}
