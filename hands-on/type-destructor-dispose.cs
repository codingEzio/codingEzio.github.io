using System;
using System.IO;

public class SimpleFileWriter : IDisposable
{
    private StreamWriter _streamWriter;

    public SimpleFileWriter(string filePath)
    {
        _streamWriter = new StreamWriter(filePath);
    }

    public void WriteLine(string message)
    {
        _streamWriter.WriteLine(message);
    }

    public void Dispose()
    {
        _streamWriter?.Dispose();
        Console.WriteLine("Resources cleaned up!");
    }
}

// Code below would write two lines of text to a file under ./resource/

using (var writer = new SimpleFileWriter("./resource/destructor-dispose-example.txt"))
{
    writer.WriteLine("Hello, World!");
    writer.WriteLine("Resource management in action!");
}

// Output: Resources cleaned up!

// Check ./resource/destructor-dispose-example.txt for written messages