using System;

namespace Batuhan.UI.Models.Dto
{
    public class CarsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Hp { get; set; }
        public DateTime CreatedDate { get; set; }
        public string İmgPath { get; set; }
        public int CategoryId { get; set; }
    }
}
