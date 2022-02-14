namespace Binance.Spot.Tests.Models
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Spot.Models;

    public class LendingTypeTests
    {
        [TestMethod]
        public void ToString_Matches_Value()
        {
            LendingType model = LendingType.DAILY;

            model.ToString().Should().Be(model.Value);
        }
    }
}