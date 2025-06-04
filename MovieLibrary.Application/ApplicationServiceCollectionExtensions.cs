using Microsoft.Extensions.DependencyInjection;
using MovieLibrary.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Application
{
    public static class ApplicationServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddSingleton<IMovieRepository, MovieRepository>();
            return services;
        }
    }
}
