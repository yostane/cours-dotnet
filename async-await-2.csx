Task RunLoopAsync(int identifier)
{
    return Task.Run(() =>
    {
        for (int i = 0; i < 100; i++)
        {
            Console.WriteLine($"Task {identifier} {i}");
        }
    });
}

async Task RunTestAsync()
{
    int x = 30;
    await RunLoopAsync(30);
    Console.WriteLine(x);
}

var t = RunLoopAsync(1);
Task.WaitAll();

Task.WaitAll(RunTestAsync());

// équivalent à:
// Task task = RunLoopAsync();
// Task.WaitAll(task);

Task.WaitAll(RunLoopAsync(2), RunLoopAsync(3));

