class DestructorDemo
{
    public DestructorDemo() => Console.WriteLine("demo1 Constructed");
    ~DestructorDemo() => Console.WriteLine("demo1 Destructed");
}

var destructorDemo = new DestructorDemo();
GC.Collect();
GC.WaitForPendingFinalizers();
Console.WriteLine("Whole script ended.");
