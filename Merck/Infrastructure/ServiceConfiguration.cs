using Merck.Interfaces.Repositories;
using Merck.Repositories;
using Merck.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Merck.Infrastructure
{
    public class ServiceConfiguration
    {
        public static void Register(IServiceCollection services)
        {
            //Repositories
            services.AddScoped<ITreatmentEventRepository, TreatmentEventRepository>();
            //Services
            services.AddScoped<TreatmentEventServices>();
        }
    }
}
