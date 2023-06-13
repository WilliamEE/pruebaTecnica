using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels
{
    public class Empleado
    {
        [Key]
        public int IdEmpleado { get; set; }
        [MaxLength(150)]
        public string Nombre { get; set; }
        [MaxLength(150)]
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public DateTime FechaContratacion { get; set; }
        public int IdDepartamento { get; set; }
        [ForeignKey("IdDepartamento")]
        public virtual Departamento Departamentos { get; set; }
    }
}
