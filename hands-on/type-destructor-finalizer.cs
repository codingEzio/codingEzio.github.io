class DestructorDemo
{
    public DestructorDemo() => Console.WriteLine("demo1 Constructed");
    ~DestructorDemo() => Console.WriteLine("demo1 Destructed");
}

var destructorDemo = new DestructorDemo();

// Output from the Finalizer is not guaranteed as it's implementation-specific (quote).