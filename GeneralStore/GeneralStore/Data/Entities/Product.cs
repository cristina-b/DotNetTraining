using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GeneralStore.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(200)]
        public string Description { get; set; }

        [StringLength(50)]
        public string Brand { get; set; }

        [Required]
        public double Price { get; set; }

    }
}
