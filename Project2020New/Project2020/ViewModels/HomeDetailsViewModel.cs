using Project2020.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project2020.ViewModels
{
    public class HomeDetailsViewModel : CreateStayViewModel
    {
        public Stay Stay { get; set; }
        public string PageTitle { get; set; }
    }
}
