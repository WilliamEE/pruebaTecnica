using BusinessModel.Services;
using DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting
{
    [TestClass]
    public class EmpleadoTest
    {
        private readonly ProjectDbContext _context;
        private const string Characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private static readonly Random Random = new Random();

        EmpleadoService EmpleadoService;
        DepartamentoService DepartamentoService;
        public EmpleadoTest()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ProjectDbContext>();
            optionsBuilder.UseSqlServer("Server=.;Database=ApiDB;user=user01;password=Admin1234");

            _context = new ProjectDbContext(optionsBuilder.Options);
            EmpleadoService = new EmpleadoService(_context);
            DepartamentoService = new DepartamentoService(_context);
        }

        [TestMethod]
        public async Task PostEmpleado()
        {
            int result = 1;
            try
            {
                var departamentos = await DepartamentoService.Get();

            Empleado Empleado = new()
            {
                IdEmpleado = 0,
                Nombre = "Test",
                Apellido = "Test",
                FechaNacimiento = DateTime.Now,
                FechaContratacion = DateTime.Now,
                IdDepartamento = departamentos.FirstOrDefault().IdDepartamento
            };

                await EmpleadoService.Save(Empleado);
            }
            catch
            {
                result = 0;
            }
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public async Task PostEmpleadoError()
        {
            int desiredLength = 200;
            string randomString = GenerateRandomString(desiredLength);

            Empleado Empleado = new()
            {
                IdEmpleado = 0,
                Nombre = randomString,
                Apellido = randomString,
                FechaNacimiento = DateTime.Now,
                FechaContratacion = DateTime.Now,
                IdDepartamento = 0
            };

            int result = 1;
            try
            {
                await EmpleadoService.Save(Empleado);
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
