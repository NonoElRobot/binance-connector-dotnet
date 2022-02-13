namespace Binance.Spot.Tests.Models
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Spot.Models;

    public class LoanDirectionTests
    {
        [TestMethod]
        public void ToString_Matches_Value()
        {
            LoanDirection model = LoanDirection.ADDITIONAL;

            model.ToString().Should().Be(model.Value);
        }
    }
}