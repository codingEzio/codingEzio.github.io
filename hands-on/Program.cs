// See https://aka.ms/new-console-template for more information

Dog myDog = new Dog();
myDog.MakeSound(); // Output: Generic animal sound, Bark!

public class Animal
{
    public void MakeSound()
    {
        Console.WriteLine("Generic animal sound");
    }
}

public class Dog : Animal
{
    public void Bark()
    {
        Console.WriteLine("Woof!");
    }

    public void MakeSound()
    {
        // Call the MakeSound method from the parent class
        base.MakeSound();
        Console.WriteLine("Bark!");
    }
}
