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

        DFS(graph, "A");
    }

    static void DFS(Dictionary<string, List<string>> graph, string start)
    {
        Stack<string> stack = new Stack<string>();
        HashSet<string> visited = new HashSet<string>();

        sw.Start();
        stack.Push(start);

        while (stack.Count > 0)
        {
            string node = stack.Pop();

            if (!visited.Contains(node))
            {
                visited.Add(node);

                Console.Clear();
                Console.WriteLine($"Step {step++}: Visiting node {node}");
                Console.WriteLine("Visited: " + string.Join(", ", visited));
                Console.WriteLine("Stack:   " + string.Join(", ", stack));
                Thread.Sleep(5000);

                // اضافه کردن همسایه‌ها به پشته (برعکس برای ترتیب مناسب)
                List<string> neighbors = graph[node];
                for (int i = neighbors.Count - 1; i >= 0; i--)
                {
                    string neighbor = neighbors[i];
                    if (!visited.Contains(neighbor))
                    {
                        stack.Push(neighbor);

                        Console.Clear();
                        Console.WriteLine($"Step {step++}: Pushed neighbor {neighbor} to stack");
                        Console.WriteLine("Visited: " + string.Join(", ", visited));
                        Console.WriteLine("Stack:   " + string.Join(", ", stack));
                        Thread.Sleep(5000);
                    }
                }
            }
        }

        sw.Stop();
        Console.Clear();
        Console.WriteLine("✅ DFS Traversal Completed");
        Console.WriteLine("Traversal Order: " + string.Join(" → ", visited));
        Console.WriteLine($"\nTotal Steps: {step - 1}");
        Console.WriteLine($"Execution Time: {sw.Elapsed.TotalSeconds:F3} seconds");
    }
}
