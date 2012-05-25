namespace Fluency.Tests.Framework
{
    using System;

    using Fluency.Framework;

    using NUnit.Framework;

    [TestFixture]
    public class FluentPropertyTests
    {
        [Test]
        public void CanSetValue()
        {
            FluentProperty<int> prop = 10;

            Assert.That(prop.PropertySet,
                Is.True);
            Assert.That(prop.Value,
                Is.EqualTo(10));
        }

        [Test]
        public void NewInstanceHasFalsePropertySet()
        {
            var prop = new FluentProperty<int>();

            Assert.That(prop.PropertySet,
                Is.False);
        }

        [Test]
        public void PropertyNotSetThrowsInvalidOperationException()
        {
            var prop = new FluentProperty<int>();

            Assert.Throws<InvalidOperationException>(() => { int i = prop.Value; },
                "The property value is not set.");
        }

        [Test]
        public void PropertySetIsChosenWhenConditionalOrMethodIsCalled()
        {
            var nextProp = new FluentProperty<int>();

            var oldProp = new FluentProperty<int>();

            Assert.That(nextProp.Or(oldProp),
                Is.EqualTo(default(FluentProperty<int>)));

            oldProp = 10;

            Assert.That(nextProp.Or(oldProp).Value,
                Is.EqualTo(10));

            nextProp = 12;

            Assert.That(nextProp.Or(oldProp).Value,
                Is.EqualTo(12));
        }
    }
}
