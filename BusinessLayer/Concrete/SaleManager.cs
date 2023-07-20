using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class SaleManager : ISaleService
    {
        private readonly ISaleDal _saleDal;

        public SaleManager(ISaleDal saleDal)
        {
            _saleDal = saleDal;
        }

        public void Delete(Sale t)
        {
            throw new NotImplementedException();
        }

        public Sale GetById(int id)
        {
            return _saleDal.GetById(id);
        }

        public List<Sale> GetListAll()
        {
            return _saleDal.GetListAll();
        }

        public List<Sale> GetListWithProduct()
        {
            return _saleDal.GetListWithProduct();
        }

        public void Insert(Sale t)
        {
            _saleDal.Insert(t);
        }

        public void Update(Sale t)
        {
            _saleDal.Update(t);
        }
    }
}
