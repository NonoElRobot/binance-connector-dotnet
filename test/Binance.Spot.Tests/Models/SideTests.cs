namespace Binance.Spot.Tests.Models
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Spot.Models;

    public class SideTests
    {
        [TestMethod]
        public void ToString_Matches_Value()
        {
            Side model = Side.BUY;

            model.ToString().Should().Be(model.Value);
        }
    }
}