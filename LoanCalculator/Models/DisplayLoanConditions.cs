using CalculatorLogic.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoanCalculator.Models
{
    public class DisplayLoanConditions : ILoanConditions
    {
        [Required]
        public string LoanName { get; set; }

        [Required]
        [Range(10, 1000000000, ErrorMessage = "Please enter a loan amount between $10 and $1,000,000,000.")]
        public decimal Balance { get; set; }
        [Required]
        [Range(0, 35, ErrorMessage = "Please enter an interest rate between 0 and 35 percent.")]
        public double Rate { get; set; }
        [Required]
        [Range(1, 480, ErrorMessage = "Please enter a term between 1 month and 480 months (40 years).")]
        public int Term { get; set; }
        public decimal AdditionalPrincipal { get; set; }
    }
}
