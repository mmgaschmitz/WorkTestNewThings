using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstUnitTest.MockVersusStub
{
    public class Mocks
    {
        public static TestObject GetMock1()
        {
            TestObject testMock = new()
            {
                Adress = "Mijn Adres",
                Name = "Maurice",
                GeboorteDatum = new DateTime(1970, 11, 30)
            };
            return testMock;
        }
    }
}
