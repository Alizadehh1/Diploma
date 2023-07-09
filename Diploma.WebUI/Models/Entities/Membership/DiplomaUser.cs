using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Diploma.WebUI.Models.Entities.Membership
{
    public class DiplomaUser : IdentityUser<int>
    {
    }
}
