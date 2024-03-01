#region usings
using System.Reflection;

#endregion

namespace AutoStock.Tool;

internal static class Program
{
    private static void Main(string[] args)
    {
        var tools = CreateToolInstances();
        for (var i = 0; i < tools.Count; i++)
            Console.WriteLine($"{i + 1}. {tools[i].GetType().Name} : {tools[i].Description()}");

        Console.WriteLine($"Which one? (1 - {tools.Count})");

        try
        {
            var input = int.Parse(Console.ReadLine());
            tools[input - 1].Run();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }

    private static List<ITool> CreateToolInstances()
    {
        List<ITool> instances = new();
        var assembly = Assembly.GetExecutingAssembly();
        var types = assembly.GetTypes().AsEnumerable();
        foreach (var type in types)
        {
            if (type == typeof(ITool))
                continue;

            if (typeof(ITool).IsAssignableFrom(type) is false)
                continue;

            var instance = Activator.CreateInstance(type) as ITool;
            if (instance != null)
                instances.Add(instance);
        }

        return instances;
    }
}