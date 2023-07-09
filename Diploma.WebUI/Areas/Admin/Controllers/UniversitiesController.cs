using Diploma.WebUI.Models.DataContexts;
using Diploma.WebUI.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diploma.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UniversitiesController : Controller
    {
        private readonly DiplomaDbContext db;

        public UniversitiesController(DiplomaDbContext db)
        {
            this.db = db;
        }
        [Authorize("admin.universities.index")]
        public async Task<IActionResult> Index()
        {
            var model = await db.Universities
                .Where(u => u.DeletedById == null)
                .ToListAsync();

            return View(model);
        }
        [Authorize("admin.universities.details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity = await db.Universities
                .FirstOrDefaultAsync(u => u.DeletedById == null && u.Id == id);

            return View(entity);
        }
        [Authorize("admin.universities.create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "admin.universities.create")]
        public async Task<IActionResult> Create(University university)
        {
            if (ModelState.IsValid)
            {
                db.Add(university);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(university);
        }
        [Authorize(Policy = "admin.universities.edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var university = await db.Universities.FirstOrDefaultAsync(c => c.DeletedById == null && c.Id == id);
            if (university == null)
            {
                return NotFound();
            }
            return View(university);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "admin.universities.edit")]
        public async Task<IActionResult> Edit(int id, University university)
        {
            if (id != university.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(university);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UniversityExists(university.Id))
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
            return View(university);
        }
        [Authorize(Policy = "admin.universities.delete")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var color = await db.Universities
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

        private bool UniversityExists(int id)
        {
            return db.Universities.Any(e => e.Id == id);
        }
    }
}
