using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CharityV2.Data;
using CharityV2.Models;
using CharityV2.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.IO;

namespace CharityV2.Controllers
{
    public class ActivitiysController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly IWebHostEnvironment _hostEnvironment;
        private string wwwroot;

        public ActivitiysController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
            _hostEnvironment = hostEnvironment;
            wwwroot = $"{this._hostEnvironment.WebRootPath}";

        }

        // GET: Activitiys
        public async Task<IActionResult> Index(int idCategory)
        {
            if (idCategory==0)
            {
                var allActivities = await _context.Activitiys
                   .ToListAsync();
                return View("Index", allActivities);
            }
            if (User.IsInRole("Admin"))
            {
                var allActivities = await _context.Activitiys
                    .Include(a => a.User)
                    .Where(cat=>cat.CategoryId==idCategory)
                    .ToListAsync();
                return View(allActivities);
            }
            if (User.IsInRole("User"))
            {
                
                var allActivities = await _context.Activitiys
                    .Where(cat => cat.CategoryId == idCategory)
                    .ToListAsync();
                return View(allActivities);
            }
            
            return Content("Error from Activitys Index");
        }

        // GET: Activitiys/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activitiy = await _context.Activitiys
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (activitiy == null)
            {
                return NotFound();
            }
            var imagePath = Path.Combine(wwwroot, "Images");
            ActivityDetailsVM modelVM = new ActivityDetailsVM();

            modelVM.Name = activitiy.Name;
            modelVM.Place=activitiy.Place;
            modelVM.Description = activitiy.Description;
            modelVM.ImagePath = _context.ActivitiesImages.Where(x => x.ActivitiyId == activitiy.Id)
                .Select(y=> $"/Images/{y.ImagePath}")
                .ToList<string>();

            return View(modelVM);
        }

        // GET: Activitiys/Create
        [Authorize]
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            return View();
        }

        // POST: Activitiys/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] ActivityVM activitiy)
        {
            if (!ModelState.IsValid)
            {
                return View(activitiy);
            }

            ImagesBuilder imagesBuilder = new ImagesBuilder(_context, _hostEnvironment);
            await imagesBuilder.CreateImages(activitiy, _userManager.GetUserId(User));

            
            return RedirectToAction("Index", new { idCategory = activitiy.CategoryId });
        }

        // GET: Activitiys/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activitiy = await _context.Activitiys.FindAsync(id);
            if (activitiy == null)
            {
                return NotFound();
            }
            return View(activitiy);
        }

        // POST: Activitiys/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, int userCounter, [Bind("Id,UserId,Name,EmployeeId,Description,Place,Start,End,RedistrationTime,CategoryId,CountInterest,CountParticipants,Status")] Activity activitiy)
        {
            if (id != activitiy.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(activitiy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActivitiyExists(activitiy.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", activitiy.UserId);
            return View(activitiy);
        }

        // GET: Activitiys/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activitiy = await _context.Activitiys
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (activitiy == null)
            {
                return NotFound();
            }

            return View(activitiy);
        }

        // POST: Activitiys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var activitiy = await _context.Activitiys.FindAsync(id);
            _context.Activitiys.Remove(activitiy);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActivitiyExists(int id)
        {
            return _context.Activitiys.Any(e => e.Id == id);
        }
        [Authorize]
        public async Task<IActionResult> Like(int id)
        {
            Activity actStatus = await _context.Activitiys.FindAsync(id);
            actStatus.CountInterest += 1;
            _context.Activitiys.Update(actStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index",new {idCategory=0});
        }
        [Authorize]
        public async Task<IActionResult> Participate(int id)
        {
            Activity actStatus = await _context.Activitiys.FindAsync(id);
            actStatus.CountParticipants += 1;
            _context.Activitiys.Update(actStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", new { idCategory = 0 });
        }
        
        public async Task<IActionResult> IndexUser()
        {

            //var allActivities = await _context.Users
            //.ToListAsync();
            var allUsers = await _userManager.Users.ToListAsync();
            return View("IndexUser", allUsers);
            
        }
        public async Task<IActionResult> EditUser(string id)
        {
            //var activitiy = await _context.Users.FindAsync(id);
            var user = await _userManager.FindByIdAsync(id);
            var rolesr = await _userManager.AddToRoleAsync(user, RoleType.Admin.ToString());
            user.Role=RoleType.Admin;

            _context.Update(user);
            _context.SaveChanges();
            return RedirectToAction("IndexUser");
        }
    }
}
