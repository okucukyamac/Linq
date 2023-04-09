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
                new Employee() {Id= 1,Name="Preety",AddressId=1} ,
                new Employee() {Id= 2,Name="Priyanka",AddressId=2} ,
                new Employee() {Id= 3,Name="Anurag",AddressId=3} ,
                new Employee() {Id= 4,Name="Pranaya",AddressId=4} ,
                new Employee() {Id= 5,Name="Hina",AddressId=12} ,
                new Employee() {Id= 6,Name="Sambit",AddressId=10} ,
                new Employee() {Id= 7,Name="Happy",AddressId=6} ,
                new Employee() {Id= 8,Name="Tarun",AddressId=4} ,
                new Employee() {Id= 9,Name="Santosh",AddressId=3},
                new Employee() {Id= 10,Name="Raja",AddressId=2},
                new Employee() {Id= 11,Name="Sudhanshu",AddressId=7}
            };

            List<Address> addresses = new List<Address>()
            {
                new Address() {Id= 1,AddressLine="AddressLine1"},
                new Address() {Id= 2,AddressLine="AddressLine2"},
                new Address() {Id= 3,AddressLine="AddressLine3"},
                new Address() {Id= 4,AddressLine="AddressLine4"},
                new Address() {Id= 5,AddressLine="AddressLine5"},
                new Address() {Id= 6,AddressLine="AddressLine6"},
                new Address() {Id= 7,AddressLine="AddressLine7"},
            };

            var result = employees.Join(addresses, emp => emp.AddressId, add => add.Id, (emp, add) => new
            {
                EmployeeId = emp.Id,
                EmployeName = emp.Name,
                AdressLine = add.AddressLine
            }).ToList();

            result.ForEach(a =>
            {
                Console.WriteLine(a.EmployeeId + " - " + a.AdressLine + " - " + a.EmployeName);
            });

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
