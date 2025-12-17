using System;

namespace UnivPersonnel.Models
{
    public class PositionChange
    {
        public int Id { get; set; }
        public string Reason { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderNumber { get; set; }
        public string NewPosition { get; set; }
    }
}
