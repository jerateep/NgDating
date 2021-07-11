using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace API.Data
{
    public class DataContext : DbContext
    {
        //public DataContext()
        //{

        //}
        public DataContext(DbContextOptions<DataContext> options)
          : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //string Constr = "server=localhost;database=KMS;user=root;password=Abc@12345;TreatTinyAsBoolean=true;";
                //optionsBuilder.UseSqlServer(Constr, o => o.EnableRetryOnFailure());
            }
        }
        public DbSet<AppUser> AppUser { get; set; }
        public DbSet<Photo> Photos { get; set; }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //}
    }
}
