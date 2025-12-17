using System;
using System.Collections.Generic;

namespace UnivPersonnel.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Department { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public string HomeAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Education { get; set; }
        public string GraduatedUniversity { get; set; }
        public int GraduationYear { get; set; }
        public string Speciality { get; set; }
        public string EducationDocument { get; set; }
        public string PhotoPath { get; set; }
        public string AcademicDegree { get; set; }
        public string AcademicTitle { get; set; }
        public string Position { get; set; }
        public string PassportNumber { get; set; }
        public DateTime PassportIssueDate { get; set; }
        public string PassportIssuedBy { get; set; }
        public DateTime EmploymentStartDate { get; set; }

        public List<PreviousWorkplace> PreviousWorkplaces { get; set; } = new();
        public List<PositionChange> PositionChanges { get; set; } = new();
        public List<Sanction> Sanctions { get; set; } = new();
        public List<Reward> Rewards { get; set; } = new();
    }
}
