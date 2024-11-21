using Microsoft.EntityFrameworkCore;
using MovieManagement.BLL.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.BLL.DAL.Services
{
    public class MovieService
    {
        private readonly MovieContext _context;

        public MovieService(MovieContext context)
        {
            _context = context;
        }

        public List<MovieModel> GetAllMovies()
        {
            return _context.Movies
                .Include(m => m.Director)
                .Select(m => new MovieModel
                {
                    Id = m.Id,
                    Name = m.Name,
                    ReleaseDate = m.ReleaseDate,
                    TotalRevenue = m.TotalRevenue,
                    DirectorId = m.DirectorId,
                    DirectorName = $"{m.Director.Name} {m.Director.Surname}"
                }).ToList();
        }

        public MovieModel GetMovieById(int id)
        {
            var movie = _context.Movies
                .Include(m => m.Director)
                .FirstOrDefault(m => m.Id == id);
            if (movie == null) return null;

            return new MovieModel
            {
                Id = movie.Id,
                Name = movie.Name,
                ReleaseDate = movie.ReleaseDate,
                TotalRevenue = movie.TotalRevenue,
                DirectorId = movie.DirectorId,
                DirectorName = $"{movie.Director.Name} {movie.Director.Surname}"
            };
        }

        public void CreateMovie(MovieModel model)
        {
            var movie = new Movie
            {
                Name = model.Name,
                ReleaseDate = model.ReleaseDate,
                TotalRevenue = model.TotalRevenue,
                DirectorId = model.DirectorId
            };
            _context.Movies.Add(movie);
            _context.SaveChanges();
        }

        public void UpdateMovie(MovieModel model)
        {
            var movie = _context.Movies.Find(model.Id);
            if (movie == null) return;

            movie.Name = model.Name;
            movie.ReleaseDate = model.ReleaseDate;
            movie.TotalRevenue = model.TotalRevenue;
            movie.DirectorId = model.DirectorId;
            _context.SaveChanges();
        }

        public void DeleteMovie(int id)
        {
            var movie = _context.Movies.Find(id);
            if (movie == null) return;

            _context.Movies.Remove(movie);
            _context.SaveChanges();
        }
    }
}
