using Diploma.WebUI.AppCode.Infrastructure;
using Diploma.WebUI.Models.Entities.Membership;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diploma.WebUI.Models.Entities
{
    public class Student : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FatherName { get; set; }
        public string PhoneNumber { get; set; }
        public int GroupId { get; set; }
        public virtual Group Group { get; set; }
        public int DiplomaUserId { get; set; }
        public virtual DiplomaUser DiplomaUser { get; set; }
        public int? SubjectId { get; set; }
        public virtual Subject Subject { get; set; }

    }
}
