namespace YandexOauth.WebHost.Dto
{
    using AutoMapper;

    public class BaseDtoMap<TSource, TDestination>
        where TSource : new()
        where TDestination : new()
    {
        private readonly IMappingExpression<TSource, TDestination> _mappingExpression;

        public BaseDtoMap()
        {
            _mappingExpression = Mapper.CreateMap<TSource, TDestination>();
        }

        public IMappingExpression<TSource, TDestination> Map
        {
            get
            {
                return _mappingExpression;
            }
        }
    }
}