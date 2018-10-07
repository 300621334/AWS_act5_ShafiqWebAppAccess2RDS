using System;
using System.Collections.Generic;

namespace ShafiqWebAppAccess2RDS.Models
{
    public partial class Appointments
    {
        public int IdAppointment { get; set; }
        public int IdUser { get; set; }
        public string Clinic { get; set; }
        public string Doctor { get; set; }
        public string AppointmentTime { get; set; }
        public string CreationTime { get; set; }
        public string DrAvailable { get; set; }
        public int? IdDoc { get; set; }

        public Users IdUserNavigation { get; set; }
    }
}
