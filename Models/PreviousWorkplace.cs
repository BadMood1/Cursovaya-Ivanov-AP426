using System;

namespace UnivPersonnel.Models
{
    public class PreviousWorkplace
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyPhone { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string LastPosition { get; set; }
        public string DismissalReason { get; set; }
    }
}
