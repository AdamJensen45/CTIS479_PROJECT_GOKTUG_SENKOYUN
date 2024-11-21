using MovieManagement.BLL.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.BLL.DAL.Services
{
    public class DirectorService
    {
        private readonly MovieContext _context;

        public DirectorService(MovieContext context)
        {
            _context = context;
        }

        public List<DirectorModel> GetAllDirectors()
        {
            return _context.Directors
                .Select(d => new DirectorModel
                {
                    Id = d.Id,
                    Name = d.Name,
                    Surname = d.Surname,
                    IsRetired = d.IsRetired
                }).ToList();
        }

        public DirectorModel GetDirectorById(int id)
        {
            var director = _context.Directors.Find(id);
            if (director == null) return null;

            return new DirectorModel
            {
                Id = director.Id,
                Name = director.Name,
                Surname = director.Surname,
                IsRetired = director.IsRetired
            };
        }

        public void CreateDirector(DirectorModel model)
        {
            var director = new Director
            {
                Name = model.Name,
                Surname = model.Surname,
                IsRetired = model.IsRetired
            };
            _context.Directors.Add(director);
            _context.SaveChanges();
        }

        public void UpdateDirector(DirectorModel model)
        {
            var director = _context.Directors.Find(model.Id);
            if (director == null) return;

            director.Name = model.Name;
            director.Surname = model.Surname;
            director.IsRetired = model.IsRetired;
            _context.SaveChanges();
        }

        public void DeleteDirector(int id)
        {
            var director = _context.Directors.Find(id);
            if (director == null) return;

            _context.Directors.Remove(director);
            _context.SaveChanges();
        }
    }
}
