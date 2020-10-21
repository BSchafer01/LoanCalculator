namespace CalculatorLogic.Models
{
    public interface ILoanConditions
    {
        decimal Balance { get; set; }
        double Rate { get; set; }
        int Term { get; set; }
        decimal AdditionalPrincipal { get; set; }
    }
}