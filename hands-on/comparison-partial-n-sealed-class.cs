
// Partial class allow classes be written in seperate places, even files
// Partial class's implementations were merged at compile time

public partial class PartialClass
{
    public void A()
    {
        Console.WriteLine("AAA");
    }
}

public partial class PartialClass
{
    public void B()
    {
        Console.WriteLine("BBB");
    }
}

var myPartialClass = new PartialClass();
myPartialClass.A();
myPartialClass.B();


// ----------------------------------------------


public sealed class SealedClass
{
    public void C()
    {
        Console.WriteLine("CCC");
    }
}

SealedClass mySealedClass = new SealedClass();
mySealedClass.C();


// Yes, the only reason why Sealed Class exists is to prevent inheritance
// Code below would throw an error telling you can't inherit from it

// public class InheritedClass : SealedClass
// {
//     public void D()
//     {
//         Console.WriteLine("DDD");
//     }
// }