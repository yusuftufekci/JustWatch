using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustWatch.Infrastructure.Context
{
    public class JustWatchContext : DbContext
    {
        public JustWatchContext(DbContextOptions<JustWatchContext> options)
           : base(options)
        {
        }
        // public virtual DbSet<TargetDynamicBanner> TargetDynamicBanner { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
 }
