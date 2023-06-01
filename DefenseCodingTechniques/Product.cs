using DefenseCodingTechniques.Utilities;

namespace DefensiveCodingTechniques
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// Calculate the potential profit margin.
        /// </summary>
        /// <param name="costInput">Cost (from user input as string)</param>
        /// <param name="priceInput">Suggested price (from user input as string)</param>
        /// <returns>Resulting profit margin</returns>
        public decimal CalculateMargin(string costInput, string priceInput)
        {
            Guard.ThrowIfNullOrEmpty(costInput, "Please enter the cost");
            Guard.ThrowIfNullOrEmpty(priceInput, "Please enter the price");

            var cost = Guard.ThrowIfNotPositiveDecimal(costInput, "The cost must be a number 0 or greater");
            var price = Guard.ThrowIfNotPositiveNonZeroDecimal(priceInput, "The price must be a number greater than 0");

            return CalculateMargin(cost, price);
        }

        private decimal CalculateMargin(decimal cost, decimal price)
        {
           return Math.Round((price - cost) / price * 100M);
        }
    }
}
