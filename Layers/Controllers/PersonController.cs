using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NeoFindr.Controllers
{
    public class PersonController : Controller
    {
        private readonly PersonService personService;

        public PersonController(PersonService personService)
        {
            this.personService = personService;
        }
        
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var allPeople = personService.ListAll();
            return View(allPeople);
        }

        [HttpGet]
        public async Task<IActionResult> Search(string searchTerm)
        {
            var results = personService.Search(searchTerm);
            return View("List", results);
        }
    }

    public class PersonService
    {
        private PersonRepository personRepository;

        public PersonService(PersonRepository personRepository)
        {
            this.personRepository = personRepository;
        }
        
        public List<Person> ListAll()
        {
            return personRepository.ListAll();
        }

        public List<Person> Search(string searchTerm)
        {
            return personRepository.ListAll(searchTerm);
        }
    }

    public class PersonRepository
    {
        public List<Person> ListAll(string searchTerm = "")
        {
            if (!string.IsNullOrEmpty(searchTerm))
            {
                // pass query to DB...
            }
            else
            {
                // return everything?
            }
            
            return new List<Person>
            {
                new Person
                {
                    FirstName = "Neo", 
                    LastName = "Anderson", 
                    LastSlept = new DateTime(),
                    ThreatLevel = "Inconsequential"
                }
            };
        }
    }

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime LastSlept { get; set; }
        public string ThreatLevel { get; set; }
    }
}