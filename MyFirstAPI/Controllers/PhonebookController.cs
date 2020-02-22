using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MyFirstAPI.Models;

namespace MyFirstAPI.Controllers
{
    public class PhonebookController : ApiController
    {
        List<Phonebook> myBook = new List<Phonebook>();

        public PhonebookController(): base()
        {
            Phonebook p1 = new Phonebook { Name = "Ronan", Number = "1111", Address = "1 Main Street"};
            Phonebook p2 = new Phonebook { Name = "James", Number = "2222", Address = "2 Main Street" };
            Phonebook p3 = new Phonebook { Name = "Pamela", Number = "3333"};
            myBook.Add(p1);
            myBook.Add(p2);
            myBook.Add(p3);
        }
        // GET: api/Phonebook
        public string Get()
        {
            return "API is Listening";
        }

        // GET: api/Phonebook/5
        public string Get(int id)
        {
            Phonebook p = myBook[id];

            return "Name: " + p.Name + " " + "Number: " + p.Number;
        }

        // http://localhost:56097/api/Phonebook?Name=Ronan
        public string GetByName(string name)
        {
            Phonebook FindName = myBook.FirstOrDefault(p => p.Name.ToUpper() == name.ToUpper());
            if (FindName != null)
            {
                return "Number: " + FindName.Number + ", " + "Address: " + FindName.Address;
            }
            else
            {
                return "Name not in the API";
            }
            
        }

        // http://localhost:56097/api/Phonebook?Number=1111
        public string GetByNumber(string number)
        {
            Phonebook FindNumber = myBook.FirstOrDefault(p => p.Number.ToUpper() == number.ToUpper());
            if (FindNumber != null)
            {
                return "Name: " + FindNumber.Name + ", " + "Address: " + FindNumber.Address;
            }
            else
            {
                return "Number not in the API";
            }

        }

        // POST: api/Phonebook
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Phonebook/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Phonebook/5
        public void Delete(int id)
        {
        }
    }
}
