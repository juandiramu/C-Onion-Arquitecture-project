using Dealership_Application_.Services;
using Dealership_Application_.Services.impl;
using Dealership_Domain.Repository;
using Dealership_Infrastructure;
using Microsoft.AspNetCore.DataProtection.KeyManagement;

namespace Api._DI
{
    public static class InjectExtension
{
        public static void Inject(this WebApplicationBuilder webApplicationBuilder)
        {
            webApplicationBuilder.Services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
            webApplicationBuilder.Services.AddScoped<ICreateCarService, CreateCar > ();
            webApplicationBuilder.Services.AddScoped<IEditCarService, EditCarService>();
        }
        }
}
