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
    public class UIBasket_2Manager : UIBasket_2Service
    {
        private readonly IUIBasket_2_DAL _uIBasket_2_;
        public UIBasket_2Manager(IUIBasket_2_DAL uIBasket_2)
        {
            _uIBasket_2_ = uIBasket_2;
        }
        public int Deleted(UIBasket_2 delete)
        {
            return _uIBasket_2_.Deleted(delete);
        }

        public IEnumerable<UIBasket_2> Find(Expression<Func<UIBasket_2, bool>> fınd)
        {
            return _uIBasket_2_.Find(fınd);
        }

        public UIBasket_2 Fınd(Expression<Func<UIBasket_2, bool>> fınd)
        {
            return _uIBasket_2_.Fınd(fınd);
        }

        public List<UIBasket_2> getAll()
        {
            return _uIBasket_2_.getAll();
        }

        public List<UIBasket_2> GetAll(Expression<Func<UIBasket_2, bool>> get)
        {
            return _uIBasket_2_.GetAll(get);
        }

        public int Insert(UIBasket_2 add)
        {
            return _uIBasket_2_.Insert(add);
        }

        public List<UIBasket_2> Lıst(Expression<Func<UIBasket_2, bool>> list)
        {
            return _uIBasket_2_.Lıst(list);
        }

        public int Update(UIBasket_2 up)
        {
            return _uIBasket_2_.Update(up);
        }
    }
}
