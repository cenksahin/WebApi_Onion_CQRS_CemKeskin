using Microsoft.Extensions.DependencyInjection;
using YoutubeApi.Application.Interfaces.AutoMapper;
using YoutubeApi.Mapper.AutoMapper;


namespace YoutubeApi.Mapper
{
    public static class Registration
    {
        public static void AddCustomMapper(this IServiceCollection services)
        {
            services.AddSingleton<IMapperr, Mapperr>();
        }
    }
}
