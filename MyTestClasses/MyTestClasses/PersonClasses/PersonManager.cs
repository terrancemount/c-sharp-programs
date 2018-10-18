using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTestClasses
{
    public class PersonManager
    {
        public Person CreatePerson(string first, string last, bool isSupervisor)
        {
            Person ret = null; //will return null if first name is not passed in.

            if (!string.IsNullOrEmpty(first))
            {
                if (isSupervisor)
                {
                    ret = new Supervisor() { FirstName = first, LastName = last };
                }
                else
                {
                    ret = new Employee() { FirstName = first, LastName = last };
                }
            }

            return ret;
        }

        public List<Person> GetPeople()
        {
            List<Person> people = new List<Person>();

            people.Add(new Person() { FirstName = "Paul", LastName = "Sherif" });
            people.Add(new Person() { FirstName = "Terrance", LastName = "Mount" });
            people.Add(new Person() { FirstName = "Heather", LastName = "Helgeson" });

            return people;
        }

        public List<Person> GetSupervisors()
        {
            List<Person> people = new List<Person>();

            people.Add(CreatePerson("Terrance", "Mount", true));
            people.Add(CreatePerson("Heather", "Helgeson", true));

            return people;
        }
    }
}
