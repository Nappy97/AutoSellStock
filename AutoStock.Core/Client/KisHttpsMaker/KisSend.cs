using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net.Mime;
using System.Web;
using AutoStock.ApiLibrary.Dtos.Kis.Token.TokenDto;
using AutoStock.ApiLibrary.Dtos.Kis.Volume;
using AutoStock.Shared.Constant;
using AutoStock.Shared.Extension;

namespace AutoStock.Core.Client.KisHttpsMaker;

public class KisSend
{
    #region singleton

    private static readonly Lazy<KisSend> _instance = new(() => new KisSend());

    public static KisSend Instance => _instance.Value;

    private KisSend()
    {
    }

    #endregion

    #region init

    public async Task<(string, string)> OnInitializedAsync()
    {
        var response =
            await SendAsync<TokenDto.TokenRequest, TokenDto.TokenResponse>(new TokenDto.TokenRequest(), EndPoint.접속키발급,
                false, true);
        return (response.access_token, response.access_token_token_expired);
    }

    #endregion


    # region Http

    private async Task<TR> SendAsync<T, TR>(T data, string requestUrl, bool hasHeader, bool isPost)
        where TR : class, new() where T : class
    {
        using var client = CreateConfiguredClient(hasHeader);
        var response = isPost switch
        {
            true => await client.PostAsJsonAsync(requestUrl, data),
            false => await client.GetAsync($"{requestUrl}{data.ToQueryParameter()}")
        };
        return await response.Content.ReadFromJsonAsync<TR>();
    }

    #endregion

    #region HttpsHeader

    private HttpClient CreateConfiguredClient(bool hasHeader)
    {
        var client = new HttpClient
        {
            BaseAddress = new Uri(EndPoint.HostDomain)
        };
        client.DefaultRequestHeaders
            .Accept
            .Add(new MediaTypeWithQualityHeaderValue(MediaTypeNames.Application.Json));
        if (hasHeader)
        {
            AddHeaders(client);
        }

        return client;
    }

    private void AddHeaders(HttpClient client)
    {
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", KisSecret.Token);
        client.DefaultRequestHeaders.Add("appkey", KisSecret.Appkey);
        client.DefaultRequestHeaders.Add("appsecret", KisSecret.Secretkey);
        client.DefaultRequestHeaders.Add("tr_id", "FHPST01710000");
        client.DefaultRequestHeaders.Add("custtype", "P");
    }

    #endregion

    #region 거래량 가져오기

    public async Task<string> GetVolumes()
    {
        var data = new VolumeDto.VolumeRequest
        {
            FID_INPUT_PRICE_1 = "0",
            FID_INPUT_PRICE_2 = "",
            FID_VOL_CNT = "",
            FID_INPUT_DATE_1 = "2024"
        };
        var response =
            await SendAsync<VolumeDto.VolumeRequest, VolumeDto.VolumeResponse>(data, EndPoint.거래량순위, true, false);
        return response.ResponseCode;
    }

    #endregion
}