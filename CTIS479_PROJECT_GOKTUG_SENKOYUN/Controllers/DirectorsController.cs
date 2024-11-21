using Microsoft.AspNetCore.Mvc;
using MovieManagement.BLL.DAL.Models;
using MovieManagement.BLL.DAL.Services;

namespace MovieManagementSystem.Controllers
{
    public class DirectorsController : Controller
    {
        private readonly DirectorService _directorService;

        public DirectorsController(DirectorService directorService)
        {
            _directorService = directorService;
        }

        public IActionResult Index()
        {

            var directors = _directorService.GetAllDirectors();
            return View(directors);
        }

        public IActionResult Details(int id)
        {

            var director = _directorService.GetDirectorById(id);
            if (director == null)
            {
                return NotFound();
            }
            return View(director);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DirectorModel director)
        {
            if (ModelState.IsValid)
            {
                _directorService.CreateDirector(director);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).ToList();

                foreach (var error in errors)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
            }
            return View(director);
        }

        public IActionResult Edit(int id)
        {
            var director = _directorService.GetDirectorById(id);
            if (director == null)
            {
                return NotFound();
            }
            return View(director);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, DirectorModel director)
        {
            if (id != director.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _directorService.UpdateDirector(director);
                return RedirectToAction(nameof(Index));
            }
            return View(director);
        }

        public IActionResult Delete(int id)
        {
            var director = _directorService.GetDirectorById(id);
            if (director == null)
            {
                return NotFound();
            }
            return View(director);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _directorService.DeleteDirector(id);
            return RedirectToAction(nameof(Index));
        }
    
}
}
