using Microsoft.EntityFrameworkCore;
using Orange.Services.ShoppingCartAPI.Model;
using Orange.Services.ShoppingCartAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orange.Services.ShoppingCartAPI.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }    
        public DbSet<CartDetails> CartDetails { get; set; }
        public DbSet<CartHeader> CartHeaders {get; set; }



    }
}
