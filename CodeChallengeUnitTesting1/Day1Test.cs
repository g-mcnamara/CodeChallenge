using System;
using Xunit;
using CodeChallenge;

namespace CodeChallenge.Test
{
    /// <summary>
    /// This class contains unit tests for the Day1 class of the CodeChallenge project
    /// </summary>
    public class Day1Test
    {
        [Fact]
        public void Test1()
        {
            Assert.Equal(0, Day1.FindFloor("(())"));
        }

        [Fact]
        public void Test2()
        {
            Assert.Equal(0, Day1.FirstBasement("(())"));
        }

        [Fact]
        public void PassingTest()
        {
            Assert.Equal(4, Add(2, 2));
        }

        [Fact]
        public void FailingTest()
        {
            Assert.Equal(5, Add(2, 2));
        }

        int Add(int x, int y)
        {
            return x + y;
        }
    }
}
