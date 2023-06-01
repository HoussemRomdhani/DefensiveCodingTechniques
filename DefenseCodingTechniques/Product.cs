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
            decimal cost = decimal.Parse(costInput);
            decimal price = decimal.Parse(priceInput);

            var margin = ((price - cost) / price) * 100M;

            return margin;
        }

    }
}
