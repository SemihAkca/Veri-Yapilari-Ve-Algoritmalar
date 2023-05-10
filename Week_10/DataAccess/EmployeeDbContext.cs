using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class EmployeeDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = C:\Users\win10\Desktop\MYAZ206\Veri_Yapıları_Ve_Algoritmalar\Week_10\SortingAlgoritmsApp\Employee.db;");
        }

        public DbSet<Employee> Employees { get; set; }
    }
}   
