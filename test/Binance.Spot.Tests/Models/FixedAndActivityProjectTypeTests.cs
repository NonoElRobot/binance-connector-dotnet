namespace Binance.Spot.Tests.Models
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Spot.Models;

    public class FixedAndActivityProjectTypeTests
    {
        [TestMethod]
        public void ToString_Matches_Value()
        {
            FixedAndActivityProjectType model = FixedAndActivityProjectType.ACTIVITY;

            model.ToString().Should().Be(model.Value);
        }
    }
}