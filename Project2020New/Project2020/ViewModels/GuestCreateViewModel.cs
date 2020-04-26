using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project2020.ViewModels
{
    public class GuestCreateViewModel
    {
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
        public List<IFormFile> Photos { get; set; }
        //public List<Stay> Stays { get; set; }
    }
}
