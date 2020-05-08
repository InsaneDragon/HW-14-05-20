using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace AlifHW_2019_
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            while (true)
            {
                Console.WriteLine("Choose Operation");
                Console.WriteLine("1.Create");
                Console.WriteLine("2.Read");
                Console.WriteLine("3.Update");
                Console.WriteLine("4.Delete");
                Console.Write("Choice:");
                string x = Console.ReadLine();
                switch (x)
                {
                    case "1":
                        {
                            Console.Clear();
                            Console.Write("Name:");
                            string Name = Console.ReadLine();
                            Create(Name);
                            Console.Clear();
                        }
                        break;
                    case "2":
                        {
                            Console.Clear();
                            Read();
                        }
                        break;
                    case "3":
                        {
                            Console.Clear();
                            Read();
                            Console.Write("ID:");
                            int id = int.Parse(Console.ReadLine());
                            Console.Write("Name(Updated):");
                            string Name = Console.ReadLine();
                            Update(id,Name);
                        }
                        break;

                    case "4":
                        {
                            Console.Clear();
                            Console.Write("ID:");
                            int id = int.Parse(Console.ReadLine());
                            Delete(id);
                        }
                        break;
                }
            }
        }
        static void Create(string Name)
        {
            using (var context = new TestContext())
            {
                context.Add(new Person { Name = Name });
                context.SaveChanges();
            }
        }
        static void Read()
        {
            using (var context = new TestContext())
            {
                var list = context.Person.ToList();
                foreach (var item in list)
                {
                    Console.WriteLine("ID:" + item.Id + " Name:" + item.Name);
                }
            }
        }
        static void Update(int id,string name)
        {
            using (var context = new TestContext())
            {
                var Person = context.Person.Where(p => p.Id == id).FirstOrDefault();
                if (Person == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("There is no Person with this id");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Person.Name = name;
                    context.Entry(Person).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
        }
        static void Delete(int id)
        {
            using (var context = new TestContext())
            {
                var Person = context.Person.Where(p => p.Id == id).FirstOrDefault();
                if (Person == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("There is no Person with this id");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    context.Remove(Person);
                    context.SaveChanges();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Person was removed successfully");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
    }
}
