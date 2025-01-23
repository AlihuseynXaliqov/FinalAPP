using AutoMapper;
using CakeFinalApp.DAL.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CakeFinalApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext dbContext;


        public HomeController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;

        }
        public async Task<IActionResult> Index()
        {
            var agents = await dbContext.Agents.Include(x => x.Position).ToListAsync();
            return View(agents);
        }
    }
}
