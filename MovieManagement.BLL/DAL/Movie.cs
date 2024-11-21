using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.BLL.DAL
{
    public class Movie
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public decimal TotalRevenue { get; set; }
        public int DirectorId { get; set; } 
        
        public Director Director { get; set; }
    }
}
