using System;
using Dapper;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rolodex.Model
{
    public class PersonDB
    {
        static String connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        IDbConnection connection;
        
        public PersonDB() 
        {
            this.connection = new SqlConnection(connectionString);
            Person = this.connection.Query<Person>("SELECT * FROM person;");
        }
        public IEnumerable<Person> Person { get; set; }

        public void Remove(Person person)
        {
            Console.WriteLine("deleting person.id="+person.id);
            this.connection.Query("DELETE FROM person WHERE id=" + person.id);
            Person = this.connection.Query<Person>("SELECT * FROM person;");
        }

        public void Add(Person person)
        {
            Console.WriteLine("adding person.firstName=" + person.firstName);
            string insertString = "INSERT INTO person(firstName, middleName, lastName, jobTitle, address, city, state, zipCode, phone) VALUES ("
                + "'" + person.firstName + "', '" + person.middleName + "', '" + person.lastName + "', '" + person.jobTitle + "', '"
                + person.address + "', '" + person.city + "', '" + person.state + "', '" + person.zipCode + "', '" + person.phone + "');";
            Console.WriteLine(insertString);
            this.connection.Query(insertString);
            Person = this.connection.Query<Person>("SELECT * FROM person;");
        }

        public void Update(Person person)
        {
            Console.WriteLine("updating person.id=" + person.id);
            string updateString = "UPDATE person SET firstName = '"+person.firstName
                + "', middleName = '"+person.middleName
                + "', lastName = '" + person.lastName
                + "', jobTitle = '" + person.jobTitle
                + "', address = '" + person.address
                + "', city = '" + person.city
                + "', state = '" + person.state
                + "', zipCode = '" + person.zipCode
                + "', phone = '" + person.phone
                + "' WHERE id = '"+person.id+"';";
            Console.WriteLine(updateString);
            this.connection.Query(updateString);
            Person = this.connection.Query<Person>("SELECT * FROM person;");
        }
    }
}
