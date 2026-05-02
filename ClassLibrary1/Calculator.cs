

namespace TradeNodeLogic
{
    public class CalculatorResult
    {
        public decimal TurnOver { get; set; }
        public decimal TotalExpenses { get; set; }
        public decimal NetProfit { get; set; }
        public decimal Margin { get; set; }
    }

    public static class AvitoCalculator
    {
        public static CalculatorResult Calculate (decimal cost, decimal quantity, decimal price, decimal CommissionPercent, decimal adsCost)
        {
            decimal turnover = price * quantity;
            decimal totalCostPrice = cost * quantity;
            decimal commissionAbsolute = turnover * (CommissionPercent / 100m);
            decimal totalExpenses = totalCostPrice + commissionAbsolute + adsCost;
            decimal netProfit = turnover - totalExpenses;

            decimal margin = 0;

            if (turnover > 0)
            {
                margin = (netProfit / turnover) * 100m;
            }

            return new CalculatorResult
            {
                TurnOver = turnover,
                TotalExpenses = totalExpenses,
                NetProfit = netProfit,
                Margin = Math.Round(margin, 2)
            };


        }
    }
}
