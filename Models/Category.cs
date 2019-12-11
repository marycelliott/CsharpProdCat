using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsCategories.Models
{
    public class Category
    {
        [Key]
        public int CatId { get; set; }
        [Required(ErrorMessage="Name is required.")]
        [MinLength(4, ErrorMessage="Name must be at least 4 characters long.")]
        public string Name { get; set; }
        public DateTime CreatedAt { get; set;} = DateTime.Now;
        public DateTime UpdatedAt { get; set;} = DateTime.Now;

        public List<ProdCat> Associations { get; set; }
    }
}