using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstUnitTest;
public class MyClass
{
    public string Name { get; set; }
    public string Adress { get; set; }
}

public record MyRecord(
    string Name,
    string Adress
    );

public record MyRecord2(
    string Name,
    string Adress
    );
