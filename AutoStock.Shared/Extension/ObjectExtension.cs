namespace AutoStock.Shared.Extension;

public static class ObjectExtension
{
    public static string ToQueryParameter<T>(this T data) where T : class
    {
        var properties = typeof(T).GetProperties();
        var queryParameter = properties.Select(p => $"{p.Name}={p.GetValue(data)}");
        return "?" + string.Join("&", queryParameter);
    }
}