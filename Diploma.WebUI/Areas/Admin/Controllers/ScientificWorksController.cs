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
    public class ScientificWorksController : Controller
    {
        private readonly DiplomaDbContext db;

        public ScientificWorksController(DiplomaDbContext db)
        {
            this.db = db;
        }
        [Authorize("admin.scientificWorks.index")]
        public async Task<IActionResult> Index()
        {
            var model = await db.ScientificWorks
                .Where(u => u.DeletedById == null)
                .ToListAsync();

            return View(model);
        }
        [Authorize("admin.scientificWorks.details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity = await db.ScientificWorks
                .FirstOrDefaultAsync(u => u.DeletedById == null && u.Id == id);

            return View(entity);
        }
        [Authorize(Policy = "admin.scientificWorks.create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "admin.scientificWorks.create")]
        public async Task<IActionResult> Create(ScientificWork ScientificWork)
        {

            if (ModelState.IsValid)
            {
                db.Add(ScientificWork);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ScientificWork);
        }
        [Authorize(Policy = "admin.scientificWorks.edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ScientificWork = await db.ScientificWorks.FirstOrDefaultAsync(c => c.DeletedById == null && c.Id == id);
            if (ScientificWork == null)
            {
                return NotFound();
            }
            return View(ScientificWork);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "admin.scientificWorks.edit")]
        public async Task<IActionResult> Edit(int id, ScientificWork ScientificWork)
        {
            if (id != ScientificWork.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(ScientificWork);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScientificWorkExists(ScientificWork.Id))
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
            return View(ScientificWork);
        }
        [Authorize(Policy = "admin.scientificWorks.delete")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var color = await db.ScientificWorks
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

        private bool ScientificWorkExists(int id)
        {
            return db.ScientificWorks.Any(e => e.Id == id);
        }
    }
}
