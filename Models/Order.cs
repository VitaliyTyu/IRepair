using System;

namespace BD9.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int? ServiceId { get; set; }//внешний ключ1
        public Service? Service { get; set; }

        public string? Warraty { get; set; }

        public int? EmploeeId { get; set; }//внешний ключ2
        public Emploee? Emp { get; set; }

        public int? ClientId { get; set; }//внешний ключ3
        public Client? Client { get; set; }

        public DateTime? AcceptOrd { get; set; }
        public string? Description { get; set; }
        public DateTime? DateIssue { get; set; }
    }
}
