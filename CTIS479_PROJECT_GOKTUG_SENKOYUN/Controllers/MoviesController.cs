using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieManagement.BLL.DAL.Models;
using MovieManagement.BLL.DAL.Services;


namespace MovieManagementSystem.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MovieService _movieService;
        private readonly DirectorService _directorService;

        public MoviesController(MovieService movieService, DirectorService directorService)
        {
            _movieService = movieService;
            _directorService = directorService;
        }

        public IActionResult Index()
        {
            var movies = _movieService.GetAllMovies();
            return View(movies);
        }

        public IActionResult Details(int id)
        {
            var movie = _movieService.GetMovieById(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        public IActionResult Create()
        {
            var directors = _directorService.GetAllDirectors();
          
            ViewBag.DirectorList = new SelectList(directors, "Id", "FullName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MovieModel movie)
        {
            if (ModelState.IsValid)
            {
                _movieService.CreateMovie(movie);
                return RedirectToAction(nameof(Index));
            }
            var directors = _directorService.GetAllDirectors();
            ViewBag.DirectorList = new SelectList(directors, "Id", "FullName");
            return View(movie);
        }

     
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = _movieService.GetMovieById(id.Value);
            if (movie == null)
            {
                return NotFound();
            }

            var directors = _directorService.GetAllDirectors();

            ViewBag.DirectorList = new SelectList(directors, "Id", "FullName", movie.DirectorId);

            return View(movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, MovieModel movie)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _movieService.UpdateMovie(movie);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "An error occurred while updating the movie.");
                }
            }

            var directors = _directorService.GetAllDirectors();
            ViewBag.DirectorList = new SelectList(directors, "Id", "FullName", movie.DirectorId);

            return View(movie);
        }

        public IActionResult Delete(int id)
        {
            var movie = _movieService.GetMovieById(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _movieService.DeleteMovie(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
