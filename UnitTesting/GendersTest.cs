using BusinessModel.Services;
using DataModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace UnitTesting
{
    [TestClass]
    public class GendersTest
    {
        private readonly ProjectDbContext _context;

        GendersService gendersService;
        public GendersTest() {
            var optionsBuilder = new DbContextOptionsBuilder<ProjectDbContext>();
            optionsBuilder.UseSqlServer("Server=.;Database=ApiDB;user=user01;password=@Admin1234");

            _context = new ProjectDbContext(optionsBuilder.Options);
            gendersService = new GendersService(_context);
        }

        [TestMethod]
        public async Task PostGenders()
        {
            Genders gender = new()
            {
                GenderId = 0,
                GenderName = "Test"
            };

            int result = 1;
            try
            {
                await gendersService.Save(gender);
            }
            catch
            {
                result = 0;
            }
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public async Task PostGendersError()
        {
            Genders gender = new()
            {
                GenderId = 0,
                GenderName = "12345678901234567890"
            };

            int result = 1;
            try
            {
                await gendersService.Save(gender);
            }
            catch
            {
                result = 0;
            }
            Assert.AreEqual(0, result);
        }

    }
}
