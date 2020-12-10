using DataLayer.Entities;
using DataLayer.Entities.CommonEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public class EFDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Directory> Directories { get; set; }
        public DbSet<SiteWebPage> Pages { get; set; }
        

        public DbSet<CustumContent> CustumContent { get; set; }

        public DbSet<CustumField> CustumFields { get; set; }
        public DbSet<CustumFieldValue> CustumFieldValues { get; set; }

        public EFDBContext(DbContextOptions<EFDBContext> options)
           : base(options)
        {
        }
    }

    public class EFDBContextFactory : IDesignTimeDbContextFactory<EFDBContext>
    {
        public EFDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EFDBContext>();
            optionsBuilder.UseSqlServer("Data Source=wpl27.hosting.reg.ru; Initial Catalog=u0513189_DB; Persist Security Info=False;Integrated Security=False;MultipleActiveResultSets=True; User ID=u0513189_k2moz; Password=474963551aA;", b => b.MigrationsAssembly("DataLayer"));
            //optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=mobilestoredb;Trusted_Connection=True;MultipleActiveResultSets=true", b => b.MigrationsAssembly("DataLayer"));

            //
            //optionsBuilder.UseSqlite("Data Source=blog.db");

            return new EFDBContext(optionsBuilder.Options);
        }
    }
}
