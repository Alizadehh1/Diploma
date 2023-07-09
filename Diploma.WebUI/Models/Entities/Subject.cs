using Diploma.WebUI.AppCode.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diploma.WebUI.Models.Entities
{
    public class Subject : BaseEntity
    {
        public string Name { get; set; }
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }
    }
}
