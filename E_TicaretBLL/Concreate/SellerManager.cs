using E_TicaretBLL.Abstract;
using E_TicaretDAL.Abstract;
using E_TicaretEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_TicaretBLL.Concreate
{
    public class SellerManager : SellerService
    {
        private readonly ISeller_DAL _seller;
        public SellerManager(ISeller_DAL seller)
        {
            _seller = seller;
        }
        public int Deleted(Seller delete)
        {
            return _seller.Deleted(delete);
        }

        public IEnumerable<Seller> Find(Expression<Func<Seller, bool>> fınd)
        {
            return _seller.Find(fınd);
        }

        public Seller Fınd(Expression<Func<Seller, bool>> fınd)
        {
            return _seller.Fınd(fınd);
        }

        public List<Seller> getAll()
        {
            return _seller.getAll();
        }

        public List<Seller> GetAll(Expression<Func<Seller, bool>> get)
        {
            return _seller.GetAll(get);
        }

        public int Insert(Seller add)
        {
            return _seller.Insert(add);
        }

        public List<Seller> Lıst(Expression<Func<Seller, bool>> list)
        {
            return _seller.Lıst(list);
        }

        public int Update(Seller up)
        {
            return _seller.Update(up);
        }
    }
}
