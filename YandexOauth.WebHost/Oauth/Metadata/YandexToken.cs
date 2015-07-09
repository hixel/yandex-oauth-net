namespace YandexOauth.WebHost.Oauth.Metadata
{
    using Newtonsoft.Json;

    /// <summary>
    /// Описывает токен Yandex.OAuth
    /// </summary>
    public class YandexToken
    {
        /// <summary>Идентификатор токена</summary>
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        /// <summary>Тип токена</summary>
        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        /// <summary>Время жизни в секундах</summary>
        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }
    }
}