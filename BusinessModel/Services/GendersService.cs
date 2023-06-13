using DataModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel.Services
{
    public class GendersService : IGendersService
    {
        private readonly ProjectDbContext context;

        public GendersService(ProjectDbContext dbcontext)
        {
            context = dbcontext;
        }
        public async Task<IEnumerable<Genders>> Get()
        {
            DbSet<Genders> genders; 
            try
            {
                genders = context.Genders;
            }
            catch
            {
                genders = null;
            }
            return genders;
        }

        public async Task Save(Genders genders)
        {
            context.Add(genders);
            await context.SaveChangesAsync();
        }

        public async Task Update(int id, Genders genders)
        {
            var gendersActual = context.Genders.Find(id);

            if (gendersActual != null)
            {
                gendersActual.GenderName = genders.GenderName;
                await context.SaveChangesAsync();
            }
        }

        public async Task Delete(int id)
        {
            var genders = context.Genders.Find(id);

            if (genders != null)
            {
                context.Remove(genders);
                await context.SaveChangesAsync();
            }
        }
    }

    public interface IGendersService
    {
        Task<IEnumerable<Genders>> Get();
        Task Save(Genders genders);
        Task Update(int id, Genders genders);
        Task Delete(int id);
    }
}
