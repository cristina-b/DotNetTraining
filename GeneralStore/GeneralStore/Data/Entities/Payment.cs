using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GeneralStore.Entities
{
    public class Payment
    {        
        public int Id { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public int OrderId { get; set; }

        [Required]
        public double Amount { get; set; }

    }
}
