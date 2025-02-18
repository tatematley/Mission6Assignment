using Microsoft.AspNetCore.Mvc;
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
        return View();
    }

    [HttpPost]
    public IActionResult MovieForm(Application response)
    {
        _context.Applications.Add(response);
        _context.SaveChanges();
        return RedirectToAction("MovieForm");
    }

    public IActionResult MovieList()
    {
        var applications = _context.Applications
            .OrderBy(x => x.Title).ToList();
        return View(applications);
    }
}