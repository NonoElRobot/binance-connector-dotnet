namespace Binance.Spot.Tests.Models
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Spot.Models;

    public class FiatPaymentTransactionTypeTests
    {
        [TestMethod]
        public void ToString_Matches_Value()
        {
            FiatPaymentTransactionType model = FiatPaymentTransactionType.BUY;

            model.ToString().Should().Be(model.Value.ToString());
        }
    }
}