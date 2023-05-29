using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract;
using Entities;

namespace Business.Conrete
{
    public class EmployeeManager:IEmployeeService
    {
        private IEmployeeDal _employeeDal ;

        public EmployeeManager(IEmployeeDal employeeDal)
        {
            _employeeDal = employeeDal;
        }
        public List<Employee> GetEmployees(Func<Employee,bool> filter = null)
        {
            return _employeeDal.GetEmployees(filter);
        }
    }
}
