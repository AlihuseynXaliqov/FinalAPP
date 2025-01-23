using AutoMapper;
using CakeFinalApp.Areas.Manage.Helpers.Exception;
using CakeFinalApp.Areas.Manage.ViewModels.Agent;
using CakeFinalApp.DAL.Context;
using CakeFinalApp.Helpers;
using CakeFinalApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CakeFinalApp.Areas.Manage.Controllers
{
    [Area("Manage")]
    [Authorize(Roles ="Admin")]
    public class AgentController : Controller
    {
        private readonly AppDbContext dbContext;
        private readonly IMapper mapper;
        private readonly IWebHostEnvironment web;

        public AgentController(AppDbContext dbContext, IMapper mapper, IWebHostEnvironment web)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.web = web;
        }
        public async Task<IActionResult> Index()
        {
            var agents = await dbContext.Agents.Include(x => x.Position).ToListAsync();
            return View(agents);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Position=await dbContext.Positions.ToListAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateAgentVm vm)
        {
            ViewBag.Position = await dbContext.Positions.ToListAsync();

            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            if (!vm.formFile.ContentType.Contains("image"))
            {
                ModelState.AddModelError("formFile", "Sekil duzgun deyil");
                return View(vm);
            }
            if (vm.formFile.Length > 2097152)
            {
                ModelState.AddModelError("formFile", "Sekil olcusu 2mb cox olmamalidir");
                return View(vm);

            }
            vm.ImageUrl = vm.formFile.Upload(web.WebRootPath, "Upload/Agent");
            var agent = mapper.Map<Agent>(vm);
            await dbContext.Agents.AddAsync(agent);
            await dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Update(int id)
        {
            ViewBag.Position = await dbContext.Positions.ToListAsync();

            if (id <= 0)
            {
                throw new NegativeIdException();

            }
            var agent = await dbContext.Agents.FirstOrDefaultAsync(x => x.Id == id);
            if (agent == null)
            {
                throw new NotFoundException<Agent>();
            }
            var newAgent = mapper.Map<UpdateAgentVm>(agent);
            return View(newAgent);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateAgentVm vm)
        {
            ViewBag.Position = await dbContext.Positions.ToListAsync();

            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            var agent = await dbContext.Agents.FirstOrDefaultAsync(x => x.Id == vm.Id);
            if (vm.formFile != null)
            {
                if (!vm.formFile.ContentType.Contains("image"))
                {
                    ModelState.AddModelError("formFile", "Sekil duzgun deyil");
                    return View(vm);
                }
                if (vm.formFile.Length > 2097152)
                {
                    ModelState.AddModelError("formFile", "Sekil olcusu 2mb cox olmamalidir");
                    return View(vm);
                }
                if (!string.IsNullOrEmpty(agent.ImageUrl))
                {
                    FileExtention.Delete(web.WebRootPath, "Upload/Agent", agent.ImageUrl);
                }
                agent.ImageUrl = vm.formFile.Upload(web.WebRootPath, "Upload/Agent");
            }
            agent.PositionId = vm.PositionId;
            agent.Name = vm.Name;

            await dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                throw new NegativeIdException();

            }
            var agent = await dbContext.Agents.FirstOrDefaultAsync(x => x.Id == id);
            if (agent == null)
            {
                throw new NotFoundException<Agent>();
            }
            FileExtention.Delete(web.WebRootPath, "Upload/Agent", agent.ImageUrl);
            dbContext.Agents.Remove(agent);
            await dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


        } }
    }
