using AutoFixture;
using AutoFixture.Xunit2;

namespace Skeleton.Test.Attributes
{
    public class AutoMoqDataAttribute : AutoDataAttribute
    {
        public AutoMoqDataAttribute() : base(() => new Fixture().Customize(new AutoFixtureCustomization())) { }
    }
}
