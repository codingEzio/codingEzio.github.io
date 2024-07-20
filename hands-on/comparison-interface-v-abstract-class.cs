using System;

// Define the interface
public interface IVehicle
{
    void Drive();
    void Stop();
}

// Define the abstract class
public abstract class Machine
{
    public string Name { get; set; }

    public abstract void Start(); // Abstract method

    public void Shutdown() // Concrete method
    {
        Console.WriteLine($"{Name} is shutting down.");
    }
}

// Define a class that implements the interface and inherits from the abstract class
public class Car : Machine, IVehicle
{
    public override void Start()
    {
        Console.WriteLine($"{Name} is starting.");
    }

    public void Drive()
    {
        Console.WriteLine($"{Name} is driving.");
    }

    public void Stop()
    {
        Console.WriteLine($"{Name} is stopping.");
    }
}

// Main script logic
Car myCar = new Car { Name = "Tesla" };

// Using methods from the abstract class
myCar.Start();    // Outputs: Tesla is starting.
myCar.Shutdown(); // Outputs: Tesla is shutting down.

// Using methods from the interface
myCar.Drive();    // Outputs: Tesla is driving.
myCar.Stop();     // Outputs: Tesla is stopping.