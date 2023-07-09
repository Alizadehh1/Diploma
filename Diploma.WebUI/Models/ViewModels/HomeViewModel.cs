using Diploma.WebUI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diploma.WebUI.Models.ViewModels
{
    public class HomeViewModel
    {
        public List<Subject> Subjects { get; set; }
        public List<Author> Authors { get; set; }
    }
}
