using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EFDemoWeb.Models;
using EFDataAccessLibrary.DataAccess;
using System.Text.Json;
using EFDataAccessLibrary.Models;

namespace EFDemoWeb.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly PeopleContext _db;

    public HomeController(ILogger<HomeController> logger, PeopleContext db)
    {
        _logger = logger;
        _db = db;
    }

    public IActionResult Index()
    {
        LoadSampleData();
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
    private void LoadSampleData()
    {
        if (_db.People.Any())
        {
            string file = System.IO.File.ReadAllText("generated.json");
            var people = JsonSerializer.Deserialize<List<Person>>(file);
            _db.AddRange(people);
            _db.SaveChanges();
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

   
}
