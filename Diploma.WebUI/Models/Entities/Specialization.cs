using Diploma.WebUI.AppCode.Infrastructure;

namespace Diploma.WebUI.Models.Entities
{
    public class Specialization : BaseEntity
    {
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }
}
