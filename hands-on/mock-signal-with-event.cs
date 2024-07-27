using System;
using System.Threading;

static void MyHandler(object sender, ConsoleCancelEventArgs args)
{
    Console.WriteLine("\n收到信号，准备退出...");

    // 阻止默认行为 (立即退出)
    args.Cancel = true;

    // 执行清理工作...
    Thread.Sleep(1500);
    Console.WriteLine("清理完成，再见！");

    // 退出
    Environment.Exit(0);
}

// signal-like handler registered here
Console.CancelKeyPress += MyHandler;  // Ctrl+C, Ctrl+\

Console.WriteLine($"开始工作，按 Ctrl+C 或 Ctrl + \\ 退出 (pid: {Process.GetCurrentProcess().Id})...");
while (true)
{
    Thread.Sleep(1000); // 模拟工作
}
