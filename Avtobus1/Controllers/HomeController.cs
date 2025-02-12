using Avtobus1.Context;
using Avtobus1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Avtobus1.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly LinkContext _context;

    public HomeController(ILogger<HomeController> logger, LinkContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        Link link = new()
        {
            Name = "Name",
            ShortName = "Short name",
            CreatedAt = DateTime.Now,
            Redirects = 1
        };
        ViewBag.Links = new List<Link>([link]);
        return View();
    }

    public IActionResult Create()
    {
        return View();
    }

    public IActionResult Read()
    {
        return View();
    }

    public IActionResult Edit()
    {
        return View();
    }
}
