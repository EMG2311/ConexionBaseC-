using A.CMD.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A.CMD
{
    internal class CodeFirstDbContext : DbContext
    {
        public virtual DbSet<Customer>  Customers { get; set; } 
        public virtual DbSet<Booking> Booking { get; set; }
        public virtual DbSet<Destination> Destination { get; set; }
        public CodeFirstDbContext(){}

        

        public CodeFirstDbContext(DbContextOptions<CodeFirstDbContext> options): base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=roundhouse.proxy.rlwy.net;port=53156;database=railway;user=root;password=iDnoBfPAMxqlHlVoWdwZNblYujqIUvZT;SslMode=none;");
        }

     

    }

}
