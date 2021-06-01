using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProductMobile
{
   public class Product
    {
        [Key]
        public int id{ get; set; }
        public string nom { get; set; }
        public string description { get; set; }
        public int prix { get; set; }
    }
}
