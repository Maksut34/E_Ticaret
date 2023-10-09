using E_TicaretBLL.Abstract;
using E_TicaretEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_TicaretBLL.Concreate
{
    public class UsersManager : UsersService
    {
        private readonly UsersService _usersService;
        public UsersManager(UsersService usersService)
        {
            _usersService = usersService;
        }
        public int Deleted(Users delete)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Users> Find(Expression<Func<Users, bool>> fınd)
        {
            throw new NotImplementedException();
        }

        public Users Fınd(Expression<Func<Users, bool>> fınd)
        {
            return _usersService.Fınd(fınd);
        }

        public List<Users> getAll()
        {
            throw new NotImplementedException();
        }

        public List<Users> GetAll(Expression<Func<Users, bool>> get)
        {
            throw new NotImplementedException();
        }

        public int Insert(Users add)
        {
            throw new NotImplementedException();
        }

        public List<Users> Lıst(Expression<Func<Users, bool>> list)
        {
            throw new NotImplementedException();
        }

        public int Update(Users up)
        {
            throw new NotImplementedException();
        }
    }
}
