using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_TicaretDAL.RepoStory
{
    public interface IRepoStory<T>
    {
        int Insert(T add);
        int Update(T up);
        int Deleted(T delete);
        List<T> getAll();
        List<T> GetAll(Expression<Func<T, bool>> get);
        List<T> Lıst(Expression<Func<T, bool>> list);
        IEnumerable <T> Find(Expression<Func<T, bool>> fınd);
        T Fınd(Expression<Func<T, bool>> fınd);
    }
}
