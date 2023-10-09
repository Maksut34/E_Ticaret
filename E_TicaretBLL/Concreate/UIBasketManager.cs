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
    public class UIBasketManager : UIBasketService
    {
        private readonly IUIBasket_DAL _uIBasket;
        public UIBasketManager(IUIBasket_DAL uIBasket)
        {
            _uIBasket = uIBasket;
        }
        public int Deleted(UIBasket delete)
        {
            return _uIBasket.Deleted(delete);
        }

        public IEnumerable<UIBasket> Find(Expression<Func<UIBasket, bool>> fınd)
        {
            return _uIBasket.Find(fınd);
        }

        public UIBasket Fınd(Expression<Func<UIBasket, bool>> fınd)
        {
            return _uIBasket.Fınd(fınd);
        }

        public List<UIBasket> getAll()
        {
            return _uIBasket.getAll();
        }

        public List<UIBasket> GetAll(Expression<Func<UIBasket, bool>> get)
        {
            return _uIBasket.GetAll(get);
        }

        public int Insert(UIBasket add)
        {
            return _uIBasket.Insert(add);
        }

        public List<UIBasket> Lıst(Expression<Func<UIBasket, bool>> list)
        {
            return _uIBasket.Lıst(list);        }

        public int Update(UIBasket up)
        {
            return _uIBasket.Update(up);
        }
    }
}
