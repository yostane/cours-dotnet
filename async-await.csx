// tache asynchrone -(en)-> async task
var task1 = Task.Run(() =>
{
    for (int i = 0; i < 100; i++)
    {
        Console.WriteLine($"Task 1 {i}");
    }
});


var task2 = Task.Run(() =>
{
    for (int i = 0; i < 300; i++)
    {
        Console.WriteLine($"Task 2 {i}");
    }
});


// J'attends la fin des deux tasks
Task.WaitAll(task1, task2);

// autre facon d'attendre task1 mais ça marche à la racine avec scriptcs
// await task1;
// autre facon d'attendre task2
// await task2;

Console.WriteLine("Fin");


