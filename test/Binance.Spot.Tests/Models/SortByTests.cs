namespace Binance.Spot.Tests.Models
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Spot.Models;

    public class SortByTests
    {
        [TestMethod]
        public void ToString_Matches_Value()
        {
            SortBy model = SortBy.START_TIME;

            model.ToString().Should().Be(model.Value);
        }
    }
}