using System;

namespace UnivPersonnel.Models
{
    public class Sanction
    {
        public int Id { get; set; }
        public string Type { get; set; } // Вид взыскания
        public DateTime OrderDate { get; set; }
        public string OrderNumber { get; set; }
        public string Notes { get; set; }
    }
}
