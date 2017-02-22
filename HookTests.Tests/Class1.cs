using FluentAssertions;
using NUnit.Framework;

namespace HookTests.Tests
{
    public class Class1
    {
        [Test]
        public void test_s()
        {
            Calculator.Add(1, 2).Should().Be(3);
        }

        [Test]
        public void test_f()
        {
            Calculator.Add(1, 2).Should().Be(4);
        }
    }
}
