using System;
using System.Collections.Generic;

namespace ShafiqWebAppAccess2RDS.Models
{
    public partial class Enrollment
    {
        public string StudentId { get; set; }
        public string CourseCode { get; set; }

        public Course CourseCodeNavigation { get; set; }
        public Student Student { get; set; }
    }
}
