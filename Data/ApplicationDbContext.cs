using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Rest_API_with_ASP.NET_Core_Part_1.Models;

namespace Rest_API_with_ASP.NET_Core_Part_1.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base (options)
        {
        }

        public DbSet<Produto> Produtos {get;set;}
    }
}