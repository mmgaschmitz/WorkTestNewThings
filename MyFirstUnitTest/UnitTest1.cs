using MyFirstUnitTest;
using NuGet.Frameworks;
using Xunit.Abstractions;

namespace MyFirstUnitTests;

public class UnitTest1
{
    private readonly ITestOutputHelper output;

    public UnitTest1(ITestOutputHelper output)
    {
        this.output = output;
    }

    //  TEST is te spliten in [Fact] en [Theories]
    [Fact]
    public void PassingTest()
    {
        // Meerdere asserts wel/niet doen?
        output.WriteLine("PassingTest eenvoudige test blabla 1");
        Assert.Equal(4, Add(2, 2));
        output.WriteLine("PassingTest eenvoudige test blabla 2");
        Assert.True(4 == 4);
        output.WriteLine("PassingTest eenvoudige test blabla 3");
        Assert.False(4 == 3);
    }

    [Fact]
    public void ClassCompare1()
    {
        MyClass a = new() {  Name="Maurice", Adress="home street 1"};
        MyClass b = new() { Name = "Elvira", Adress = "home street 2" };
        // Assert.Equal<MyClass>.Compare(a, b);
        // Assert.True(a.Equals(b));
        // Assert.Equal(a, b);
        Assert.Equivalent(a, b, strict: true);
    }

    [Fact]
    public void ClassCompare2()
    {
        MyClass a = new() { Name = "Maurice", Adress = "home street 1" };
        MyClass b = new () { Name = "Maurice", Adress = "home street 1" };
        // Assert.Equal<MyClass>.Compare(a, b);
        // Assert.Equal(a, b);
        //Assert.True(a.Equals(b));
        Assert.Equivalent(a, b, strict: true);
    }

    [Fact]
    public void RecordCompare1()
    {
        MyRecord a = new ( Name : "Maurice", Adress: "home street 1" );
        MyRecord b = new ( Name : "Maurice", Adress : "home street 1" );
        // Assert.Equal<MyClass>.Compare(a, b);
        // Assert.Equal(a, b);
        //Assert.True(a.Equals(b));
        Assert.True(a == b);
    }

    [Fact]
    public void RecordCompare2()
    {
        MyRecord a = new (Name: "elvira", Adress: "home street 1");
        MyRecord b = new (Name: "Maurice", Adress: "home street 2");
        Assert.True(a == b);
    }

    [Fact]
    public void RecordCompare3()
    {
        MyRecord a = new(Name: "elvira", Adress: "home street 1");
        MyRecord b = new(Name: "Maurice", Adress: "home street 2");
        Assert.Equivalent(a, b, strict: true);
    }

    [Fact]
    public void RecordCompare4()
    {
        MyRecord a = new(Name: "elvira", Adress: "home street 1");
        MyRecord b = new(Name: "elvira", Adress: "home street 1");
        Assert.True(a.GetType() == b.GetType());
        Assert.Equivalent(a, b, strict: true);
    }

    [Fact]
    public void RecordClassCompare1()
    {
        MyRecord a = new(Name: "elvira", Adress: "home street 1");
        MyClass b = new() { Name = "elvira", Adress = "home street 1" };
        Assert.True(a.GetType() == b.GetType());
        Assert.Equivalent(a, b, strict: true);
    }

    [Fact]
    public void RecordClassCompare2()
    {
        MyRecord a = new (Name: "elvira", Adress: "home street 1");
        MyClass b = new() { Name = "elvira", Adress = "home street 1" };
        Assert.Equivalent(a, b, strict: true);
    }

    [Fact]
    public void RecordClassCompare3()
    {
        MyRecord a = new (Name: "elvira", Adress: "home street 1");
        MyClass b = new() { Name = "elvira", Adress = "home street 1" };
        Assert.Equivalent(a, b, strict: false);
    }

    [Fact]
    public void Record2Types()
    {
        MyRecord a = new (Name: "elvira", Adress: "home street 1");
        MyRecord2 b = new (Name: "elvira", Adress: "home street 1");
        Assert.True(a.GetType() == b.GetType());
        Assert.Equivalent(a, b, strict: false);
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
