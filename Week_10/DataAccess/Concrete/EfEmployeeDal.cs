using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using Entities;

namespace DataAccess.Concrete
{
    public class EfEmployeeDal : IEmployeeDal
    {
        public List<Employee> GetEmployees(Func<Employee, bool> filter = null)
        {
            using (EmployeeDbContext context = new EmployeeDbContext())
            {
                return filter == null ? context.Set<Employee>().ToList()
                    : context.Set<Employee>().Where(filter).ToList();
            }

            #region ADO NET İle Sqlite Üzerinden Veri Getirme 
            //ADO Net ile sqlite üzerinden veri getirme
            //var employees = new List<Employee>();
            //string connectionString = "Data Source = C:\\Users\\win10\\Desktop\\MYAZ206\\Veri_Yapıları_Ve_Algoritmalar\\Week_10\\SortingAlgoritmsApp\\Employee.db;";
            //using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            //{
            //    connection.Open();
            //    string sorgu = "SELECT * FROM Employees;";

            //    using (SQLiteCommand command = new SQLiteCommand(sorgu, connection))
            //    {
            //        using (SQLiteDataReader reader = command.ExecuteReader())
            //        {
            //            while (reader.Read())
            //            {
            //                int id = Convert.ToInt32(reader["ID"]);
            //                string firstName = reader["firstName"].ToString();
            //                string lastName = reader["lastName"].ToString();
            //                decimal salary = Convert.ToDecimal(reader["salary"]);

            //                employees.Add(new Employee { Id = id, FirstName = firstName, LastName = lastName, Salary = salary });
            //            }
            //        }
            //    }
            //}

            //return filter == null
            //    ? employees
            //    : employees.Where(filter).ToList();
            #endregion
        }
    }
}
