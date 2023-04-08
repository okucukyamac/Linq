﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;
using LinqBasics.Models;

namespace LinqBasics
{

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Course> courses = new List<Course>();

            courses.Add(new Course { Id = 1, Subject = "Linq", Rank = 4 });
            courses.Add(new Course { Id = 2, Subject = ".Net", Rank = 5 });
            courses.Add(new Course { Id = 3, Subject = "C#", Rank = 3 });

            var result = from c in courses
                         where c.Rank > 3 && c.Subject.Contains("Li")
                         select c;

            var result2 = courses.Where(a => a.Rank > 3 && a.Subject.Contains("Net"));

            foreach (var item in result)
            {
                Console.WriteLine(item.Subject);
            }
            
            foreach (var item in result2)
            {
                Console.WriteLine(item.Subject);
            }

            //Syntaxes();

        }

        private static void Syntaxes()
        {
            List<Student> students = new List<Student>();

            students.Add(new Student { Id = 1, Name = "Oğuz" });
            students.Add(new Student { Id = 2, Name = "Fatih" });
            students.Add(new Student { Id = 3, Name = "Mesut" });

            var result = from s in students
                         where s.Name.Contains("F")
                         select s;

            var result2 = students.Where(a => a.Name.Contains("F"));

            Console.WriteLine(result.First().Name);
            Console.WriteLine(result2.First().Name);
        }
    }
}
