using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Ürünler
    {
        [Key]
        public int UrunID { get; set; }
        public string UrunName { get; set; }
        public int UrunSayi { get; set; }
    }
}
