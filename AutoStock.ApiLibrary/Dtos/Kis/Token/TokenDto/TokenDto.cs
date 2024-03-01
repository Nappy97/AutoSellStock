using AutoStock.Shared.Constant;

namespace AutoStock.ApiLibrary.Dtos.Kis.Token.TokenDto;

public class TokenDto
{
    public class TokenRequest
    {
        public string grant_type => "client_credentials";
        public string appkey => KisSecret.Appkey;

        public string appsecret => KisSecret.Secretkey;
    }

    public class TokenResponse
    {
        public string access_token { get; set; }

        public string token_type { get; set; }

        public int expires_in { get; set; }
        public string access_token_token_expired { get; set; }

        public string error_description { get; set; }
        public string error_code { get; set; }

        public TokenResponse()
        {
        }
    }
}