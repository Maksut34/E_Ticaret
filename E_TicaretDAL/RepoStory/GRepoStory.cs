using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_TicaretDAL.RepoStory
{
    public class GRepoStory<T, TContext> : IRepoStory<T> where T : class where TContext : DbContext, new()
    {
        public int Deleted(T delete)
        {
            using (var context = new TContext())
            {
                context.Set<T>().Remove(delete);
                return context.SaveChanges();
            }
        }

        public IEnumerable <T> Find(Expression<Func<T, bool>> fınd)
        {
            using (var context = new TContext())
            {
                return context.Set<T>().Where(fınd).ToList();
            }
        }

        public List<T> getAll()
        {
            using (var context = new TContext())
            {
                return context.Set<T>().ToList();
            }
        }
        private readonly TContext _context;

        public GRepoStory()
        {
            _context = new TContext();
        }

        public List<T> GetAll(Expression<Func<T, bool>> get)
        {
            return _context.Set<T>().ToList();
        }

        public int Insert(T add)
        {
            using (var context = new TContext())
            {
                context.Set<T>().Add(add);
                return context.SaveChanges();
            }
        }

        public List<T> Lıst(Expression<Func<T, bool>> list)
        {
            using (var context = new TContext())
            {
                return context.Set<T>().Where(list).ToList();
            }
        }

        public int Update(T up)
        {
            using (var context = new TContext())
            {
                context.Set<T>().Update(up);
                return context.SaveChanges();
            }
        }

        public T Fınd(Expression<Func<T, bool>> fınd)
        {
            using (var context = new TContext())
            {
                return context.Set<T>().FirstOrDefault(fınd);
            }
        }
    }
}
