using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProblems.Models {
    public class Person {
        public Person(string firstName, string lastName, string emailAddress) {
            FirstName = firstName;
            LastName = lastName;
            Email = emailAddress;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
