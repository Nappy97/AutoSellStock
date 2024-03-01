using System.Net.Http.Headers;
using System.Text;

namespace AutoStock.ApiLibrary.Utilities;

internal interface IRestClientFactory
{
    HttpClient Create();

    Task<HttpResponseMessage> PostAsJsonString(string url, string jsonString,
        Func<HttpRequestHeaders, Task> headerAsyncHandler = null);
}

internal class RestClientFactory(IHttpClientFactory httpClientFactory) : IRestClientFactory
{
    private const string MediaType = "application/json";

    private IHttpClientFactory _httpClientFactory = httpClientFactory;

    public HttpClient Create()
    {
        var client = _httpClientFactory.CreateClient(Constants.HttpClientName);
        client.DefaultRequestHeaders.Clear();
        client.DefaultRequestHeaders.UserAgent.ParseAdd(Constants.UserAgent);
        return client;
    }

    public async Task<HttpResponseMessage> PostAsJsonString(string url, string jsonString,
        Func<HttpRequestHeaders, Task> headerAsyncHandler = null)
    {
        var client = Create();

        if (headerAsyncHandler is not null)
            await headerAsyncHandler(client.DefaultRequestHeaders);

        var jsonContent = new StringContent(jsonString, Encoding.UTF8, MediaType);
        return await client.PostAsync(url, jsonContent);
    }
}