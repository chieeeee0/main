using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Login
{
    public class PersonalInformation
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime Birthdate { get; set; }
        public int Age { get; set; }

        public PersonalInformation()
        {

        }
        public PersonalInformation(PersonalInformation personalInformation)
        {
           
        }

        public string GetPersonalInformationMethod()
        {
            return String.Concat(this.Firstname, " ", this.Lastname, " ", "Birthdate: ", this.Birthdate);
        }


        public int GetAge()
        {
            
            int age = DateTime.Now.Year - Birthdate.Year;

            return age;
        }
    }
}
