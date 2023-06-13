using DataModels;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel.Services
{
    public class EmpleadoService : IEmpleadoService
    {
        ProjectDbContext context;

        public EmpleadoService(ProjectDbContext dbcontext)
        {
            context = dbcontext;
        }
        public async Task<IEnumerable<Empleado>> Get()
        {
            return await context.Empleado.ToListAsync();
        }

        public async Task<Empleado> GetById(int IdEmpleado)
        {
            var param = new SqlParameter[]
            {
                new SqlParameter() {ParameterName = "@IdEmpleado", Value = IdEmpleado},
            };

            var empleados =  await context.Empleado.FromSqlRaw("[dbo].[EmpleadoGet] @IdEmpleado", param).ToListAsync();
            Empleado empleado = new Empleado();
            if (empleados.Count != 0)
            {
                empleado = empleados.FirstOrDefault();
            }
            return empleado;
        }

        public async Task Save(Empleado Empleado)
        {
            context.Add(Empleado);
            await context.SaveChangesAsync();
        }

        public async Task Update(int id, Empleado Empleado)
        {
            var EmpleadoActual = context.Empleado.Find(id);

            if (EmpleadoActual != null)
            {
                EmpleadoActual.Nombre = Empleado.Nombre;
                EmpleadoActual.Apellido = Empleado.Apellido;
                EmpleadoActual.FechaNacimiento = Empleado.FechaNacimiento;
                EmpleadoActual.FechaContratacion = Empleado.FechaContratacion;
                EmpleadoActual.IdDepartamento = Empleado.IdDepartamento;
                await context.SaveChangesAsync();
            }
        }

        public async Task Delete(int id)
        {
            var EmpleadoActual = context.Empleado.Find(id);

            if (EmpleadoActual != null)
            {
                context.Remove(EmpleadoActual);
                await context.SaveChangesAsync();
            }
        }

    }

    public interface IEmpleadoService
    {
        Task<IEnumerable<Empleado>> Get();
        Task<Empleado> GetById(int IdEmpleado);
        Task Save(Empleado Empleado);

        Task Update(int id, Empleado Empleado);

        Task Delete(int id);
    }
}
