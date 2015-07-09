namespace YandexOauth.WebHost
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using Dto;
    using WebGrease.Css.Extensions;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            InitializeDtoMap();
        }

        private static void InitializeDtoMap()
        {
            AppDomain
                .CurrentDomain
                .GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(x => Inherits(x, typeof(BaseDtoMap<,>)))
                .ForEach(x => Activator.CreateInstance(x));
        }

        private static bool Inherits(Type child, Type parent)
        {
            if (child == parent)
            {
                return false;
            }

            var currentChild = child.IsGenericType
                                   ? child.GetGenericTypeDefinition()
                                   : child;

            while (currentChild != typeof(object))
            {
                if (parent == currentChild)
                {
                    return true;
                }
                    
                currentChild = currentChild.BaseType != null
                               && currentChild.BaseType.IsGenericType
                                   ? currentChild.BaseType.GetGenericTypeDefinition()
                                   : currentChild.BaseType;

                if (currentChild == null)
                {
                    return false;
                }
            }

            return false;
        }
    }
}
