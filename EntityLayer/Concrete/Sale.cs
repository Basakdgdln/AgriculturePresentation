using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Sale
    {
        public int SaleID { get; set; }
        public string Customer { get; set; }
        public int Piece { get; set; }
        public int TotalAmount { get; set; }
        public DateTime Date { get; set; }


        public int ProductID { get; set; }
        public virtual Product Product { get; set; }
    }
}
