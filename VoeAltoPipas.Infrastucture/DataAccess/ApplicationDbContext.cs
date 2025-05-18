using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoeAltoPipas.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace VoeAltoPipas.Infrastucture.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Produtos> Produtos { get; set; }
    }
}
