using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MovieManagement.BLL.DAL.Models
{
    public class MovieModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Movie name is required")]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ReleaseDate { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Total revenue must be non-negative")]
        public decimal TotalRevenue { get; set; }

        [Required(ErrorMessage = "Director is required")]
        public int DirectorId { get; set; }

        public string? DirectorName { get; set; }
    }
}
