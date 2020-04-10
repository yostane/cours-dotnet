Task RunLoopAsync()
{
    return Task.Run(() =>
    {
        for (int i = 0; i < 100; i++)
        {
            Console.WriteLine($"Task 1 {i}");
        }
    });
}

await RunLoopAsync();

// équivalent à:
// Task task = RunLoopAsync();
// Task.WaitAll(task);

