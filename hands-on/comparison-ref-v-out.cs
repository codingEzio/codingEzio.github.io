public class UnderstandingRefOut
{
    public void ModifyValue(int input, ref int refValue, out int outValue)
    {
        input = 99; // Original 'input' untouched outside
        refValue = 88; // Directly modifies 'originalRef'
        outValue = 77; // Must be assigned before exiting
    }

    public void UsageExample()
    {
        int originalValue = 10;
        int originalRef = 20;

        ModifyValue(originalValue, ref originalRef, out int originalOut);

        // Output: 10, 88, 77
        Console.WriteLine($"{originalValue}, {originalRef}, {originalOut}");
    }
}

var sample = new UnderstandingRefOut();
sample.UsageExample();