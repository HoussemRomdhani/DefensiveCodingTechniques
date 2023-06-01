namespace DefenseCodingTechniques.Utilities
{
    public static class Guard
    {
        public static void ThrowIfNullOrEmpty(string argumentValue, string message)
        {
            if (string.IsNullOrWhiteSpace(argumentValue)) throw new ArgumentException(message);
        }

        public static decimal ThrowIfNotPositiveDecimal(string argumentValue, string message)
        {
            var success = decimal.TryParse(argumentValue, out decimal result);
            if (!success || result < 0) throw new ArgumentException(message);

            return result;
        }

        public static decimal ThrowIfNotPositiveNonZeroDecimal(string argumentValue, string message)
        {
            var success = decimal.TryParse(argumentValue, out decimal result);
            if (!success || result <= 0) throw new ArgumentException(message);

            return result;
        }
    }
}