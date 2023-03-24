using Merck.DTOS;
using Merck.Migrations;
using Merck.Models;
using Merck.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Merck.Repositories
{
    public class AuthFilter : Attribute, IAuthorizationFilter
    {
        
        private readonly string[] _roles;
        private readonly string[] _permissions;
        public AuthFilter(string[] roles = null, string[] permissions = null)
        {
            _roles = roles;
            _permissions = permissions;
           
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var _db = context.HttpContext.RequestServices.GetService<MyDbContext>();

            var usrName = context.HttpContext.User.Identity.Name;
            
            List<RolePermissionDTO> user = _db.UserRoles
                .Where(usr => usr.User.UserName == usrName)
                .Include(role => role.Role)
                    .ThenInclude(perRole => perRole.PermissionRoles)
                        .ThenInclude(per => per.Permission).Select(rolPer=> new RolePermissionDTO()
                        {
                            RoleName=rolPer.Role.Name,
                            PermissionsName=rolPer.Role.PermissionRoles.Select(perRole=>perRole.Permission).Select(per=>per.Name).ToList(),
                        }).ToList();

            if (_roles != null && _roles.Length > 0)
            {
                if (!user.Any(uR=> _roles.Contains(uR.RoleName)))
                {
                    context.Result = new ForbidResult();
                    return;
                }

            }
            if (_permissions != null && _permissions.Length > 0)
            {
                if (!_permissions.All(p => user.Any(up => up.PermissionsName.Contains(p))))
                {
                    context.Result = new ForbidResult();
                    return;
                }
            }
        }
    }
}