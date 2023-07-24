namespace MyFirstUnitTests;

public class UnitTest2
{

    //  TEST is te spliten in [Fact] en [Theories]
    [Fact]
    public void PassingTest()
    {
        Assert.Equal(4, Add(2, 2));
    }

    /// Onderstaande kan niet bij een  Fact
    //[Fact]
    //[InlineData(2,2)]
    //[InlineData(3, 2)]
    //[InlineData(-4, 8)]
    //public void PassingTest2(int a, int b)
    //{
    //    Assert.Equal(4, Add(a, b));
    //}

    [Theory]
    [InlineData(2, 2, 4)]
    [InlineData(3, 2, 5)]
    [InlineData(-4, 8, 4)]
    public void PassingTest2(int a, int b, int result)
    {
        Assert.Equal(result, Add(a, b));
    }



    [Fact]
    public void FailingTest()
    {
        Assert.Equal(5, Add(2, 2));
    }

    [Theory]
    [InlineData(3)]
    [InlineData(5)]
    [InlineData(6)]
    public void MyFirstTheory(int value)
    {
        Assert.True(IsOdd(value));
    }

    [Theory]
    [InlineData(3)]
    [InlineData(5)]
    public void MyFirstTheory2(int value)
    {
        Assert.True(IsOdd(value));
    }
    [Theory]
    [InlineData(6)]
    public void MyFirstTheory3(int value)
    {
        Assert.False(IsOdd(value));
    }

    /// <summary>
    ///  te testen functie normaal in een ander project
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    private static int Add(int x, int y)
    {
        return x + y;
    }

    /// <summary>
    /// tesen ia a Theorie
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static bool IsOdd(int value)
    {
        return value % 2 == 1;
    }
}
