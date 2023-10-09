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
    
    public class CommentManager : CommentService
    {
        private readonly IComment_DAL _comment;
        public CommentManager(IComment_DAL comment)
        {
            _comment = comment;
        }
        public int Deleted(Comment delete)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Comment> Find(Expression<Func<Comment, bool>> fınd)
        {
            throw new NotImplementedException();
        }

        public Comment Fınd(Expression<Func<Comment, bool>> fınd)
        {
            throw new NotImplementedException();
        }

        public List<Comment> getAll()
        {
            return _comment.getAll();
        }

        public List<Comment> GetAll(Expression<Func<Comment, bool>> get)
        {
            throw new NotImplementedException();
        }

        public int Insert(Comment add)
        {
            return _comment.Insert(add);
        }

        public List<Comment> Lıst(Expression<Func<Comment, bool>> list)
        {
            throw new NotImplementedException();
        }

        public int Update(Comment up)
        {
            throw new NotImplementedException();
        }
    }
}
