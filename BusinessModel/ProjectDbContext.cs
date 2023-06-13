using DataModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using BusinessModel.DataModels.Models;

namespace BusinessModel
{
    class ProjectDbContext : DbContext
    {

        public ProjectDbContext() : base(GetOptions()) { }
        private static DbContextOptions GetOptions()
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), "Server=.;Database=AfpApi;user=sa;password=Bufete2018").Options;
        }
        public DbSet<Genders> Genders { get; set; }
        public DbSet<Person> Person { get; set; }
    }
}
