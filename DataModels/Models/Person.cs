using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }
        [MaxLength(150)]
        public string PersonFullName { get; set; }
        [MaxLength(300)]
        public string PersonAddress { get; set; }
        [MaxLength(20)]
        public string PersonPhone { get; set; }
        public int GenderId { get; set; }
        [ForeignKey("GenderId")]
        public virtual Genders Genders { get; set; }
    }
}
