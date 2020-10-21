using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorLogic.Models
{
    public class MonthlyResults : IMonthlyResults
    {
        public int Month { get; set; }
        public decimal TotalPayment { get; set; }
        public decimal Balance { get; set; }
        public decimal InterestPayment { get; set; }
        public decimal PrincipalPayment { get; set; }
        public decimal TotalInterest { get; set; }
        public decimal TotalPaid { get; set; }
        public decimal AdditionalPrincipal { get; set; }
        public decimal AdditionalInterest { get; set; }
        public decimal AdditionalTotalInterest { get; set; }
        public decimal AdditionalTotalPrincipal { get; set; }
        public decimal AdditionalBalance { get; set; }


    }
}
