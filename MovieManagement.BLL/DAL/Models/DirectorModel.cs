using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MovieManagement.BLL.DAL.Models
{
    public class DirectorModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Surname is required")]
        public required string Surname { get; set; }

        public bool IsRetired { get; set; }

        public List<MovieModel>? Movies { get; set; }

        public string FullName => $"{Name} {Surname}";
    }
}
