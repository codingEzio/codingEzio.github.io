using System;
using System.Threading.Tasks;

// Define a delegate type
public delegate void SimpleDelegate(string message);

// Method definitions with same signature (which is a must)
static void Method1(string message) => Console.WriteLine($"Method1: {message}");
static void Method2(string message) => Console.WriteLine($"Method2: {message}");
static void Method3(string message) => Console.WriteLine($"Method3: {message}");


// 1. Creating and Assigning Delegates 🎬
SimpleDelegate del1 = Method1;
SimpleDelegate del2 = Method2;

// 2. Combining Delegates ➕
SimpleDelegate multiDel = del1 + del2;

// 3. Invoking Multicast Delegate 🚀
multiDel("Hey, Simple Delegate!");

// 4. Adding Methods to Existing Delegate ➕
multiDel += Method3;

// 5. Removing Methods from Delegate ➖
multiDel -= Method1;

// 6. Clearing All Invocations 🧹
multiDel = null;

// 7. Checking for null before invoking 🔍
multiDel?.Invoke("Safe invocation");

// 8. Getting Invocation List 📋
Delegate[] invocationList = multiDel?.GetInvocationList() ?? Array.Empty<Delegate>();

// 9. Async Invocation using Task<> 🔄
static void AsyncMethod(string message) => Console.WriteLine($"Async: {message}");
static void AsyncMethodWrapper(string message)
{
    Task.Run(() => AsyncMethod(message));
}

SimpleDelegate asyncDel = AsyncMethodWrapper;
asyncDel("Async call");

// 10. Using Action and Func (built-in delegate types) 🛠️
Action<string> action = Method1;
action += Method2;
action("Using Action");

static int Square(int x) => x * x;
Func<int, int> func = Square;
Console.WriteLine($"Square of 5: {func(5)}");
