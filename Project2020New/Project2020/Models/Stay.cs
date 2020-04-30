﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Project2020.Models;

namespace Project2020.Models
{
    public class Stay
    {       
        public int StayId { get; set; }      
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd MM yyyy}")]
        public DateTime StartDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd MM yyyy}")]
        public DateTime EndDate { get; set; }
        public string EmergencyContactNumber { get; set; }
        [ForeignKey("Id")]
        public int GuestID { get; set; }
        public Guest Guest { get; set; }
    }
}
