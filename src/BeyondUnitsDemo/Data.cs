using System.Collections.Generic;
using System.Linq;

namespace BeyondUnitsDemo
{
    public class Data
    {
        public IList<Person> GetPeopleOrderedByFirstName()
        {
            var people = new List<Person>
                             {
                                 new Person {Firstname = "Tom", Surname = "Tunstal"},
                                 new Person {Firstname = "Aaron", Surname = "Smith"},
                                 new Person {Firstname = "Callum", Surname = "MacDonald"},
                                 new Person {Firstname = "Barry", Surname = "Todd"},
                             };

            return people.OrderBy(o => o.Firstname).ToList();
        }
    }
}