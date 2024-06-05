using JustWatch.Domain.Entities.JustWatch;
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
         public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>(entity =>
            {
                // Specify the table name (optional if your table name matches the class name)
                entity.ToTable("Users");

                // Specify primary key
                entity.HasKey(e => e.Id);

                // Configure columns
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Username).HasColumnName("username").HasMaxLength(50).IsRequired();
                entity.Property(e => e.Email).HasColumnName("email").HasMaxLength(100).IsRequired();
                entity.Property(e => e.PasswordHash).HasColumnName("password_hash").HasMaxLength(100).IsRequired();
                entity.Property(e => e.CreatedAt).HasColumnName("created_at").IsRequired();
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at").IsRequired();
            });
            base.OnModelCreating(modelBuilder);

        }
    }
 }
