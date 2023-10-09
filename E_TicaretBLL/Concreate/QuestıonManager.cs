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
    public class QuestıonManager : QuestıonService
    {
        private readonly IQuestıon_DAL _questıon;
        public QuestıonManager(IQuestıon_DAL questıon)
        {
            _questıon = questıon;
        }
        public int Deleted(Question delete)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Question> Find(Expression<Func<Question, bool>> fınd)
        {
            throw new NotImplementedException();
        }

        public Question Fınd(Expression<Func<Question, bool>> fınd)
        {
            throw new NotImplementedException();
        }

        public List<Question> getAll()
        {
            throw new NotImplementedException();
        }

        public List<Question> GetAll(Expression<Func<Question, bool>> get)
        {
            throw new NotImplementedException();
        }

        public int Insert(Question add)
        {
            return _questıon.Insert(add);
        }

        public List<Question> Lıst(Expression<Func<Question, bool>> list)
        {
            throw new NotImplementedException();
        }

        public int Update(Question up)
        {
            throw new NotImplementedException();
        }
    }
}
