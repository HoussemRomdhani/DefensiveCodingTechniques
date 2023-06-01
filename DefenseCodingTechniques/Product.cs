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
            if (string.IsNullOrWhiteSpace(costInput))
                throw new ArgumentException("Please enter the cost");

            if (string.IsNullOrWhiteSpace(priceInput))
                throw new ArgumentException("Please enter the price");

            bool success = decimal.TryParse(costInput, out decimal cost);
            if (!success || cost < 0)
                throw new ArgumentException("The cost must be a number 0 or greater");

            success = decimal.TryParse(priceInput, out decimal price);
            if (!success || price <= 0)
                throw new ArgumentException("The price must be a number greater than 0");

            decimal margin = Math.Round(((price - cost) / price) * 100M);

            return margin;
        }
    }
}
