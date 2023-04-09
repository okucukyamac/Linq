using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;
using LinqBasics.Abstract;
using LinqBasics.Models;

namespace LinqBasics
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<Employee> employees = new List<Employee>()
            {
                new Employee() {Id= 1,Name="Fatih",AddressId=1,DepartmentId=10} ,
                new Employee() {Id= 2,Name="Erhan",AddressId=2,DepartmentId=20} ,
                new Employee() {Id= 3,Name="Şafak",AddressId=3,DepartmentId=30} ,
                new Employee() {Id= 4,Name="Oğuz",AddressId=4,DepartmentId=0} ,
                new Employee() {Id= 5,Name="Yağır",AddressId=5,DepartmentId=0} ,
                new Employee() {Id= 6,Name="Murat",AddressId=6,DepartmentId=0} ,
                new Employee() {Id= 7,Name="Bahri",AddressId=7,DepartmentId=0} ,
                new Employee() {Id= 8,Name="Nedim",AddressId=8,DepartmentId=0} ,
                new Employee() {Id= 9,Name="Osman",AddressId=9,DepartmentId=10} ,
                new Employee() {Id= 10,Name="Ali",AddressId=10,DepartmentId=20} ,
                new Employee() {Id= 11,Name="Ömer",AddressId=11,DepartmentId=30}
            };

            List<Address> addresses = new List<Address>()
            {
                new Address() {Id= 1,AddressLine="AddressLine1"},
                new Address() {Id= 2,AddressLine="AddressLine2"},
                new Address() {Id= 3,AddressLine="AddressLine3"},
                new Address() {Id= 4,AddressLine="AddressLine4"},
                new Address() {Id= 5,AddressLine="AddressLine5"},
                new Address() {Id= 9,AddressLine="AddressLine9"},
                new Address() {Id= 10,AddressLine="AddressLine10"},
                new Address() {Id= 11,AddressLine="AddressLine11"}
            };

            List<Department> departments = new List<Department>()
            {
                new Department{Id=10,Name="IT"},
                new Department{Id=20,Name="HR"},
                new Department{Id=30,Name="Payroll"}
            };

            var result = from emp in employees
                         join add in addresses on emp.AddressId equals add.Id
                         join dep in departments on emp.DepartmentId equals dep.Id
                         select new
                         {
                             EmpId = emp.Id,
                             EmpName = emp.Name,
                             add.AddressLine,
                             DemartmantName = dep.Name

                         };

            foreach (var item in result)
            {
                Console.WriteLine($"{item.EmpId} - {item.EmpName} - {item.AddressLine} - {item.DemartmantName}");
            }


            //Methods.JoinInnerJoin();
            //Methods.GroupBy();
            //Methods.SumMaxMinAverageCountAggregate();
            //Methods.SelectMany();
            //Methods.EqualsContainsEndWithStartWith();
            //Methods.Any();
            //Methods.All();
            //Methods.Distinct();
            //Methods.ExceptUnionConcatIntersect();
            //Methods.Reverse();
            //Methods.ThenBy();
            //Methods.OrderBy();
            //Methods.OfType();
            //Methods.IEnumerable_IQueryable();
            //Methods.UsingWhere();
            //Methods.Syntaxes();
        }

    }
}
