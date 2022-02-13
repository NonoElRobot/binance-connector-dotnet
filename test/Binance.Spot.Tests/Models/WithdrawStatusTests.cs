namespace Binance.Spot.Tests.Models
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Spot.Models;

    public class WithdrawStatusTests
    {
        [TestMethod]
        public void ToString_Matches_Value()
        {
            WithdrawStatus model = WithdrawStatus.EMAIL_SENT;

            model.ToString().Should().Be(model.Value);
        }
    }
}