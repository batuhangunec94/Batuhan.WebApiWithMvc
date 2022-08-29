using System;

namespace Batuhan.WebApi.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Hp { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string İmgPath { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
