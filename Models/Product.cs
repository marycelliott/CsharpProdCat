using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsCategories.Models
{
    public class Product
    {
        [Key]
        public int ProdId { get; set; }
        [Required(ErrorMessage="Name is required.")]
        [MinLength(4, ErrorMessage="Name must be at least 4 characters long.")]
        public string Name { get; set; }
        [Required(ErrorMessage="Description is required.")]
        [MinLength(10, ErrorMessage="Name must be at least 10 characters long.")]
        public string Description { get; set; }
        [Required(ErrorMessage="Price is required.")]
        [Range(1.00,1000.00, ErrorMessage="Price must be between $1.00 and $1,000.00.")]
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set;} = DateTime.Now;
        public DateTime UpdatedAt { get; set;} = DateTime.Now;

        public List<ProdCat> Associations { get; set; }
    }
}