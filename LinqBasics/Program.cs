using System;
using System.Collections;
using System.Collections.Generic;
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
            EqualsContainsEndWithStartWith();

            //Any();
            //All();
            //Distinct();
            //ExceptUnionConcatIntersect();
            //Reverse();
            //ThenBy();
            //OrderBy();
            //OfType();
            //IEnumerable_IQueryable();
            //UsingWhere();
            //Syntaxes();
        }

        private static void EqualsContainsEndWithStartWith()
        {
            List<Student> students = new List<Student>();

            students.Add(new Student() { Id = 1, Name = "Ramesh", Rank = 1, Age = 39, IsFeesSubmitted = true });
            students.Add(new Student() { Id = 2, Name = "Kapil", Rank = 1, Age = 32, IsFeesSubmitted = true });
            students.Add(new Student() { Id = 3, Name = "Suresh", Rank = 2, Age = 45, IsFeesSubmitted = true });
            students.Add(new Student() { Id = 3, Name = "Mahesh", Rank = 2, Age = 39, IsFeesSubmitted = true });

            var equals = students.Where(a => a.Name.Equals("Ramesh"));//aynısını getir
            var contains = students.Where(a => a.Name.Contains("esh"));//içerenleri getir
            var endWith = students.Where(a => a.Name.EndsWith("esh"));//bitenleri getir
            var startWith = students.Where(a => a.Name.StartsWith("Ka"));//başlayanları getir

            foreach (var student in equals)
                Console.WriteLine(student.Name);
            Console.WriteLine("");
            foreach (var student in contains)
                Console.WriteLine(student.Name);
            Console.WriteLine("");

            foreach (var student in endWith)
                Console.WriteLine(student.Name);
            Console.WriteLine("");

            foreach (var student in startWith)
                Console.WriteLine(student.Name);
            Console.WriteLine("");
        }

        private static void Any()
        {
            List<Student> students = new List<Student>();

            if (students.Any())
                Console.WriteLine("eleman var");
            else
                Console.WriteLine("eleman yok");

            students.Add(new Student() { Id = 1, Name = "Ramesh", Rank = 1, Age = 39, IsFeesSubmitted = true });

            if (students.Any())
                Console.WriteLine("eleman var");
            else
                Console.WriteLine("eleman yok");


            students.Add(new Student() { Id = 2, Name = "Kapil", Rank = 1, Age = 32, IsFeesSubmitted = true });
            students.Add(new Student() { Id = 3, Name = "Suresh", Rank = 2, Age = 45, IsFeesSubmitted = true });
            students.Add(new Student() { Id = 3, Name = "Mahesh", Rank = 2, Age = 39, IsFeesSubmitted = true });

            var any = students.Any(a => a.Age > 35);
            var any1 = students.Any(a => a.Age > 50);

            Console.WriteLine(any);
            Console.WriteLine(any1);
        }

        private static void All()
        {
            List<Student> students = new List<Student>();
            students.Add(new Student() { Id = 1, Name = "Ramesh", Rank = 1, Age = 39, IsFeesSubmitted = true });
            students.Add(new Student() { Id = 2, Name = "Kapil", Rank = 1, Age = 32, IsFeesSubmitted = true });
            students.Add(new Student() { Id = 3, Name = "Suresh", Rank = 2, Age = 45, IsFeesSubmitted = true });
            students.Add(new Student() { Id = 3, Name = "Mahesh", Rank = 2, Age = 39, IsFeesSubmitted = true });

            var distinct = students.All(a => a.Age > 35);
            var distinct1 = students.All(a => a.Age > 30);

            Console.WriteLine(distinct);
            Console.WriteLine(distinct1);
        }

        private static void Distinct()
        {
            List<Student> students = new List<Student>();
            students.Add(new Student() { Id = 1, Name = "Ramesh", Rank = 1, Age = 39 });
            students.Add(new Student() { Id = 2, Name = "Kapil", Rank = 1, Age = 32 });
            students.Add(new Student() { Id = 3, Name = "Suresh", Rank = 2, Age = 45 });
            students.Add(new Student() { Id = 3, Name = "Mahesh", Rank = 2, Age = 39 });

            var distinct = (from s in students
                            select s.Name).Distinct().ToList();

            foreach (var item in distinct)
            {
                Console.WriteLine(item);
            }
        }

        private static void ExceptUnionConcatIntersect()
        {
            List<string> can = new List<string>() { "Fatih", "Erhan", "Oğuz", "Enes" };
            List<string> boz = new List<string>() { "Fatih", "Erhan", "Apul", "Ali" };

            var fark = can.Except(boz);
            var fark1 = boz.Except(can);

            var toplam = can.Union(boz);// iki diziyi birleştirir. kesişim değerlerini bir kere yazar.
            var toplam1 = can.Concat(boz);// iki diziyi birleştirir. kesişim değerlerini kaç tane varsa hepsini yazar.

            var kesisim = can.Intersect(boz); // iki dizinin kesişim kümesini alır.

            foreach (var item in kesisim)
            {
                Console.WriteLine(item + "+");
            }

            foreach (var item in toplam)
            {
                Console.WriteLine(item);
            }

            foreach (var item in toplam1)
            {
                Console.WriteLine(item + "-");
            }

            foreach (var item in fark)
            {
                Console.WriteLine(item);
            }

            foreach (var item in fark1)
            {
                Console.WriteLine(item);
            }
        }

        private static void Reverse()
        {
            List<int> intList = new() { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };

            foreach (var item in intList)
            {
                Console.WriteLine(item);
            }

            intList.Reverse();

            var reverseList = intList;

            foreach (var item in reverseList)
            {
                Console.WriteLine(item);
            }
        }

        private static void ThenBy()
        {
            List<Student> students = new List<Student>();
            students.Add(new Student() { Id = 1, Name = "Ramesh", Rank = 1, Age = 39 });
            students.Add(new Student() { Id = 2, Name = "Kapil", Rank = 1, Age = 32 });
            students.Add(new Student() { Id = 3, Name = "Suresh", Rank = 2, Age = 45 });
            students.Add(new Student() { Id = 3, Name = "Mahesh", Rank = 2, Age = 39 });

            var studentOrderByRank = from student in students
                                     orderby student.Rank descending, student.Age descending
                                     select student;

            var studentOrderByRank2 = students.OrderBy(x => x.Rank).ThenByDescending(a => a.Age).ToList();

            foreach (var item in studentOrderByRank)
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine("---");

            studentOrderByRank2.ForEach(a => Console.WriteLine(a.Name));
        }

        private static void OrderBy()
        {
            List<Student> students = new List<Student>();
            students.Add(new Student() { Id = 1, Name = "Ramesh", Rank = 3 });
            students.Add(new Student() { Id = 2, Name = "Kapil", Rank = 1 });
            students.Add(new Student() { Id = 3, Name = "Suresh", Rank = 2 });

            var studentOrderByRank = from student in students
                                     orderby student.Rank descending
                                     select student;

            var studentOrderByRank2 = students.OrderByDescending(x => x.Rank).ToList();

            foreach (var item in studentOrderByRank)
            {
                Console.WriteLine(item.Name);
            }

            studentOrderByRank2.ForEach(a => Console.WriteLine(a.Name));
        }

        private static void OfType()
        {
            List<AbstractCourse> courses = new List<AbstractCourse>();

            courses.Add(new FreeCourse() { Id = 1, Subject = "Linq Tutorials", Rank = 5 });
            courses.Add(new FreeCourse() { Id = 2, Subject = ".Net Threading Tutorials", Rank = 4 });
            courses.Add(new PaidCourse() { Id = 3, Subject = "Learn WPF", Rank = 3 });
            courses.Add(new PaidCourse() { Id = 4, Subject = "Linq Datagrid Tutorils", Rank = 3 });

            var paidCourses = from course in courses.OfType<PaidCourse>()
                              select course;

            var freeCourses = from course in courses.OfType<FreeCourse>()
                              select course;

            foreach (var item in paidCourses)
            {
                Console.WriteLine(item.Subject);
            }

            foreach (var item in freeCourses)
            {
                Console.WriteLine(item.Subject);
            }
        }

        private static void IEnumerable_IQueryable()
        {
            List<int> integerList = new()
            {
                1,2,3,4,5,6,7,8,9,10,11,12,13,14,
            };

            //IEnumerable<T>
            //IQueryable

            var querySyntax = from obj in integerList.AsQueryable()
                              where obj > 5
                              select obj;

            foreach (var item in querySyntax)
            {
                Console.WriteLine(item);
            }
        }

        private static void UsingWhere()
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
