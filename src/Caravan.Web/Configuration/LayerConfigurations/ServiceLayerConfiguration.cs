using Caravan.DataAccess.Interfaces.Common;
using Caravan.DataAccess.Repositories.Common;
using Caravan.Service.Common.Security;
using Caravan.Service.Interfaces;
using Caravan.Service.Interfaces.Common;
using Caravan.Service.Interfaces.Security;
using Caravan.Service.Services;
using Caravan.Service.Services.Common;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Caravan.Web.Configuration.LayerConfigurations
{
    public static class ServiceLayerConfiguration
    {
        public static void AddService(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAuthManager, AuthManager>();
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IPaginatorService, PaginatorService>();
            services.AddScoped<ITruckService, TruckService>();
            services.AddScoped<ILocationService, LocationService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddMemoryCache(); 
            services.AddHttpContextAccessor();
            services.AddAutoMapper(typeof(MappingConfiguration));
        }
    }
}
