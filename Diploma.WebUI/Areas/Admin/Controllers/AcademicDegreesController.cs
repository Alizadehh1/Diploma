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
    public class AcademicDegreesController : Controller
    {
        private readonly DiplomaDbContext db;

        public AcademicDegreesController(DiplomaDbContext db)
        {
            this.db = db;
        }
        [Authorize(Policy = "admin.academicDegree.index")]
        public async Task<IActionResult> Index()
        {
            var model = await db.AcademicDegrees
                .Where(u => u.DeletedById == null)
                .ToListAsync();

            return View(model);
        }
        [Authorize(Policy = "admin.academicDegree.details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity = await db.AcademicDegrees
                .FirstOrDefaultAsync(u => u.DeletedById == null && u.Id == id);

            return View(entity);
        }
        [Authorize(Policy = "admin.academicDegree.create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "admin.academicDegree.create")]
        public async Task<IActionResult> Create(AcademicDegree AcademicDegree)
        {
            if (ModelState.IsValid)
            {
                db.Add(AcademicDegree);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(AcademicDegree);
        }
        [Authorize(Policy = "admin.academicDegree.edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var AcademicDegree = await db.AcademicDegrees.FirstOrDefaultAsync(c => c.DeletedById == null && c.Id == id);
            if (AcademicDegree == null)
            {
                return NotFound();
            }
            return View(AcademicDegree);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "admin.academicDegree.edit")]
        public async Task<IActionResult> Edit(int id, AcademicDegree AcademicDegree)
        {
            if (id != AcademicDegree.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(AcademicDegree);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AcademicDegreeExists(AcademicDegree.Id))
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
            return View(AcademicDegree);
        }
        [Authorize(Policy = "admin.academicDegree.delete")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var color = await db.AcademicDegrees
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

        private bool AcademicDegreeExists(int id)
        {
            return db.AcademicDegrees.Any(e => e.Id == id);
        }
    }
}
