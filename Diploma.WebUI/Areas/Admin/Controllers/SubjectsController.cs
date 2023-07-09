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
    public class SubjectsController : Controller
    {
        private readonly DiplomaDbContext db;

        public SubjectsController(DiplomaDbContext db)
        {
            this.db = db;
        }
        [Authorize(Policy = "admin.faculties.index")]
        public async Task<IActionResult> Index()
        {
            var model = await db.Subjects
                .Where(f => f.DeletedById == null)
                .Include(f=>f.Author)
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

            var entity = await db.Subjects
                .Include(f=>f.Author)
                .FirstOrDefaultAsync(u => u.DeletedById == null && u.Id == id);

            return View(entity);
        }
        [Authorize(Policy = "admin.faculties.create")]
        public IActionResult Create()
        {
            ViewData["AuthorId"] = new SelectList(db.Authors.Where(i => i.DeletedById == null), "Id", "Name");

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "admin.faculties.create")]
        public async Task<IActionResult> Create(Subject subject)
        {
            if (ModelState.IsValid)
            {
                db.Add(subject);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(subject);
        }
        [Authorize(Policy = "admin.faculties.edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subject = await db.Subjects.FirstOrDefaultAsync(c => c.DeletedById == null && c.Id == id);
            if (subject == null)
            {
                return NotFound();
            }
            ViewData["AuthorId"] = new SelectList(db.Authors.Where(i => i.DeletedById == null), "Id", "Name", subject.AuthorId);
            return View(subject);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "admin.faculties.edit")]
        public async Task<IActionResult> Edit(int id, Subject subject)
        {
            if (id != subject.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(subject);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubjectExists(subject.Id))
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
            return View(subject);
        }
        [Authorize(Policy = "admin.faculties.delete")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var color = await db.Subjects
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

        private bool SubjectExists(int id)
        {
            return db.Subjects.Any(e => e.Id == id);
        }

    }
}
