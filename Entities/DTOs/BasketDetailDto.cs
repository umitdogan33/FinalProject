using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
   public class BasketDetailDto
    {
        public long BasketId { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public string ProductName { get; set; }
        public int Count { get; set; }
    }
}
