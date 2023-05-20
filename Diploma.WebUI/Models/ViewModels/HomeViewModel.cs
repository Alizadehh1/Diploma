using Diploma.WebUI.Models.Entities;
using System.Collections.Generic;

namespace Diploma.WebUI.Models.ViewModels
{
    public class HomeViewModel
    {
        public List<University> Universities { get; set; }
        public List<Faculty> Faculties { get; set; }
    }
}
