namespace YandexOauth.WebHost.Dto
{
    using System.Linq;
    using Oauth.Metadata;
    using ViewModels.YandexOauth;

    public class YandexPassportDtoMap : BaseDtoMap<YandexPassportInfo, YandexPassportViewModel>
    {
        public YandexPassportDtoMap()
        {
            Map
                .ForMember(x => x.Email, y => y.MapFrom(x => x.DefaultEmail))
                .ForMember(x => x.OpenIdList, y => y.MapFrom(x => x.OpenIdIdentities.ToList()));
        }
    }
}