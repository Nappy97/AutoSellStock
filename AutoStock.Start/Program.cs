using AutoStock.Core.Client.KisHttpsMaker;

namespace AutoStock.Start;

public class Program
{
    static async Task Main(string[] args)
    {
        // await Send();
        await GetVolumes();
    }

    private static async Task Send()
    {
        var result = await KisSend.Instance.OnInitializedAsync();
        Console.WriteLine(result);
    }

    private static async Task GetVolumes()
    {
        var result = await KisSend.Instance.GetVolumes();
        Console.WriteLine(result);
    }
}