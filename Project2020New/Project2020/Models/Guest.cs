using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project2020.Models
{
    public class Guest
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Name cannot Exceed 25 Characters")]
        public string Forename { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd MM yyyy}")]
        public DateTime Date_Of_Birth { get; set; }
        [Required]
        public string PhotoPath { get; set; }
        //public List<Stay> Stays { get; set; }

    }
}
