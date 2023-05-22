using Diploma.WebUI.Models;
using Diploma.WebUI.Models.DataContexts;
using Diploma.WebUI.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Diploma.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly DiplomaDbContext db;

        public HomeController(DiplomaDbContext db)
        {
            this.db = db;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new HomeViewModel();

            viewModel.Universities = await db.Universities
                .Where(u => u.DeletedById == null)
                .ToListAsync();

            viewModel.Faculties = await db.Faculties
                .Where(f => f.DeletedById == null && f.University.DeletedById==null)
                .ToListAsync();

            viewModel.Departments = await db.Departments
                .Where(f => f.DeletedById == null && f.Faculty.DeletedById == null && f.Faculty.University.DeletedById == null)
                .ToListAsync();

            viewModel.Specializations = await db.Specializations
                .Where(f => f.DeletedById == null && f.Department.DeletedById == null && f.Department.Faculty.DeletedById == null && f.Department.Faculty.University.DeletedById == null)
                .ToListAsync();

            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}
