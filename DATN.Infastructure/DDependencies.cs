
using DATN.Infastructure.Repositories.AccountRepository;
using DATN.Infastructure.Repositories.BaseRepository;
using DATN.Infastructure.Repositories.BillRepository;
using DATN.Infastructure.Repositories.EmailReponsitory;
using DATN.Infastructure.Repositories.EntryVehiclesRepository;
using DATN.Infastructure.Repositories.ManagementRepository;
using DATN.Infastructure.Repositories.ParkingRepository;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DATN.Infastructure
{
    public static class DDependencies
    {
        public static void RegisterRepositories(this IServiceCollection services)
        {
			services.AddTransient(typeof(IRepository<>), typeof(Repository<>));

            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<IManagementRepository, ManagementRepository>();
            services.AddTransient<IParkingRepository, ParkingRepository>();
            services.AddTransient<IEntryVehiclesRepository, EntryVehiclesRepository>();
            services.AddTransient<IBillRepository, BillRepository>();
            services.AddTransient<IEmailService, EmailService>();



            //services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}
