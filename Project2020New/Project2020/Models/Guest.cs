using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project2020.Models
{
    public class Guest
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Name cannot Exceed 50 Characters")]
        public string Forename { get; set; }
        [Required]
        public string Surname { get; set; }
        public Nullable<System.DateTime> Date_Of_Birth { get; set; }
        public string PhotoPath { get; set; }
    }
}
