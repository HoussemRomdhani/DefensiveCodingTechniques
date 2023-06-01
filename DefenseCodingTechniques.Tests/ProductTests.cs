using DefensiveCodingTechniques;

namespace DefenseCodingTechniques.Tests
{
    public class ProductTests
    {
        [Fact]
        public void CalculateMargin_WhenValidCost50PercentOfPrice_ShouldReturn50()
        {
            // Arrange
            string cost = "50";
            string price = "100";
            decimal expected = 50;
            var product = new Product();

            // Act
            decimal actual = product.CalculateMargin(cost, price);

            // Assert
            Assert.Equal(expected, actual);
        }
     
        [Fact]
        public void CalculateMargin_WhenValidCostEqualPrice_ShouldReturn0()
        {
            // Arrange
            string cost = "100";
            string price = "100";
            decimal expected = 0;
            var product = new Product();

            // Act
            decimal actual = product.CalculateMargin(cost, price);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CalculateMargin_WhenValidCostIsMoreThanPrice_ShouldReturnNegative()
        {
            // Arrange
            string cost = "120";
            string price = "100";
            decimal expected = -20;
            var product = new Product();

            // Act
            decimal actual = product.CalculateMargin(cost, price);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CalculateMargin_WhenValidCostIsZero_ShouldReturn100()
        {
            // Arrange
            string cost = "0";
            string price = "100";
            decimal expected = 100;
            var product = new Product();

            // Act
            decimal actual = product.CalculateMargin(cost, price);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CalculateMargin_WhenValidSmallValues50PercentOfPrice_ShouldReturn50()
        {
            // Arrange
            string cost = ".01";
            string price = ".02";
            decimal expected = 50M;
            var product = new Product();

            // Act
            decimal actual = product.CalculateMargin(cost, price);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CalculateMargin_WhenValidCostOneThirdOfPrice_ShouldRoundTo33()
        {
            // Arrange
            string cost = "100";
            string price = "150";
            decimal expected = 33;
            var product = new Product();

            // Act
            decimal actual = product.CalculateMargin(cost, price);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CalculateMargin_WhenValidCostLessThan1_ShouldReturn100()
        {
            // Arrange
            string cost = ".01";
            string price = "100";
            decimal expected = 100M;
            var product = new Product();

            // Act
            decimal actual = product.CalculateMargin(cost, price);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CalculateMargin_WhenValidCostCloseToPrice_ShouldReturn1()
        {
            // Arrange
            string cost = "100";
            string price = "101";
            decimal expected = 1M;
            var product = new Product();

            // Act
            decimal actual = product.CalculateMargin(cost, price);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CalculateMargin_WhenValidCostContainsDecimal50PercentOfPrice_ShouldReturn50()
        {
            // Arrange
            string cost = "49.55";
            string price = "100";
            decimal expected = 50M;
            var product = new Product();

            // Act
            decimal actual = product.CalculateMargin(cost, price);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CalculateMargin_WhenInvalidPriceIs0_ShouldGenerateError()
        {
            // Arrange
            string cost = "50";
            string price = "0";
            var product = new Product();

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => product.CalculateMargin(cost, price));
            Assert.Equal("The price must be a number greater than 0", ex.Message);
        }

        [Fact]
        public void CalculateMargin_WhenInvalidPriceIsEmpty_ShouldGenerateError()
        {
            // Arrange
            string cost = "50";
            string price = "";
            var product = new Product();

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => product.CalculateMargin(cost, price));
            Assert.Equal("Please enter the price", ex.Message);
        }

        [Fact]
        public void CalculateMargin_WhenInvalidCostIsEmpty_ShouldGenerateError()
        {
            // Arrange
            string cost = "";
            string price = "100";
            var product = new Product();

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => product.CalculateMargin(cost, price));
            Assert.Equal("Please enter the cost", ex.Message);
        }

        [Fact]
        public void CalculateMargin_WhenInvalidPriceIsNull_ShouldGenerateError()
        {
            // Arrange
            string cost = "50";
            string price = null;
            var product = new Product();

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() =>
                                        product.CalculateMargin(cost, price));
            Assert.Equal("Please enter the price", ex.Message);
        }

        [Fact]
        public void CalculateMargin_WhenInvalidCostIsNull_ShouldGenerateError()
        {
            // Arrange
            string cost = null;
            string price = "100";
            var product = new Product();

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() =>
                                        product.CalculateMargin(cost, price));
            Assert.Equal("Please enter the cost", ex.Message);
        }

        [Fact]
        public void CalculateMargin_WhenInvalidPriceIsNotANumber_ShouldGenerateError()
        {
            // Arrange
            string cost = "50";
            string price = "Hundred";
            var product = new Product();

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => product.CalculateMargin(cost, price));
            Assert.Equal("The price must be a number greater than 0", ex.Message);
        }

        [Fact]
        public void CalculateMargin_WhenInvalidCostIsNotANumber_ShouldGenerateError()
        {
            // Arrange
            string cost = "Fifty";
            string price = "100";
            var product = new Product();

            // Act
            Action act = () => product.CalculateMargin(cost, price);

            // Assert
            var ex = Assert.Throws<ArgumentException>(act);
            Assert.Equal("The cost must be a number 0 or greater", ex.Message);
        }

        [Fact]
        public void CalculateMargin_WhenInvalidCostContainsDollar_ShouldError()
        {
            // Arrange
            string cost = "$49.95";
            string price = "100";
            var product = new Product();

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() =>
                                            product.CalculateMargin(cost, price));
            Assert.Equal("The cost must be a number 0 or greater",
                          ex.Message);
        }
    }
}