using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstUnitTest.MockVersusStub
{
    internal class StubTijdReizen : IDateTimeProvider
    {
        private DateTime Date { get; }
        public StubTijdReizen(DateTime date)
        { 
            Date = date;
        }
        DateTime IDateTimeProvider.GetNow()
        {
            return Date;
        }

        DateTime IDateTimeProvider.GetNowPlus10Days()
        {
            return Date.AddDays(10);
        }
    }
}
