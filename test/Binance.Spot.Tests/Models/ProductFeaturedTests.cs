namespace Binance.Spot.Tests.Models
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Spot.Models;

    public class ProductFeaturedTests
    {
        [TestMethod]
        public void ToString_Matches_Value()
        {
            ProductFeatured model = ProductFeatured.ALL;

            model.ToString().Should().Be(model.Value);
        }
    }
}