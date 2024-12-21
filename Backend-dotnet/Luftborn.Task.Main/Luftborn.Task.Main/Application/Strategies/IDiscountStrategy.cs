namespace Luftborn.Task.Main.Application.Strategies
{
    public interface IDiscountStrategy
    {
        decimal ApplyDiscount(decimal price);
    }

    public class NoDiscountStrategy : IDiscountStrategy
    {
        public decimal ApplyDiscount(decimal price)
        {
            return price;
        }
    }

    public class BlackFridayDiscountStrategy : IDiscountStrategy
    {
        public decimal ApplyDiscount(decimal price)
        {
            return price * 0.5m;
        }
    }

    public class PercentageDiscountStrategy(decimal percentage) : IDiscountStrategy
    {
        private readonly decimal _percentage = percentage;

        public decimal ApplyDiscount(decimal price)
        {
            return price * (1 - _percentage / 100);
        }
    }
}
