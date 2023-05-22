using Diploma.WebUI.Models.Entities;
using System.Collections.Generic;

namespace Diploma.WebUI.Models.ViewModels
{
    public class HomeViewModel
    {
        public List<University> Universities { get; set; }
        public List<Faculty> Faculties { get; set; }
        public List<Department> Departments { get; set; }
        public List<Specialization> Specializations { get; set; }
    }
}
