using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studentregistreringsprogram
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string City { get; set; } = "";


        public Student()
        {
            
        }

        public override string? ToString()
        {
            return $"Förnamn:{FirstName}  Efternamn:{LastName}  Ort:{City}";
        }
    }
}
