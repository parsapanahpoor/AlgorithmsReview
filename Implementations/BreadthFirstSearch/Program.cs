using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

class Program
{
    static int step = 1;
    static Stopwatch sw = new Stopwatch();

    static void Main()
    {
        // تعریف گراف به صورت لیست مجاورت
        Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>
        {
            { "A", new List<string> { "B", "C" } },
            { "B", new List<string> { "D", "E" } },
            { "C", new List<string> { "F" } },
            { "D", new List<string>() },
            { "E", new List<string>() },
            { "F", new List<string>() }
        };

        BFS(graph, "A");
    }

    static void BFS(Dictionary<string, List<string>> graph, string start)
    {
        Queue<string> queue = new Queue<string>();
        HashSet<string> visited = new HashSet<string>();

        sw.Start();
        queue.Enqueue(start);
        visited.Add(start);

        while (queue.Count > 0)
        {
            string node = queue.Dequeue();

            Console.Clear();
            Console.WriteLine($"Step {step++}: Visiting node {node}");
            Console.WriteLine("Visited: " + string.Join(", ", visited));
            Console.WriteLine("Queue:   " + string.Join(", ", queue));
            Thread.Sleep(5000);

            foreach (string neighbor in graph[node])
            {
                if (!visited.Contains(neighbor))
                {
                    queue.Enqueue(neighbor);
                    visited.Add(neighbor);

                    Console.Clear();
                    Console.WriteLine($"Step {step++}: Enqueued neighbor {neighbor}");
                    Console.WriteLine("Visited: " + string.Join(", ", visited));
                    Console.WriteLine("Queue:   " + string.Join(", ", queue));
                    Thread.Sleep(5000);
                }
            }
        }

        sw.Stop();
        Console.Clear();
        Console.WriteLine("✅ BFS Traversal Completed");
        Console.WriteLine("Traversal Order: " + string.Join(" → ", visited));
        Console.WriteLine($"\nTotal Steps: {step - 1}");
        Console.WriteLine($"Execution Time: {sw.Elapsed.TotalSeconds:F3} seconds");
    }
}
