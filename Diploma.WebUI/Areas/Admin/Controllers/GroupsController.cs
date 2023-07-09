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
    public class GroupsController : Controller
    {
        private readonly DiplomaDbContext db;

        public GroupsController(DiplomaDbContext db)
        {
            this.db = db;
        }
        [Authorize(Policy = "admin.groups.index")]
        public async Task<IActionResult> Index()
        {
            var model = await db.Groups
                .Include(f => f.Specialization)
                .ThenInclude(f => f.Department)
                .ThenInclude(F => F.Faculty)
                .ThenInclude(F => F.University)
                .Include(f => f.Section)
                .Where(f => f.DeletedById == null && f.Specialization.DeletedById == null && f.Specialization.Department.DeletedById == null && f.Specialization.Department.Faculty.DeletedById == null && f.Specialization.Department.Faculty.University.DeletedById == null)
                .ToListAsync();

            return View(model);
        }
        [Authorize(Policy = "admin.groups.details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity = await db.Groups
                .Include(f => f.Specialization)
                .ThenInclude(f => f.Department)
                .ThenInclude(F => F.Faculty)
                .ThenInclude(F => F.University)
                .Include(f => f.Section)
                .FirstOrDefaultAsync(f => f.Id == id && f.DeletedById == null && f.Specialization.DeletedById == null && f.Specialization.Department.DeletedById == null && f.Specialization.Department.Faculty.DeletedById == null && f.Specialization.Department.Faculty.University.DeletedById == null);

            if (entity == null)
            {
                return NotFound();
            }

            return View(entity);
        }
        [Authorize(Policy = "admin.groups.create")]
        public IActionResult Create()
        {
            ViewData["SpecializationId"] = new SelectList(db.Specializations.Include(f => f.Department)
                .ThenInclude(f => f.Faculty)
                .ThenInclude(F => F.University)
                .Where(f => f.DeletedById == null && f.Department.DeletedById == null && f.Department.Faculty.DeletedById == null && f.Department.Faculty.University.DeletedById == null), "Id", "Name");
            ViewData["SectionId"] = new SelectList(db.Sections.Where(s => s.DeletedById == null), "Id", "Name");

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "admin.groups.create")]
        public async Task<IActionResult> Create(Group group)
        {
            if (ModelState.IsValid)
            {
                db.Add(group);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(group);
        }
        [Authorize(Policy = "admin.groups.edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var group = await db.Groups
                .Include(f => f.Specialization)
                .ThenInclude(f => f.Department)
                .ThenInclude(F => F.Faculty)
                .ThenInclude(F => F.University)
                .Include(f => f.Section)
                .FirstOrDefaultAsync(f => f.Id == id && f.DeletedById == null && f.Specialization.DeletedById == null && f.Specialization.Department.DeletedById == null && f.Specialization.Department.Faculty.DeletedById == null && f.Specialization.Department.Faculty.University.DeletedById == null);
            if (group == null)
            {
                return NotFound();
            }
            ViewData["SpecializationId"] = new SelectList(db.Specializations.Include(f => f.Department)
                .ThenInclude(f => f.Faculty)
                .ThenInclude(F => F.University)
                .Where(f => f.DeletedById == null && f.Department.DeletedById == null && f.Department.Faculty.DeletedById == null && f.Department.Faculty.University.DeletedById == null), "Id", "Name",group.SpecializationId);
            ViewData["SectionId"] = new SelectList(db.Sections.Where(s => s.DeletedById == null), "Id", "Name", group.SectionId);
            return View(group);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "admin.groups.edit")]
        public async Task<IActionResult> Edit(int id, Group group)
        {
            if (id != group.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(group);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroupExists(group.Id))
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
            return View(group);
        }
        [Authorize(Policy = "admin.groups.delete")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var group = await db.Groups
                .FirstOrDefaultAsync(f => f.DeletedById == null && f.Specialization.DeletedById == null && f.Specialization.Department.DeletedById == null && f.Specialization.Department.Faculty.DeletedById == null && f.Specialization.Department.Faculty.University.DeletedById == null);
            if (group == null)
            {
                return Json(new
                {
                    error = true,
                    message = "Mövcud deyil"
                });
            }
            //var user = await userManager.GetUserAsync(User);
            group.DeletedById = 1;
            group.DeletedDate = DateTime.UtcNow.AddHours(4);
            await db.SaveChangesAsync();
            return Json(new
            {
                error = false,
                message = "Uğurla silindi"
            });
        }

        private bool GroupExists(int id)
        {
            return db.Groups.Any(e => e.Id == id);
        }

    }
}
