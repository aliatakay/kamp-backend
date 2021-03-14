/* Kodların altında açıklamalar var. */

using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    // context: db tabloları ile proje classlarını bağlamak anlamı taşır.
    public class NorthwindContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Northwind;Trusted_Connection=true");
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }

    }
}

/* 
            Bizim sınıfımızın adını Context yaptık ama işlevsel olarak da Context yapmamız için
            DbContext sınıfından kalıtım almamız lazım.
            
            burdaki amaç db tabloları ile proje classlarını bağlamak.

            o halde ilk olarak benim db'mi projeme belirtmem lazım. sonuçta projeye bağlamaya çalıştığım bir db var.
            işte burada abstract sınıfın override metot ezme özelliğini kullacağız.

            OnConfiguring bu metot sayesinde, ben veritabanımın nerede olduğunu projeye bildireceğim.

            optionsBuilder.UseSqlServer(); ile bağlayacağım sql server'ı belirteceğim.
            içine bir connection string vereceğiz.

            
            public DbSet<Product> Products { get; set; } Product sınıfımızı, Products tablosu ile eşleştirdik.
 */
