namespace AutoStock.Shared.Constant;

public class EndPoint
{
    public const string HostDomain = "https://openapi.koreainvestment.com:9443";
    public const string 접속키발급 = "/oauth2/tokenP";
    public const string 거래량순위 = "/uapi/domestic-stock/v1/quotations/volume-rank";
    public const string 주식현재가_시세 = "/uapi/domestic-stock/v1/quotations/inquire-price";
}