using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsCategories.Models
{
    public class ViewModel
    {
        public Product OneProd { get; set; }
        public Category OneCat { get; set; }
        public ProdCat Association { get; set; }
        public List<Product> AllProds { get; set; }
        public List<Category> AllCats { get; set; }
        public List<ProdCat> Associations { get; set; }
    }
}