using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Product
{
   public class Product
    {

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
    }
}
