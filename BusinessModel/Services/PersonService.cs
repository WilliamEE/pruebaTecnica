using DataModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel.Services
{
    public class PersonService : IPersonService
    {
        ProjectDbContext context;

        public PersonService(ProjectDbContext dbcontext)
        {
            context = dbcontext;
        }
        public IEnumerable<Person> Get()
        {
            return context.Person;
        }

        public async Task Save(Person person)
        {
            context.Add(person);
            await context.SaveChangesAsync();
        }

        public async Task Update(int id, Person person)
        {
            var personActual = context.Person.Find(id);

            if (personActual != null)
            {
                personActual.PersonFullName = person.PersonFullName;
                personActual.PersonAddress = person.PersonAddress;
                personActual.PersonPhone = person.PersonPhone;
                 await context.SaveChangesAsync();
            }
        }

        public async Task Delete(int id)
        {
            var personActual = context.Person.Find(id);

            if (personActual != null)
            {
                context.Remove(personActual);
                await context.SaveChangesAsync();
            }
        }

    }

    public interface IPersonService
    {
        IEnumerable<Person> Get();
        Task Save(Person person);

        Task Update(int id, Person person);

        Task Delete(int id);
    }
}
