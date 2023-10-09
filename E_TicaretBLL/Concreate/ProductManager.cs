using E_TicaretBLL.Abstract;
using E_TicaretDAL.Abstract;
using E_TicaretDAL.Concreate;
using E_TicaretEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_TicaretBLL.Concreate
{
    public class ProductManager : ProductService
    {
        private readonly IProduct_DAL _product;
        public ProductManager(IProduct_DAL product)
        {
            _product= product;
        }
        public int Deleted(Product delete)
        {
            return _product.Deleted(delete);
        }

        public IEnumerable<Product> Find(Expression<Func<Product, bool>> fınd)
        {
            return _product.Find(fınd);
        }

        public Product Fınd(Expression<Func<Product, bool>> fınd)
        {
            return _product.Fınd(fınd);
        }

        public List<Product> getAll()
        {
            return _product.getAll();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> get)
        {
            return _product.GetAll(get);
        }

        public int Insert(Product add)
        {
            return _product.Insert(add);
        }

        public List<Product> Lıst(Expression<Func<Product, bool>> list)
        {
            return _product.Lıst(list);
        }

        public int Update(Product up)
        {
            return _product.Update(up);
        }
    }
}
