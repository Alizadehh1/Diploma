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
    public class StatusesController : Controller
    {
        private readonly DiplomaDbContext db;

        public StatusesController(DiplomaDbContext db)
        {
            this.db = db;
        }
        [Authorize("admin.statuses.index")]
        public async Task<IActionResult> Index()
        {
            var model = await db.Statuses
                .Where(u => u.DeletedById == null)
                .ToListAsync();

            return View(model);
        }
        [Authorize("admin.statuses.details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity = await db.Statuses
                .FirstOrDefaultAsync(u => u.DeletedById == null && u.Id == id);

            return View(entity);
        }
        [Authorize("admin.statuses.create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "admin.statuses.create")]
        public async Task<IActionResult> Create(Status Status)
        {
            if (ModelState.IsValid)
            {
                db.Add(Status);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Status);
        }
        [Authorize(Policy = "admin.statuses.edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Status = await db.Statuses.FirstOrDefaultAsync(c => c.DeletedById == null && c.Id == id);
            if (Status == null)
            {
                return NotFound();
            }
            return View(Status);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "admin.statuses.edit")]
        public async Task<IActionResult> Edit(int id, Status Status)
        {
            if (id != Status.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(Status);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StatusExists(Status.Id))
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
            return View(Status);
        }
        [Authorize(Policy = "admin.statuses.delete")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var color = await db.Statuses
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

        private bool StatusExists(int id)
        {
            return db.Statuses.Any(e => e.Id == id);
        }
    }
}
