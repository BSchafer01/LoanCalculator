using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LoanCalculator.Models
{
    public class ApplicationUser: IdentityUser
    {
        [Required]
        public string FName { get; set; }

    }
}
