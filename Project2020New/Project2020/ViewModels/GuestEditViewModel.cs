using Project2020.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2020.ViewModels
{
    public class GuestEditViewModel : GuestCreateViewModel
    {

        public GuestEditViewModel()
        {
            Stays = new List<string>();
        }
        public Guest Guest { get; set; }
        public Stay Stay { get; set; }
        public int Id { get; set; }
        public string ExistingPhotoPath { get; set; }
        public new List<string> Stays { get; set; }
    }
}
