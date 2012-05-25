namespace Fluency.Tests.Framework
{
    using Fluency.Framework;

    public class MockConfiguration : IConfiguration<MockConfiguration>
    {
        public FluentProperty<int> Number { get; set; }

        public FluentProperty<bool?> Flag { get; set; }

        public MockConfiguration Update(MockConfiguration next)
        {
            return new MockConfiguration
                {
                    Number = next.Number.Or(this.Number), 
                    Flag = next.Flag.Or(this.Flag)
                };
        }
    }
}
