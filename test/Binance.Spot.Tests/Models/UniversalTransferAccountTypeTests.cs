namespace Binance.Spot.Tests.Models
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Spot.Models;

    public class UniversalTransferAccountTypeTests
    {
        [TestMethod]
        public void ToString_Matches_Value()
        {
            UniversalTransferAccountType model = UniversalTransferAccountType.SPOT;

            model.ToString().Should().Be(model.Value);
        }
    }
}