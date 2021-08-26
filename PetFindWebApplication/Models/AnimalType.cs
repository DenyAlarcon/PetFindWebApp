using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetFindWebApplication.Models
{
    public class AnimalType
    {
        [Display(Name = "Животное")]
        public int Id { get; set; }
        public string Type { get; set; }
        public List<Advertisement> Advertisements { get; set; }
    }
}
