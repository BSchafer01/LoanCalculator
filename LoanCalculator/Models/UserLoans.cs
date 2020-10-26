using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LoanCalculator.Models
{
    public class UserLoans
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string LoanName { get; set; }
        public ApplicationUser User { get; set; }
        [Required]
        [Column(TypeName = "Money")]
        public decimal LoanAmount { get; set; }
        [Required]
        public double InterestRate { get; set; }
        [Column(TypeName = "Money")]
        public decimal AdditionalPrincipal { get; set; }
        [Required]
        public int LoanTerm { get; set; }
    }
}
