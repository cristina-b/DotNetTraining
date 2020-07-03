using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

public enum OrderStatus
{
    NotShipped,
    Sent,
    Received
}

namespace GeneralStore.Entities
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Address { get; set; }

        public OrderStatus OrderStatus { get; set; }

    }
}
