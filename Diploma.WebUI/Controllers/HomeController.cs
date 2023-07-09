using Diploma.WebUI.AppCode.Extensions;
using Diploma.WebUI.Models.DataContexts;
using Diploma.WebUI.Models.Entities.Membership;
using Diploma.WebUI.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Diploma.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly DiplomaDbContext db;
        private readonly UserManager<DiplomaUser> userManager;

        public HomeController(DiplomaDbContext db, UserManager<DiplomaUser> userManager)
        {
            this.db = db;
            this.userManager = userManager;
        }
        [Authorize(Policy = "home.index")]
        public async Task<IActionResult> Index()
        {
            var viewModel = new HomeViewModel();

            viewModel.Authors = await db.Authors
                .ToListAsync();
            viewModel.Subjects = await db.Subjects
                .Where(s => s.DeletedById == null)
                .Include(s => s.Author)
                .ToListAsync();

            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> SelectSubject([FromRoute] int id)
        {
            var subject = await db.Subjects
                .FirstOrDefaultAsync(m => m.Id == id && m.DeletedById == null);

            var user = await db.Students
                .Include(a => a.DiplomaUser)
                .FirstOrDefaultAsync(a => a.DiplomaUserId == Convert.ToInt32(User.GetUserId()));

            if (subject == null)
            {
                return Json(new
                {
                    error = true,
                    message = "Mövcud deyil"
                });
            }

            if (user.SubjectId != null)
            {
                return Json(new
                {
                    error = true,
                    message = "Siz artiq diplom isi secmisiniz"
                });
            }

            user.SubjectId = id;
            await db.SaveChangesAsync();
            return Json(new
            {
                error = false,
                message = "Uğurla secildi"
            });
        }
    }
}
