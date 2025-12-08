using Geometry;

namespace TestLekcija14
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Assert.Equal(4, 2+2);
        }

        [Fact]
        public void Test2()
        {
            Assert.Equal(5, 2 + 2+1);
        }



        [Fact]

        public void Rectangle_Area_4_3() {
            var r = new Rectangle() { Height = 4, Width = 3 };
            Assert.Equal(12, r.Area);
        }

        [Theory]
        [InlineData(2, 3, 6)]
        [InlineData(2, 2, 4)]
        [InlineData(1, 1, 1)]
        [InlineData(1, 2, 2)]
        public void Rectangle_Area_Correct(int x, int y, int area)
        {
            var r = new Rectangle() { Height = x, Width = y };
            Assert.Equal(area, r.Area);
        }

    }
}
