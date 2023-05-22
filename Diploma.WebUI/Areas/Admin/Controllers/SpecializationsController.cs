using Diploma.WebUI.Models.DataContexts;
using Diploma.WebUI.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diploma.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SpecializationsController : Controller
    {
        private readonly DiplomaDbContext db;

        public SpecializationsController(DiplomaDbContext db)
        {
            this.db = db;
        }
        public async Task<IActionResult> Index()
        {
            var model = await db.Specializations
                .Include(f => f.Department)
                .ThenInclude(f => f.Faculty)
                .ThenInclude(F => F.University)
                .Where(f => f.DeletedById == null && f.Department.DeletedById == null && f.Department.Faculty.DeletedById == null && f.Department.Faculty.University.DeletedById == null)
                .ToListAsync();

            return View(model);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity = await db.Specializations
                .Include(f=>f.Department)
                .ThenInclude(f=>f.Faculty)
                .ThenInclude(F=>F.University)
                .FirstOrDefaultAsync(f => f.DeletedById == null && f.Department.DeletedById == null && f.Department.Faculty.DeletedById == null && f.Department.Faculty.University.DeletedById == null && f.Id == id);

            return View(entity);
        }

        public IActionResult Create()
        {
            ViewData["DepartmentId"] = new SelectList(db.Departments.Include(f => f.Faculty).ThenInclude(f => f.University).Where(f => f.DeletedById == null && f.Faculty.DeletedById == null && f.Faculty.University.DeletedById == null), "Id", "Name");

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Specialization specialization)
        {
            if (ModelState.IsValid)
            {
                db.Add(specialization);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(specialization);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialization = await db.Specializations.FirstOrDefaultAsync(f => f.DeletedById == null && f.Department.DeletedById == null && f.Department.Faculty.DeletedById == null && f.Department.Faculty.University.DeletedById == null);
            if (specialization == null)
            {
                return NotFound();
            }
            ViewData["DepartmentId"] = new SelectList(db.Departments.Include(f => f.Faculty).ThenInclude(f => f.University).Where(f => f.DeletedById == null && f.Faculty.DeletedById == null && f.Faculty.University.DeletedById == null), "Id", "Name", specialization.DepartmentId);
            return View(specialization);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Policy = "admin.universities.edit")]
        public async Task<IActionResult> Edit(int id, Specialization specialization)
        {
            if (id != specialization.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(specialization);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpecializationExists(specialization.Id))
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
            return View(specialization);
        }
        //[Authorize(Policy = "admin.universities.delete")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var color = await db.Specializations
                .FirstOrDefaultAsync(f => f.DeletedById == null && f.Department.DeletedById == null && f.Department.Faculty.DeletedById == null && f.Department.Faculty.University.DeletedById == null);
            if (color == null)
            {
                return Json(new
                {
                    error = true,
                    message = "Mövcud deyil"
                });
            }
            //var user = await userManager.GetUserAsync(User);
            color.DeletedById = 1;
            color.DeletedDate = DateTime.UtcNow.AddHours(4);
            await db.SaveChangesAsync();
            return Json(new
            {
                error = false,
                message = "Uğurla silindi"
            });
        }

        private bool SpecializationExists(int id)
        {
            return db.Specializations.Any(e => e.Id == id);
        }

    }
}
