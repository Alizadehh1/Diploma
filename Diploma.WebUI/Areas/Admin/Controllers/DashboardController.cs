﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Diploma.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        //[Authorize(Policy = "admin.dashboard.index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
