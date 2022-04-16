using Microsoft.EntityFrameworkCore;
using Online_Shopping_Domain.Entities;
using System;

namespace Online_Shopping_Domain
{
    public class ApplicationContext :DbContext
    {
        public ApplicationContext()
        {

        }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
              : base(options)
        {
        }




        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
