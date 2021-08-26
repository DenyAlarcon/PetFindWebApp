using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetFindWebApplication.Models
{
    public class City
    {
        [Display(Name = "Город")]
        public int Id { get; set; }
        public string CityName { get; set; }
        public List<Advertisement> Advertisements { get; set; }
    }
}
