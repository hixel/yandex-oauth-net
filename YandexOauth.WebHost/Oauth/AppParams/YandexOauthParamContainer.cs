namespace YandexOauth.WebHost.Oauth.AppParams
{
    public static class YandexOauthParamContainer
    {
        /// <summary>Идентификатор приложения.
        /// Найти можно как поле "ID" на странице настроек приложения https://oauth.yandex.ru/client/<your-app-id>
        /// </summary>
        public static readonly string ClientId = "f4fe8642bb5c43f9a82ad73d9c35ab74";

        /// <summary>Секретный ключ.
        /// Найти можно как поле "Пароль" на странице настроек приложения https://oauth.yandex.ru/client/<your-app-id>
        /// </summary>
        public static readonly string ClientSecret = "986473038c884980a44a71c1a33060ea";
    }
}