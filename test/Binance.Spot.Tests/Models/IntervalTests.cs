namespace Binance.Spot.Tests.Models
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Spot.Models;

    public class IntervalTests
    {
        [TestMethod]
        public void ToString_Matches_Value()
        {
            Interval model = Interval.ONE_MINUTE;

            model.ToString().Should().Be(model.Value);
        }
    }
}