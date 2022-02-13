namespace Binance.Spot.Tests.Models
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Spot.Models;

    public class SideEffectTypeTests
    {
        [TestMethod]
        public void ToString_Matches_Value()
        {
            SideEffectType model = SideEffectType.NO_SIDE_EFFECT;

            model.ToString().Should().Be(model.Value);
        }
    }
}