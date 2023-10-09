using E_TicaretDAL.Abstract;
using E_TicaretDAL.Data;
using E_TicaretDAL.RepoStory;
using E_TicaretEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_TicaretDAL.Concreate
{
    public class Seller_DAL:GRepoStory<Seller,DataContext>,ISeller_DAL
    {
    }
}
