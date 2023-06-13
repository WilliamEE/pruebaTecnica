using BusinessModel.Services;
using DataModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting
{
    [TestClass]
    public class DepartamentoTest
    {
        private readonly ProjectDbContext _context;
        private const string Characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private static readonly Random Random = new Random();

        DepartamentoService DepartamentoService;
        public DepartamentoTest() {
            var optionsBuilder = new DbContextOptionsBuilder<ProjectDbContext>();
            optionsBuilder.UseSqlServer("Server=.;Database=ProjectDB;user=user01;password=Admin1234");

            _context = new ProjectDbContext(optionsBuilder.Options);
            DepartamentoService = new DepartamentoService(_context);
        }

        [TestMethod]
        public async Task PostDepartamento()
        {
            Departamento departamento = new()
            {
                IdDepartamento = 0,
                Nombre = "Test"
            };

            int result = 1;
            try
            {
                await DepartamentoService.Save(departamento);
            }
            catch
            {
                result = 0;
            }
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public async Task PostDepartamentoError()
        {
            int desiredLength = 200;
            string randomString = GenerateRandomString(desiredLength);

            Departamento departamento = new()
            {
                IdDepartamento = 0,
                Nombre = randomString
            };

            int result = 1;
            try
            {
                await DepartamentoService.Save(departamento);
            }
            catch
            {
                result = 0;
            }
            Assert.AreEqual(0, result);
        }

        public static string GenerateRandomString(int length)
        {
            StringBuilder sb = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                int randomIndex = Random.Next(Characters.Length);
                char randomChar = Characters[randomIndex];
                sb.Append(randomChar);
            }

            return sb.ToString();
        }

    }
}
