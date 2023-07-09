using Diploma.WebUI.AppCode.Infrastructure;
using Diploma.WebUI.Models.Entities.Membership;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diploma.WebUI.Models.Entities
{
    public class Author : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FatherName { get; set; }
        public string Biography { get; set; }
        public string Area { get; set; }
        public string Education { get; set; }
        public string ImagePath { get; set; }
        public int DiplomaUserId { get; set; }
        public virtual DiplomaUser DiplomaUser { get; set; }
        public int AcademicDegreeId { get; set; }
        public virtual AcademicDegree AcademicDegree { get; set; }
    }
}
