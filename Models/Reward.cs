using System;

namespace UnivPersonnel.Models
{
    public class Reward
    {
        public int Id { get; set; }
        public string Type { get; set; } // Вид поощрения
        public DateTime OrderDate { get; set; }
        public string OrderNumber { get; set; }
        public string Notes { get; set; }
    }
}
