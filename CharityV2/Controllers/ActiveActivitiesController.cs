using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CharityV2.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace CharityV2.Controllers
{
    public class ActiveActivitiesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public ActiveActivitiesController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: ActiveActivities
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ActiveActivities
                                        .Include(a => a.Activitiy)
                                        .Include(a => a.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ActiveActivities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activeActivity = await _context.ActiveActivities
                .Include(a => a.Activitiy)
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (activeActivity == null)
            {
                return NotFound();
            }

            return View(activeActivity);
        }

      

        // POST: ActiveActivities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int idActivity)
        {

            var currentUser = _userManager.GetUserId(User); 
            ActiveActivity modelToDb = new ActiveActivity()
            {
                ActivitiyId = idActivity,
                UserId = currentUser

            };

            _context.ActiveActivities.Add(modelToDb);

            Activity actStatus = await _context.Activitiys.FindAsync(idActivity);
            actStatus.Status = StatusType.Approved;
            _context.Activitiys.Update(actStatus);

            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Activitiys", new { id = idActivity });
         

        }

        // GET: ActiveActivities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activeActivity = await _context.ActiveActivities.FindAsync(id);
            if (activeActivity == null)
            {
                return NotFound();
            }
            ViewData["ActivitiyId"] = new SelectList(_context.Activitiys, "Id", "Id", activeActivity.ActivitiyId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", activeActivity.UserId);
            return View(activeActivity);
        }

        // POST: ActiveActivities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,ActivitiyId")] ActiveActivity activeActivity)
        {
            if (id != activeActivity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(activeActivity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActiveActivityExists(activeActivity.Id))
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
            ViewData["ActivitiyId"] = new SelectList(_context.Activitiys, "Id", "Id", activeActivity.ActivitiyId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", activeActivity.UserId);
            return View(activeActivity);
        }

        // GET: ActiveActivities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activeActivity = await _context.ActiveActivities
                .Include(a => a.Activitiy)
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (activeActivity == null)
            {
                return NotFound();
            }

            return View(activeActivity);
        }

        // POST: ActiveActivities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var activeActivity = await _context.ActiveActivities.FindAsync(id);
            _context.ActiveActivities.Remove(activeActivity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActiveActivityExists(int id)
        {
            return _context.ActiveActivities.Any(e => e.Id == id);
        }
        
    }
}
