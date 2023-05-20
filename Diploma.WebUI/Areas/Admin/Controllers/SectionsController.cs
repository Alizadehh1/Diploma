using Diploma.WebUI.Models.DataContexts;
using Diploma.WebUI.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diploma.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SectionsController : Controller
    {
        private readonly DiplomaDbContext db;

        public SectionsController(DiplomaDbContext db)
        {
            this.db = db;
        }
        public async Task<IActionResult> Index()
        {
            var model = await db.Sections
                .Where(u => u.DeletedById == null)
                .ToListAsync();

            return View(model);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity = await db.Sections
                .FirstOrDefaultAsync(u => u.DeletedById == null && u.Id == id);

            return View(entity);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Policy = "admin.Sections.create")]
        public async Task<IActionResult> Create(Section Section)
        {
            if (ModelState.IsValid)
            {
                db.Add(Section);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Section);
        }
        //[Authorize(Policy = "admin.Sections.edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Section = await db.Sections.FirstOrDefaultAsync(c => c.DeletedById == null && c.Id == id);
            if (Section == null)
            {
                return NotFound();
            }
            return View(Section);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Policy = "admin.Sections.edit")]
        public async Task<IActionResult> Edit(int id, Section Section)
        {
            if (id != Section.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(Section);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SectionExists(Section.Id))
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
            return View(Section);
        }
        //[Authorize(Policy = "admin.Sections.delete")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var color = await db.Sections
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

        private bool SectionExists(int id)
        {
            return db.Sections.Any(e => e.Id == id);
        }
    }
}
