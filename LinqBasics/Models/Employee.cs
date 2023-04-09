using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqBasics.Models
{
    internal class Employee
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int AddressId { get; set; }
        public int DepartmentId { get; set; }
        public List<Department> Departments { get; set; }

    }

    public class Address
    {
        public int Id { get; set; }
        public string AddressLine { get; set; }
    }

    class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
