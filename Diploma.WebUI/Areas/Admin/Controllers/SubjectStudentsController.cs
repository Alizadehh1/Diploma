using Diploma.WebUI.Models.DataContexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diploma.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SubjectStudentsController : Controller
    {
        private readonly DiplomaDbContext db;

        public SubjectStudentsController(DiplomaDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            var entity = db.Students
                .Where(s => s.SubjectId != null)
                .Include(s => s.Subject)
                .ThenInclude(s=>s.Author)
                .Include(s=>s.Group)
                .Include(s=>s.DiplomaUser)
                .ToList();

            return View(entity);
        }
    }
}
