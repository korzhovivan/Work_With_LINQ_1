using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;

namespace LINQ
{
    [Table(Name = "Items")]
    public class Item
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }
        [Column]
        public string Title { get; set; }
        [Column]
        public string Categoty { get; set; }
        [Column]
        public float Weight { get; set; }
        [Column]
        public decimal Price { get; set; }

    }
}