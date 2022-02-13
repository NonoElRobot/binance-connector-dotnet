namespace Binance.Spot.Tests.Models
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Spot.Models;

    public class AccountTypeTests
    {
        [TestMethod]
        public void ToString_Matches_Value()
        {
            AccountType model = AccountType.SPOT;

            model.ToString().Should().Be(model.Value);
        }
    }
}