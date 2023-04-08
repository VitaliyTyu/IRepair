using System.Collections.Generic;

namespace BD9.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string? ServiceName { get; set; }
        public int? ModelId { get; set; }//внешний ключ
        public Model? Model { get; set; }
        public int? Price { get; set; }
        public List<Order> Orders { get; set; } = new();
    }
}
