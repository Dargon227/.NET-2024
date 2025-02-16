﻿using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    internal class DBContext : DbContext 
    {
        private string _connectionString = "Server=DESKTOP-RUNEDMC\\SQLEXPRESSNET;Database=practico1;User id=sa; Password=admin123;TrustServerCertificate=True";
        
        public DBContext() {}

        public DBContext(DbContextOptions<DBContext> options) : base(options) {}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Personas> Personas { get; set; }
        public DbSet<Vehiculos> Vehiculos { get; set; }
    }
}
