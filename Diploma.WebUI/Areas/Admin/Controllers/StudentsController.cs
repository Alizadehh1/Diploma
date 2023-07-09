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
    public class StudentsController : Controller
    {
        private readonly DiplomaDbContext db;

        public StudentsController(DiplomaDbContext db)
        {
            this.db = db;
        }
        [Authorize("admin.specializations.index")]
        public async Task<IActionResult> Index()
        {
            var model = await db.Students
                .Include(f => f.Group)
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

            var entity = await db.Students
               .Include(f => f.Group)
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
            ViewData["GroupId"] = new SelectList(db.Groups.Where(a=>a.DeletedById==null).ToList(), "Id", "Name");

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize("admin.specializations.create")]
        public async Task<IActionResult> Create(Student student)
        {
            if (ModelState.IsValid)
            {
                db.Add(student);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }
        [Authorize("admin.specializations.edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await db.Students
                .Include(f => f.Group)
                .Include(f=>f.DiplomaUser)
                .FirstOrDefaultAsync(f => f.Id == id && f.DeletedById == null);
            if (student == null)
            {
                return NotFound();
            }
            ViewData["DiplomaUserId"] = new SelectList(db.Users.ToList(), "Id", "Email", student.DiplomaUserId);
            ViewData["GroupId"] = new SelectList(db.Groups.Where(a => a.DeletedById == null).ToList(), "Id", "Name", student.GroupId);
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize("admin.specializations.edit")]
        public async Task<IActionResult> Edit(int id, Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(student);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.Id))
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
            return View(student);
        }
        [Authorize("admin.specializations.delete")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var color = await db.Students
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

        private bool StudentExists(int id)
        {
            return db.Authors.Any(e => e.Id == id);
        }

    }
}
