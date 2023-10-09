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
    public class İmageManager : İmageService
    { 
        private readonly Iİmage_DAL _imageDAL;

        public İmageManager(Iİmage_DAL image_DAL)
        {
            _imageDAL = image_DAL;
        }
        public int Deleted(Image delete)
        {
            return _imageDAL.Deleted(delete);
        }

        public IEnumerable<Image> Find(Expression<Func<Image, bool>> fınd)
        {
            return _imageDAL.Find(fınd);
        }

        public Image Fınd(Expression<Func<Image, bool>> fınd)
        {
            return _imageDAL.Fınd(fınd);
        }

        public List<Image> getAll()
        {
            return _imageDAL.getAll();
        }

        public List<Image> GetAll(Expression<Func<Image, bool>> get)
        {
            return _imageDAL.GetAll(get);
        }

        public int Insert(Image add)
        {
            return _imageDAL.Insert(add);
        }

        public List<Image> Lıst(Expression<Func<Image, bool>> list)
        {
            return _imageDAL.Lıst(list);
        }

        public int Update(Image up)
        {
            return _imageDAL.Update(up);
        }
    }
}
