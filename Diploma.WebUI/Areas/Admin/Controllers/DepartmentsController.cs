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
    public class DepartmentsController : Controller
    {
        private readonly DiplomaDbContext db;

        public DepartmentsController(DiplomaDbContext db)
        {
            this.db = db;
        }
        public async Task<IActionResult> Index()
        {
            var model = await db.Departments
                .Include(f => f.Faculty)
                .ThenInclude(f => f.University)
                .Where(f => f.DeletedById == null && f.Faculty.DeletedById == null && f.Faculty.University.DeletedById == null)
                .ToListAsync();

            return View(model);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity = await db.Departments
                .Include(f=>f.Faculty)
                .ThenInclude(F=>F.University)
                .FirstOrDefaultAsync(f => f.DeletedById == null && f.Faculty.DeletedById == null && f.Faculty.University.DeletedById == null && f.Id == id);

            return View(entity);
        }

        public IActionResult Create()
        {
            ViewData["FacultyId"] = new SelectList(db.Faculties.Where(f => f.DeletedById == null && f.University.DeletedById == null).Include(f => f.University), "Id", "Name");

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Department department)
        {
            if (ModelState.IsValid)
            {
                db.Add(department);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await db.Departments.FirstOrDefaultAsync(f => f.DeletedById == null && f.Faculty.DeletedById == null && f.Faculty.University.DeletedById == null && f.Id == id);
            if (department == null)
            {
                return NotFound();
            }
            ViewData["FacultyId"] = new SelectList(db.Faculties.Where(f => f.DeletedById == null && f.University.DeletedById == null).Include(f => f.University), "Id", "Name", department.FacultyId);
            return View(department);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Policy = "admin.universities.edit")]
        public async Task<IActionResult> Edit(int id, Department department)
        {
            if (id != department.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(department);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartmentExists(department.Id))
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
            return View(department);
        }
        //[Authorize(Policy = "admin.universities.delete")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var color = await db.Departments
                .FirstOrDefaultAsync(f => f.DeletedById == null && f.Faculty.DeletedById == null && f.Faculty.University.DeletedById == null);
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

        private bool DepartmentExists(int id)
        {
            return db.Departments.Any(e => e.Id == id);
        }

    }
}
