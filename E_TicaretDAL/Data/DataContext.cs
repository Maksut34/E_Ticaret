using E_TicaretEntity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_TicaretDAL.Data
{
    public class DataContext:IdentityDbContext<Users,AppRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Veritabanı bağlantısını burada belirtin
                optionsBuilder.UseSqlServer(@"Server=Maksut12345\SQLEXPRESS02; Database=E_Ticaret; Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");
            }
        }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Image> Image { get; set; }
        public DbSet<Seller> Seller { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<UIBasket> UIBasket { get; set; }
        public DbSet<UIBasket_2> UIBasket_2 { get; set; }

    }

}
