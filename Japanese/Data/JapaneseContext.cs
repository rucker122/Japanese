using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Japanese.Models;

namespace Japanese.Data
{
    public class JapaneseContext : DbContext
    {
        public JapaneseContext (DbContextOptions<JapaneseContext> options)
            : base(options)
        {
        }

        public DbSet<Japanese.Models.VOCABULARY> VOCABULARY { get; set; }
        public DbSet<Japanese.Models.SPEECH> SPEECH { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

    }
}
