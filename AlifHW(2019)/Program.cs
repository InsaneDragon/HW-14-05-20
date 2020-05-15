using System;
using System.Collections.Generic;
using System.Text;
namespace AlifHW_2019_
{
    class Program
    {
        static void Main(string[] args)
        {
            CRUD.Add(new Person {Name="Shahzod"});
            List < Person >list= CRUD.Read<Person>();
            CRUD.Update(new Person { Name = "Dapper", Id = 1 });
            CRUD.Delete(new Person { Id = 1 });
        }
    }
}