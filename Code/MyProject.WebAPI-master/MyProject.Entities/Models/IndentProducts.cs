using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.Entities.Models
{
    public class IndentProducts
    {
        public int Id { get; set; }
        public int IndentId { get; set; }
        public int CategoryId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductQuantity { get; set; }
        public int UnitId { get; set; }
    }
}
