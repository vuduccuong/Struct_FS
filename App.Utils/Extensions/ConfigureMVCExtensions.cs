using App.Base.MyAppModel;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Utils.Extensions
{
    public static class ConfigureMVCExtensions
    {
        private const string AppSettings = "AppSettings";
        private const string BaseSettings = "BaseSettings";
        private const string DBFPTShopName = "MyApp";

        /// <summary>
        /// Get Config in appsettings
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static T GetConfig<T>(this IConfiguration configuration) => configuration.GetSection(AppSettings).GetSection(typeof(T).Name).Get<T>();

        /// <summary>
        /// Add ConnectionString
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        private static void AddDBMyApp(this IServiceCollection services, IConfiguration configuration) => services.AddDbContext<MyAppContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString(DBFPTShopName)));

        /// <summary>
        /// Add Config
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void AddConfig<T>(this IServiceCollection services, IConfiguration configuration) where T : class => services.Configure<T>(configuration.GetSection(AppSettings).GetSection(typeof(T).Name));

        /// <summary>
        /// Add Base Config
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        private static void AddBaseConfig<T>(this IServiceCollection services, IConfiguration configuration) where T : class => services.Configure<T>(configuration.GetSection(BaseSettings).GetSection(typeof(T).Name));


        public static void AddConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDBMyApp(configuration);
        }

    }
}
