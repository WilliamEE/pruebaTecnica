using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels
{
    public class Genders
    {
        [Key]
        public int GenderId { get; set; }
        [MaxLength(15)]
        [Required]
        public string GenderName { get; set; }
    }
}
