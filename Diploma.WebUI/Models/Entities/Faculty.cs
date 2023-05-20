using Diploma.WebUI.AppCode.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diploma.WebUI.Models.Entities
{
    public class Faculty : BaseEntity
    {
        public string Name { get; set; }
        public int UniversityId { get; set; }
        public virtual University University { get; set; }
    }
}
