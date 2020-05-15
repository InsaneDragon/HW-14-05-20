using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Dapper;
using System.Data;
using System.Linq;

namespace AlifHW_2019_
{
    class CRUD
    {
        const string ConnectionString = "Data Source=localhost;Initial Catalog=Test;Integrated Security=True";
        public static void Add(Person person)
        {
            using (IDbConnection con = new SqlConnection(ConnectionString))
            {
                con.Query($"INSERT INTO PERSON (Name) Values('{person.Name}')");
            }
        }
        public static List<T> Read<T>()
        {
            using (IDbConnection con = new SqlConnection(ConnectionString))
            {
                return con.Query<T>($"SELECT * FROM {typeof(T).Name?.ToUpper()}").ToList();
            }
        }
        public static void Update(Person person)
        {
            using (IDbConnection con = new SqlConnection(ConnectionString))
            {
                con.Query<Person>($"Update Person SET Name='{person.Name}' WHERE ID={person.Id}");
            }
        }
        public static void Delete(Person person)
        {
            using (IDbConnection con = new SqlConnection(ConnectionString))
            {
                con.Query<Person>($"DELETE FROM PERSON WHERE ID={person.Id}");
            }
        }
    }
}
