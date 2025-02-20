using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission06_Matley.Models;

namespace Mission06_Matley.Controllers;

public class HomeController : Controller
{
    
    private MovieFormContext _context;

    public HomeController(MovieFormContext temp)
    {
        _context = temp;
    }
    // GET
    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult GetToKnowJoel()
    {
        return View();
    }

    [HttpGet]
    public IActionResult MovieForm()
    {
        ViewBag.Categories = _context.Categories
            .OrderBy(x => x.CategoryName)
            .ToList();
        return View("MovieForm", new Movies());
    }

    [HttpPost]
    public IActionResult MovieForm(Movies response)
    {
        if (ModelState.IsValid)
        {
            _context.Movies.Add(response);
            _context.SaveChanges();
            return RedirectToAction("MovieForm");
        }
        else
        {
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();
            return View(response);
        }
    }

    public IActionResult MovieList()
    {
        var movies = _context.Movies
            .Include(x => x.Category)
            .OrderBy(x => x.Title).ToList();
        return View(movies);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var recordToEdit = _context.Movies
            .Single(x => x.MovieId == id);
        
        ViewBag.Categories = _context.Categories
            .OrderBy(x => x.CategoryName)
            .ToList();
        
        return View("MovieForm", recordToEdit);
    }

    [HttpPost]
    public IActionResult Edit(Movies updateInfo)
    {
        _context.Update(updateInfo);
        _context.SaveChanges();
        
        return RedirectToAction("MovieList");
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var recordToDelete = _context.Movies
            .Single(x => x.MovieId == id);
        
        return View(recordToDelete);
    }

    [HttpPost]
    public IActionResult Delete(Movies movies)
    {
        _context.Movies.Remove(movies);
        _context.SaveChanges();
        
        return RedirectToAction("MovieList");
    }
}
