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
    public class AuthorsController : Controller
    {
        private readonly DiplomaDbContext db;

        public AuthorsController(DiplomaDbContext db)
        {
            this.db = db;
        }
        [Authorize("admin.specializations.index")]
        public async Task<IActionResult> Index()
        {
            var model = await db.Authors
                .Include(f => f.DiplomaUser)
                .Include(f=>f.AcademicDegree)
                .Where(f => f.DeletedById == null)
                .ToListAsync();

            return View(model);
        }
        [Authorize("admin.specializations.details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity = await db.Authors
               .Include(f => f.DiplomaUser)
                .FirstOrDefaultAsync(f => f.Id == id && f.DeletedById == null);

            if (entity == null)
            {
                return NotFound();
            }

            return View(entity);
        }
        [Authorize("admin.specializations.create")]
        public IActionResult Create()
        {
            ViewData["DiplomaUserId"] = new SelectList(db.Users.ToList(), "Id", "Email");
            ViewData["AcademicDegreeId"] = new SelectList(db.AcademicDegrees.Where(a=>a.DeletedById==null).ToList(), "Id", "Name");

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize("admin.specializations.create")]
        public async Task<IActionResult> Create(Author author)
        {
            if (ModelState.IsValid)
            {
                db.Add(author);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }
        [Authorize("admin.specializations.edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var author = await db.Authors
               .Include(f => f.DiplomaUser)
                .FirstOrDefaultAsync(f => f.Id == id && f.DeletedById == null);
            if (author == null)
            {
                return NotFound();
            }
            ViewData["DiplomaUserId"] = new SelectList(db.Users.ToList(), "Id", "Email", author.DiplomaUserId);
            ViewData["AcademicDegreeId"] = new SelectList(db.AcademicDegrees.Where(a => a.DeletedById == null).ToList(), "Id", "Name", author.AcademicDegreeId);
            return View(author);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize("admin.specializations.edit")]
        public async Task<IActionResult> Edit(int id, Author author)
        {
            if (id != author.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(author);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuthorExists(author.Id))
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
            return View(author);
        }
        [Authorize("admin.specializations.delete")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var color = await db.Authors
                .FirstOrDefaultAsync(f => f.DeletedById == null && f.Id==id);
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

        private bool AuthorExists(int id)
        {
            return db.Authors.Any(e => e.Id == id);
        }

    }
}
