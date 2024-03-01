using System.Text.Json.Serialization;

namespace AutoStock.ApiLibrary.Dtos.Kis.Volume;

public class VolumeDto
{
    public class VolumeRequest
    {
        public string FID_COND_MRKT_DIV_CODE => "J";
        public string FID_COND_SCR_DIV_CODE => "20171";
        public string FID_INPUT_ISCD => "0000";
        public string FID_DIV_CLS_CODE => "1";
        
        // 0: 평균거래량, 1: 거래증가율, 2: 평균거래회전율, 3: 거래금액순, 4: 평균거래금액 회전율
        public string FID_BLNG_CLS_CODE => "1";
        // 1 or 0 9자리 (차례대로 증거금 30% 40% 50% 60% 100% 신용보증금 30% 40% 50% 60%)
        public string FID_TRGT_CLS_CODE => "111111111";
        // 1 or 0 6자리 (차례대로 투자위험/경고/주의 관리종목 정리매매 불성실공시 우선주 거래정지)
        public string FID_TRGT_EXLS_CLS_CODE => "000000";
        public string FID_INPUT_PRICE_1 { get; set; }
        public string FID_INPUT_PRICE_2 { get; set; }
        public string FID_VOL_CNT { get; set; }
        public string FID_INPUT_DATE_1 { get; set; }
    }

    public class VolumeResponse
    {
        public enum ResponseResult
        {
            알수없음,
            성공,
            거절,
            오류
        }

        [JsonPropertyName("rt_cd")]
        public string IsSuccess { get; set; }

        public ResponseResult GetResult()
        {
            if (int.TryParse(IsSuccess, out var resultCode))
                return resultCode switch
                {
                    0 => ResponseResult.성공,
                    _ => ResponseResult.거절
                };
            return ResponseResult.알수없음;
        }

        [JsonPropertyName("msg_cd")]
        public string ResponseCode { get; set; }

        [JsonPropertyName("msg1")]
        public string ResponseMessage { get; set; }

        [JsonPropertyName("output")]
        public StockInformation[] Stock { get; set; }

        public class StockInformation
        {
            [JsonPropertyName("hts_kor_isnm")]
            public string 한글종목명 { get; set; }

            [JsonPropertyName("mksc_shrn_iscd")]
            public string 유가증권_단축_종목코드 { get; set; }

            [JsonPropertyName("data_rank")]
            public string 데이터순위 { get; set; }

            [JsonPropertyName("stck_prpr")]
            public string 현재가격 { get; set; }

            [JsonPropertyName("prdy_vrss_sign")]
            public string 전일대비부호 { get; set; }

            [JsonPropertyName("prdy_ctrt")]
            public string 전일대비율 { get; set; }

            [JsonPropertyName("acml_vol")]
            public string 누적_거래량 { get; set; }

            [JsonPropertyName("prdy_vol")]
            public string 전일_거래량 { get; set; }

            [JsonPropertyName("lstn_stcn")]
            public string 상장주_개수 { get; set; }

            [JsonPropertyName("avrg_vol")]
            public string 평균_거래량 { get; set; }

            [JsonPropertyName("n_befr_clpr_vrss_prpr_rate")]
            public string N일전_종가대비_현재가_대비율 { get; set; }

            [JsonPropertyName("vol_inrt")]
            public string 거래량_증가율 { get; set; }

            [JsonPropertyName("vol_tnrt")]
            public string 거래량_회전율 { get; set; }

            [JsonPropertyName("nday_vol_tnrt")]
            public string N일거래량회전율 { get; set; }

            [JsonPropertyName("avrg_tr_pbmn")]
            public string 평균거래대금 { get; set; }

            [JsonPropertyName("tr_pbmn_tnrt")]
            public string 거래대금회전율 { get; set; }

            [JsonPropertyName("nday_tr_pbmn_tnrt")]
            public string N일_거래대금_회전율 { get; set; }

            [JsonPropertyName("acml_tr_pbmn")]
            public string 누적_거래_대금 { get; set; }
        }
    }
}