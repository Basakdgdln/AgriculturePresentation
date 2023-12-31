﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string ImagePath { get; set; }
        public bool Status { get; set; }


        //public int CategoryID { get; set; }
        //public virtual Category Category { get; set; }
        public ICollection<Sale> Sales { get; set; }

    }
}
