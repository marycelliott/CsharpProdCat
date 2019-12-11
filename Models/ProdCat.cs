using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsCategories.Models
{
    public class ProdCat
    {
        [Key]
        public int ProdCatId { get; set; }
        [Required]
        public int ProdId { get; set; }
        [Required]
        public int CatId { get; set; }

        public Category Category { get; set; }
        public Product Product { get; set; }
    }
}