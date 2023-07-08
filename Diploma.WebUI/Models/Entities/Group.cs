using Diploma.WebUI.AppCode.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diploma.WebUI.Models.Entities
{
    public class Group : BaseEntity
    {
        public string Name { get; set; }
        public int SpecializationId { get; set; }
        public virtual Specialization Specialization { get; set; }
        public int SectionId { get; set; }
        public virtual Section Section { get; set; }
    }
}
