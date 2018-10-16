using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace Rolodex.Model
{
    public class Business
    {
        PersonDB _dbContext = null;
        public Business()
        {
            _dbContext = new PersonDB();
        }
        
        internal IEnumerable<Person> Get()
        {
            return _dbContext.Person.ToList();
        }

        internal void Delete(Person person)
        {
            _dbContext.Remove(person);
        }

        internal void Update(Person updatedPerson)
        {
            CheckValidations(updatedPerson);
            if (updatedPerson.id > 0)
            {
                _dbContext.Update(updatedPerson);
            }
            else
            {
                _dbContext.Add(updatedPerson);
            }
        }

        private void CheckValidations(Person person)
        {
            if (person == null)
            {
                throw new ArgumentNullException("Person", "Please select record from Grid");
            }

            if (string.IsNullOrEmpty(person.firstName))
            {
                throw new ArgumentNullException("First Name", "Please enter FirstName");
            }
            else if (string.IsNullOrEmpty(person.lastName))
            {
                throw new ArgumentNullException("Last Name", "Please enter LastName");
            }
        }
    }
}
