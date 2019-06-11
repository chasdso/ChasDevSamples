using GenericNamespace;
using System;
using Xunit;

namespace GenericSampleCore1.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void PassingTest()
        {
            GenericSample testGenericSample = new GenericSample();
            Assert.Equal(5, testGenericSample.Add(2, 3));
        }
        [Fact]
        public void FailingTest()

        {
            GenericSample testGenericSample = new GenericSample();
            Assert.Equal(5, testGenericSample.Add(2, 2));
        }

        [Theory]
        [InlineData(2, 3)]
        [InlineData(3, 3)]

        public void TestAdd(int x, int y)
        {
            GenericSample testGenericSample = new GenericSample();
            Assert.Equal(5, testGenericSample.Add(x, y));
        }


    }
}