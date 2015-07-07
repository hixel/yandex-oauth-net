namespace YandexOauth.Controllers
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Mvc;
    using Newtonsoft.Json;
    using Oauth.AppParams;
    using Oauth.Metadata;
    using ViewModels.YandexOauth;

    public class YandexOauthController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AuthCode(string code)
        {
            var authToken = GetAuthToken(code);
            if (string.IsNullOrEmpty(authToken))
            {
                return View(new YandexPassportViewModel
                {
                    Message = "User not found"
                });
            }

            var yandexPassport = AuthorizeToken(authToken);
            if (yandexPassport == null)
            {
                return View(new YandexPassportViewModel
                {
                    Message = "Error at request"
                });
            }

            var model = AutoMapper.Mapper.Map<YandexPassportViewModel>(yandexPassport);
            model.Success = true;

            return View(model);
        }

        private static string GetAuthToken(string code)
        {
            var data = string.Format("grant_type=authorization_code&code={0}&client_id={1}&client_secret={2}",
                code,
                YandexOauthParamContainer.ClientId,
                YandexOauthParamContainer.ClientSecret);

            var request = WebRequest.Create("https://oauth.yandex.ru/token");
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";

            try
            {
                using (var requestStream = request.GetRequestStream())
                {
                    var byteArr = Encoding.UTF8.GetBytes(data);
                    requestStream.Write(byteArr, 0, byteArr.Length);
                }

                var response = request.GetResponse();
                using (var stream = response.GetResponseStream())
                {
                    if (stream == null)
                    {
                        return string.Empty;
                    }
                    var reponseStatus = ((HttpWebResponse)response).StatusCode;

                    if (reponseStatus != HttpStatusCode.OK)
                    {
                        return string.Empty;
                    }

                    using (var reader = new StreamReader(stream))
                    {
                        var responseText = reader.ReadToEnd();

                        var yandexToken = JsonConvert.DeserializeObject<YandexToken>(responseText);

                        return yandexToken.AccessToken;
                    }
                }
            }
            catch 
            {
                return string.Empty;
            }
        }

        private YandexPassportInfo AuthorizeToken(string authToken)
        {
            var uriBuilder = new UriBuilder("https://login.yandex.ru/info");
            var parameters = HttpUtility.ParseQueryString(string.Empty);
            parameters["oauth_token"] = authToken;
            parameters["format"] = "json";
            parameters["with_openid_identity"] = "yes";
            uriBuilder.Query = parameters.ToString();

            var request = WebRequest.Create(uriBuilder.Uri);
            request.Method = "GET";

            try
            {
                var response = request.GetResponse();
                using (var stream = response.GetResponseStream())
                {
                    if (stream == null)
                    {
                        return null;
                    }
                    var reponseStatus = ((HttpWebResponse)response).StatusCode;

                    if (reponseStatus != HttpStatusCode.OK)
                    {
                        return null;
                    }

                    using (var reader = new StreamReader(stream))
                    {
                        var responseText = reader.ReadToEnd();

                        var yandexPassport = JsonConvert.DeserializeObject<YandexPassportInfo>(responseText);

                        return yandexPassport;
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}