
using Merck.Filters;
using Merck.Interfaces.Repositories;
using Merck.Repositories;
using Merck.Seed;
using Merck.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Merck.Core;

namespace Merck.Infrastructure
{
    public class ServiceConfiguration
    {
        public static void Register(IServiceCollection services)
        {
            //Repositories
            services.AddScoped<ITreatmentEventRepository, TreatmentEventRepository>();
            services.AddScoped<IUserRepositories, UserRepositories>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IPermissionsRepository, PermissionRepository>();
            services.AddScoped<IPermissionRolesRepository, PermissionRolesRepository>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();
            services.AddScoped<ITokenRepository, TokenService>();
            services.AddScoped<IAuthorizationFilter, AuthFilter>();
            services.AddScoped<IFileLogRepository, FileLogRepository>();

            services.AddScoped<IDocumentRepository, DocumentRepository>();
            //Services
            services.AddScoped<TreatmentEventServices>();
            services.AddScoped<UserServices>();
            services.AddScoped<RoleServices>();
            services.AddScoped<PermissionServices>();
            services.AddScoped<PermissionRoleServices>();
            services.AddScoped<UserRoleServices>();
            services.AddScoped<AuthFilter>();
            services.AddScoped<BlobStorageService>();

        }
    }
}
