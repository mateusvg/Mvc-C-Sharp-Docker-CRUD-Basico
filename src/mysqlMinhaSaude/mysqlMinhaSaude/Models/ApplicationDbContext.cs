using Microsoft.EntityFrameworkCore;
using mysqlMinhaSaude.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaSaude.Models
{

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<CaixinhaDeRemedios> mysqlcsharpems { get; set; }
    }

}
