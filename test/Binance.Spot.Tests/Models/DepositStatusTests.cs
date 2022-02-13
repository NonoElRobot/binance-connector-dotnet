namespace Binance.Spot.Tests.Models
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Spot.Models;

    public class DepositStatusTests
    {
        [TestMethod]
        public void ToString_Matches_Value()
        {
            DepositStatus model = DepositStatus.PENDING;

            model.ToString().Should().Be(model.Value.ToString());
        }
    }
}