namespace YandexOauth.WebHost.Oauth.Metadata
{
    using Newtonsoft.Json;

    /// <summary>
    /// Данные клиента в Яндекс.Паспорт
    /// </summary>
    public class YandexPassportInfo
    {
        /// <summary>Идентификатор</summary>
        [JsonProperty("id")]
        public long Id { get; set; }

        /// <summary>Логин</summary>
        [JsonProperty("login")]
        public string Login { get; set; }

        /// <summary>Пол</summary>
        [JsonProperty("sex")]
        public string Sex { get; set; }

        /// <summary>Имя</summary>
        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        /// <summary>Фамилия</summary>
        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("Отображаемое имя")]
        public string DisplayName { get; set; }

        /// <summary>Реальное имя</summary>
        [JsonProperty("real_name")]
        public string RealName { get; set; }

        /// <summary>Список доступных электронных адресов</summary>
        [JsonProperty("emails")]
        public string[] Emails { get; set; }

        /// <summary>Список доступных идентификаторо OpenId</summary>
        [JsonProperty("openid_identities")]
        public string[] OpenIdIdentities { get; set; }

        /// <summary>Электронный адрес по-умолчанию</summary>
        [JsonProperty("default_email")]
        public string DefaultEmail { get; set; }
    }
}