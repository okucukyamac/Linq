using LinqBasics.Abstract;
using LinqBasics.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqBasics
{
    internal class Methods
    {
        public static void Range()
        {

            IEnumerable<int> numbers = Enumerable.Range(0, 10);

            foreach (int i in numbers)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("");

            numbers = Enumerable.Range(10, 30).Where(a=>a%2==0);

            foreach (var item in numbers)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("");


            numbers = Enumerable.Range(1,5).Select(a=>a*a);

            foreach (var item in numbers)
            {
                Console.WriteLine(item);
            }

          

        }

        public static void SkipWhile()
        {
            List<int> numbers = new List<int>() { 1,4,5,6,7,8,9,10, 2, 3 };

            var result = numbers.SkipWhile(a=>a<6);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

        }

        public static void Skip()
        {
            List<int> numbers = new List<int>() { 1,2,3,4,5,6,7,8,9,10};

            var result = numbers.Skip(4);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

        }
        
        public static void Take()
        {
            List<int> numbers = new List<int>() { 1,2,3,4,5,6,7,8,9,10};

            var result = numbers.OrderByDescending(a=>a).Take(4);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("");
            result = (from num in numbers
                     orderby num
                     select num).Take(4).Where(a=>a%2==0);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

        }

        public static void SequenceEqual()
        {
            var sehirler = new List<string> { "İstanbul", "İzmir", "Ankara" };

            var sehirler2 = new List<string> { "İstanbul", "İzmiR", "Ankara" };

            var sehirler3 = new List<string> { "İstanbul", "Ankara", "İzmiR", };

            var result = sehirler.SequenceEqual(sehirler2);
            Console.WriteLine(result);

            result = sehirler.SequenceEqual(sehirler2,StringComparer.OrdinalIgnoreCase);
            Console.WriteLine(result);

            result = sehirler.OrderBy(a=>a).SequenceEqual(sehirler3.OrderBy(a=>a),StringComparer.OrdinalIgnoreCase);
            Console.WriteLine(result);
        }

        public static void DefaultIfEmpty()
        {
            List<int> numbers = new List<int> { };

            var result = numbers.DefaultIfEmpty(8);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        public static void SingleOrDefault()
        {
            List<int> numbers = new List<int>() { 10, 11 };

            var result = numbers.SingleOrDefault(a => a > 40);

            Console.WriteLine(result);

            result = numbers.Single(a => a > 40);

        }

        public static void LastOrDefault()
        {
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };


            var lastOrDefault = numbers.LastOrDefault(a => a % 2 == 0);
            Console.WriteLine(lastOrDefault);
            lastOrDefault = numbers.LastOrDefault(a => a > 50);
            Console.WriteLine(lastOrDefault);

            var last = numbers.Last(a => a % 2 == 0);
            Console.WriteLine(last);
            last = numbers.Last(a => a > 50);

            var queryLast = (from a in numbers
                             select a).LastOrDefault();
        }

        public static void FirstOrDefault()
        {
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };


            var firstOrDefault = numbers.FirstOrDefault(a => a % 2 == 0);
            Console.WriteLine(firstOrDefault);
            firstOrDefault = numbers.FirstOrDefault(a => a > 50);
            Console.WriteLine(firstOrDefault);

            var first = numbers.First(a => a % 2 == 0);
            Console.WriteLine(first);
            first = numbers.First(a => a > 50);
        }

        public static void ElementAtOrDefault()
        {
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var elementAtOrDefault = numbers.ElementAtOrDefault(10);

            Console.WriteLine(elementAtOrDefault);

            var elementAt = numbers.ElementAt(10);//hata verecektir.

            Console.WriteLine(elementAt);
        }

        public static void MultipleDataSource()
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
        }

        public static void JoinInnerJoin()
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

            var result2 = from emp in employees
                          join add in addresses
                          on emp.AddressId equals add.Id
                          select new
                          {
                              EmployeeId = emp.Id,
                              EmployeName = emp.Name,
                              AdressLine = add.AddressLine
                          };

            foreach (var a in result2)
            {
                Console.WriteLine(a.EmployeeId + " - " + a.AdressLine + " - " + a.EmployeName);

            }
            Console.WriteLine("");


            result.ForEach(a =>
            {
                Console.WriteLine(a.EmployeeId + " - " + a.AdressLine + " - " + a.EmployeName);
            });
        }

        public static void GroupBy()
        {
            var students = new List<Student>
            {
                new Student() {Id= 1,Name="Fatih",Gender="Erkek",Branch="CSE",Age=20},
                new Student() {Id= 1,Name="Derya",Gender="Kadın",Branch="ETC",Age=21},
                new Student() {Id= 1,Name="Ali",Gender="Erkek",Branch="CSE",Age=22},
                new Student() {Id= 1,Name="Muhammed",Gender="Erkek",Branch="CSE",Age=23},
                new Student() {Id= 1,Name="Zeynep",Gender="Kadın",Branch="ETC",Age=24},
                new Student() {Id= 1,Name="Tarık",Gender="Erkek",Branch="CSE",Age=25},
                new Student() {Id= 1,Name="Derya",Gender="Kadın",Branch="ETC",Age=26},
                new Student() {Id= 1,Name="Emre",Gender="Erkek",Branch="ETC",Age=26},
            };

            var groupBy = students.GroupBy(x => x.Branch).Where(a => a.Key == "ETC");

            foreach (var item in groupBy)
            {
                Console.WriteLine(item.Key + " " + item.Count());
                foreach (var x in item)
                {
                    Console.WriteLine(x.Name);
                }

                Console.WriteLine("");
            }

            var groupBy1 = from s in students
                           group s by s.Gender;

            foreach (var item in groupBy1)
            {
                Console.WriteLine(item.Key + " " + item.Count());
                foreach (var x in item)
                {
                    Console.WriteLine(x.Name);
                }

                Console.WriteLine("");
            }
        }

        public static void All()
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

        public static void Any()
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

        public static void Distinct()
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

        public static void EqualsContainsEndWithStartWith()
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

        public static void ExceptUnionConcatIntersect()
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

        public static void IEnumerable_IQueryable()
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


        public static void OfType()
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

        public static void OrderBy()
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

        public static void Reverse()
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

        public static void SelectMany()
        {
            var employees = new List<Employee>(){
                new Employee { Id = 1, Departments = new List<Department> { new Department { Name = "marketing" }, new Department { Name = "Sales" } } },
                new Employee { Id = 2, Departments = new List<Department> { new Department { Name = "Advertisement" }, new Department { Name = "Production" } } },
                new Employee { Id = 3, Departments = new List<Department> { new Department { Name = "Production" }, new Department { Name = "Sales" } } }
            };

            var result = employees.SelectMany(a => a.Departments);

            foreach (var item in result)
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine("");

            foreach (var item in employees)
            {
                foreach (var it in item.Departments)
                {
                    Console.WriteLine(it.Name);
                }
            }
        }

        public static void SumMaxMinAverageCountAggregate()
        {
            var intList = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            int total = intList.Sum();
            Console.WriteLine(total);
            total = (from a in intList select a).Sum();
            Console.WriteLine(total);

            Console.WriteLine("");

            var max = intList.Max();
            Console.WriteLine(max);
            max = (from a in intList select a).Max();
            Console.WriteLine(max);

            Console.WriteLine("");

            var min = intList.Min();
            Console.WriteLine(min);
            min = (from a in intList select a).Min();
            Console.WriteLine(min);

            Console.WriteLine("");

            var Average = intList.Average();
            Console.WriteLine(Average);
            Average = (from a in intList select a).Average();
            Console.WriteLine(Average);

            Console.WriteLine("");

            var count = intList.Count();
            Console.WriteLine(count);
            count = (from a in intList select a).Count();
            Console.WriteLine(count);

            Console.WriteLine("");

            var stringList = new List<string> { "C#", "Java", "Php", "Sql" };

            var aggragate = stringList.Aggregate((x, y) => x + ", " + y);
            Console.WriteLine(aggragate);
        }

        public static void Syntaxes()
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

        public static void ThenBy()
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

        public static void UsingWhere()
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
    }
}