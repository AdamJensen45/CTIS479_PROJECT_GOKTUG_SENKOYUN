using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagementBLL.DAL
{
    public class Director
    {
        public int Id { get; set; } // Primary Key

        public string Name { get; set; }

        public string Surname { get; set; }

        public bool IsRetired { get; set; }

        // Navigation Property (One-to-Many relationship with Movies)
        public ICollection<Movie> Movies { get; set; }
    }
}
