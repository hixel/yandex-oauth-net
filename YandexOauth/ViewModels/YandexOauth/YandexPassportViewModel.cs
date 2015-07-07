namespace YandexOauth.ViewModels.YandexOauth
{
    using System.Collections.Generic;

    public class YandexPassportViewModel
    {
        public string Login { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Sex { get; set; }

        public IList<string> OpenIdList { get; set; }

        public string Message { get; set; }

        public bool Success { get; set; }

        public YandexPassportViewModel()
        {
            Success = false;
        }
    }
}