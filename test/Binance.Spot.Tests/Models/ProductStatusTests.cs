namespace Binance.Spot.Tests.Models
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Spot.Models;

    public class ProductStatusTests
    {
        [TestMethod]
        public void ToString_Matches_Value()
        {
            ProductStatus model = ProductStatus.ALL;

            model.ToString().Should().Be(model.Value);
        }
    }
}