using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels
{
    public class Departamento
    {
        [Key]
        public int IdDepartamento { get; set; }
        [MaxLength(100)]
        public string Nombre { get; set; }
        public virtual ICollection<Empleado> Empleados { get; set; }
    }
}
