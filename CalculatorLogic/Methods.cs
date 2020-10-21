using CalculatorLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorLogic
{
    public class Methods
    {
        public static List<IMonthlyResults> CalculateResults(ILoanConditions conditions)
        {
            List<IMonthlyResults> results = new List<IMonthlyResults>();

            //MonthlyResults month0 = new MonthlyResults()
            //{
            //    Balance = conditions.Balance,
            //    Month = 0,
            //    TotalPayment = 0,
            //    PrincipalPayment = 0,
            //    InterestPayment = 0,
            //    TotalInterest = 0,
            //    TotalPaid = 0,
            //    AdditionalBalance = conditions.Balance,
            //    AdditionalPrincipal = 0,
            //    AdditionalInterest = 0,
            //    AdditionalTotalInterest = 0,
            //    AdditionalTotalPrincipal = 0
            //};
            //results.Add(month0);

            decimal tmp = conditions.Balance * Convert.ToDecimal((conditions.Rate / 1200) / (1 - Math.Pow((1 + conditions.Rate / 1200), -1 * conditions.Term)));
            decimal remainingBalance = conditions.Balance;
            decimal totalInt = 0;
            decimal totalPd = 0;
            decimal addTmp = tmp + conditions.AdditionalPrincipal;
            decimal addRemainingBalance = conditions.Balance;
            decimal addTotalInt = 0;
            decimal addTotalPd = 0;

            for (int i = 1; i <= conditions.Term; i++)
            {
                decimal ip = remainingBalance * Convert.ToDecimal(conditions.Rate / 1200);
                decimal tp = tmp - ip;

                decimal addIp = addRemainingBalance * Convert.ToDecimal(conditions.Rate / 1200);
                if ((addRemainingBalance + addIp)<addTmp)
                {
                    addTmp = addRemainingBalance + addIp;
                }
                decimal addTp = addTmp - addIp;
                MonthlyResults month = new MonthlyResults()
                {
                    Month = i,
                    TotalPayment = tmp,
                    InterestPayment = ip,
                    PrincipalPayment = tp,
                    TotalInterest = totalInt + ip,
                    TotalPaid = totalPd + tmp,
                    Balance = remainingBalance - tp,
                    AdditionalPrincipal = addTp,
                    AdditionalInterest = addIp,
                    AdditionalTotalInterest = addTotalInt + addIp,
                    AdditionalTotalPrincipal = addTotalPd + addTmp,
                    AdditionalBalance = addRemainingBalance - addTp
                };

                remainingBalance = month.Balance;
                totalPd = month.TotalPaid;
                totalInt = month.TotalInterest;

                addRemainingBalance = month.AdditionalBalance;
                addTotalInt = month.AdditionalTotalInterest;
                addTotalPd = month.AdditionalTotalPrincipal;

                results.Add(month);
            }

            return results;
        }
    }
}
