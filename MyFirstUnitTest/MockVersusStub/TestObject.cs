using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstUnitTest.MockVersusStub
{
    // tijd reizen, maak een interface voor de datum now
    public interface IDateTimeProvider
    {
        DateTime GetNow();
        public DateTime GetNowPlus10Days();
    }

    // Produktie Code voor de datum
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime GetNow()
        {
            return DateTime.Now;
        }

        public DateTime GetNowPlus10Days()
        {
            return DateTime.Now.AddDays(10);
        }

    }

    public class TestObject
    {
        public string? Name { get; set; }
        public string? Adress { get; set; }
        public DateTime GeboorteDatum { get; set; }

        public bool IsVandaagJarigNietTestBaarIvmTijdReizen()
        { 
            bool result = false;
            if (this.GeboorteDatum.Equals(DateTime.Now))    
                result = true;

            return result;
        }

        public bool IsVandaagJarig(IDateTimeProvider dateTimeProvider)
        {
            bool result = false;
            if (this.GeboorteDatum.Day == dateTimeProvider.GetNow().Day && this.GeboorteDatum.Month == dateTimeProvider.GetNow().Month)
                result = true;

            return result;
        }
        public bool IsOver10DagenJarig(IDateTimeProvider dateTimeProvider)
        {
            bool result = false;
            if (this.GeboorteDatum.Day == dateTimeProvider.GetNowPlus10Days().Day && this.GeboorteDatum.Month == dateTimeProvider.GetNowPlus10Days().Month)
                result = true;

            return result;
        }
    }
}
