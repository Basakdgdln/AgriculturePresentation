using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repository;
using DataAccessLayer.Contexts;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfSaleDal : GenericRepository<Sale>, ISaleDal
    {
        public List<Sale> GetListWithProduct()
        {
            using (var context = new AgricultureContext())
            {
                return context.Sales.Include(x => x.Product).ToList();
            }
        }
    }
}
