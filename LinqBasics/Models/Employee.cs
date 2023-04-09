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
        public List<Department> Departments { get; set; }

    }

    class Department
    {
        public string Name { get; set; }
    }
}
