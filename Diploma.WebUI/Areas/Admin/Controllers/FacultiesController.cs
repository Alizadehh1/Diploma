using Diploma.WebUI.Models.DataContexts;
using Diploma.WebUI.Models.Entities;
using Microsoft.AspNetCore.Authorization;
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
    public class FacultiesController : Controller
    {
        private readonly DiplomaDbContext db;

        public FacultiesController(DiplomaDbContext db)
        {
            this.db = db;
        }
        [Authorize(Policy = "admin.faculties.index")]
        public async Task<IActionResult> Index()
        {
            var model = await db.Faculties
                .Where(f => f.DeletedById == null && f.University.DeletedById == null)
                .Include(f=>f.University)
                .ToListAsync();

            return View(model);
        }
        [Authorize(Policy = "admin.faculties.details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity = await db.Faculties
                .Include(f=>f.University)
                .FirstOrDefaultAsync(u => u.DeletedById == null && u.Id == id);

            return View(entity);
        }
        [Authorize(Policy = "admin.faculties.create")]
        public IActionResult Create()
        {
            ViewData["UniversityId"] = new SelectList(db.Universities.Where(i => i.DeletedById == null), "Id", "Name");

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "admin.faculties.create")]
        public async Task<IActionResult> Create(Faculty faculty)
        {
            if (ModelState.IsValid)
            {
                db.Add(faculty);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(faculty);
        }
        [Authorize(Policy = "admin.faculties.edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faculty = await db.Faculties.FirstOrDefaultAsync(c => c.DeletedById == null && c.Id == id);
            if (faculty == null)
            {
                return NotFound();
            }
            ViewData["UniversityId"] = new SelectList(db.Universities.Where(i => i.DeletedById == null), "Id", "Name", faculty.UniversityId);
            return View(faculty);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "admin.faculties.edit")]
        public async Task<IActionResult> Edit(int id, Faculty faculty)
        {
            if (id != faculty.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(faculty);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FacultyExists(faculty.Id))
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
            return View(faculty);
        }
        [Authorize(Policy = "admin.faculties.delete")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var color = await db.Faculties
                .FirstOrDefaultAsync(m => m.Id == id && m.DeletedById == null);
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

        private bool FacultyExists(int id)
        {
            return db.Faculties.Any(e => e.Id == id);
        }

    }
}
