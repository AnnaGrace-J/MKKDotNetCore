using Microsoft.EntityFrameworkCore;
using MKKDotNetCore.ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKKDotNetCore.ConsoleApp
{
    internal class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Data Source=.; Initial Catalog=DotNetTraining; User Id=sa; Password = sasa@123; TrustServerCertificate=True;";
            optionsBuilder.UseSqlServer(connectionString);
        }
        public DbSet<BlogDataModel> Blogs { get; set; }
    }
    }
