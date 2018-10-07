using System;
using System.Collections.Generic;

namespace ShafiqWebAppAccess2RDS.Models
{
    public partial class Student
    {
        public Student()
        {
            Enrollment = new HashSet<Enrollment>();
        }

        public string StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Program { get; set; }

        public Login Login { get; set; }
        public ICollection<Enrollment> Enrollment { get; set; }
    }
}
