using Avtobus1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Avtobus1.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ILinkService _linkService;

    public HomeController(ILogger<HomeController> logger, ILinkService linkService)
    {
        _logger = logger;
        _linkService = linkService;
    }

    public async Task<IActionResult> Index()
    {
        ViewBag.Links = await _linkService.GetAll();
        return View();
    }

    public IActionResult Create()
    {
        return View();
    }

    public async Task<IActionResult> Edit(string id)
    {
        ViewBag.Link = await _linkService.GetById(Guid.Parse(id));
        return View();
    }
}
