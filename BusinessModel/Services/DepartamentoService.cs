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
    public class DepartamentoService : IDepartamentoService
    {
        private readonly ProjectDbContext context;

        public DepartamentoService(ProjectDbContext dbcontext)
        {
            context = dbcontext;
        }
        public async Task<IEnumerable<Departamento>> Get()
        {
            DbSet<Departamento> Departamento; 
            try
            {
                Departamento = context.Departamento;
            }
            catch
            {
                Departamento = null;
            }
            return Departamento;
        }

        public async Task<IEnumerable<Empleado>> GetEmpleadosByIdDepartamento(int IdDepartamento)
        {
            var param = new SqlParameter[]
           {
                new SqlParameter() {ParameterName = "@IdDepartamento", Value = IdDepartamento},
           };

            return await context.Empleado
                .FromSqlRaw("[dbo].[EmpleadoDepartamentoIdGet] @IdDepartamento", param)
                .ToListAsync();
        }

        public async Task Save(Departamento Departamento)
        {
            context.Add(Departamento);
            await context.SaveChangesAsync();
        }

        public async Task Update(int id, Departamento Departamento)
        {
            var DepartamentoActual = context.Departamento.Find(id);

            if (DepartamentoActual != null)
            {
                DepartamentoActual.Nombre = Departamento.Nombre;
                await context.SaveChangesAsync();
            }
        }

        public async Task Delete(int id)
        {
            var Departamento = context.Departamento.Find(id);

            if (Departamento != null)
            {
                context.Remove(Departamento);
                await context.SaveChangesAsync();
            }
        }
    }

    public interface IDepartamentoService
    {
        Task<IEnumerable<Departamento>> Get();
        Task<IEnumerable<Empleado>> GetEmpleadosByIdDepartamento(int IdDepartamento);
        Task Save(Departamento Departamento);
        Task Update(int id, Departamento Departamento);
        Task Delete(int id);
    }
}
