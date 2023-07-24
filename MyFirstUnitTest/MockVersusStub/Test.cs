using Xunit.Abstractions;
using MyFirstUnitTest.MockVersusStub;
using Moq;

namespace MyFirstUnitTest.MockVersusStub
{
    // https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-best-practices
    public  class Test
    {
        [Fact]
        public void IsVandaagJarig_DatumIs19701130_IsWaargaatNIetwerken()
        {
            TestObject mock = Mocks.GetMock1();
            // Maar wat is dan vandaag?
            Assert.True(mock.IsVandaagJarigNietTestBaarIvmTijdReizen());

        }

        [Fact]
        public void IsVandaagJarig_DatumIs19800501_IsWaar()
        {
            StubTijdReizen stubdate1980 = new(new DateTime(1970, 11, 30));
            TestObject mock = Mocks.GetMock1();
            // Maar wat is dan vandaag?
            Assert.True(mock.IsVandaagJarig(stubdate1980));

        }




        [Fact]
        public void IsVandaagJarig_DatumIs19800501_IsNietWaar()
        {
            StubTijdReizen stubdate1980 = new (new DateTime(1980, 5, 1));
            TestObject mock = Mocks.GetMock1();
            // Maar wat is dan vandaag?
            Assert.False(mock.IsVandaagJarig(stubdate1980));

        }

        // NU als Mock, die je kunt configureren dan heb je geen aparte StubTijdReizen nodig
        // Meteen alleen de uitvoer definieren.

        [Fact]
        public void IsVandaagJarig_DatumIs20211130_IsWaar_Mock()
        {
            var stubdate = new Moq.Mock<IDateTimeProvider>();
            stubdate.Setup(x => x.GetNow()).Returns(new DateTime(2021, 11, 30));

            TestObject mock = Mocks.GetMock1();
            // Maar wat is dan vandaag?
            Assert.True(mock.IsVandaagJarig(stubdate.Object));

        }

        [Fact]
        public void IsVandaagJarig_DatumIs19703011_IsNietWaar_Mock()
        {
            var stubdate = new Moq.Mock<IDateTimeProvider>();
            stubdate.Setup(x => x.GetNow()).Returns(new DateTime(1970, 11, 30));

            TestObject mock = Mocks.GetMock1();
            // Maar wat is dan vandaag?
            Assert.True(mock.IsVandaagJarig(stubdate.Object));

        }

        [Fact]
        public void IsNOgEentest_DatumIs20211130_IsWaar_Mock()
        {
            var stubdate = new Moq.Mock<IDateTimeProvider>();
            stubdate.Setup(x => x.GetNow()).Returns(new DateTime(2021, 11, 30));
            stubdate.Setup(x => x.GetNowPlus10Days()).Returns(new DateTime(2021, 11, 30).AddDays(10));

            TestObject mock = Mocks.GetMock1();
            // Maar wat is dan vandaag?
            Assert.False(mock.IsOver10DagenJarig(stubdate.Object));

        }





    }
}
