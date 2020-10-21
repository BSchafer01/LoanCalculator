using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorLogic.Models
{
    public class LoanConditions : ILoanConditions
    {
        public decimal Balance { get; set; }
        public int Term { get; set; }
        public double Rate { get; set; }
        public decimal AdditionalPrincipal { get; set; }
    }
}
