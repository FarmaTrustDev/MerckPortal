using Merck.DTOS.Auth;
using Merck.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System;
using Merck.Repositories;
using System.Linq;
using System.Collections.Generic;
using Merck.Helpers.JWT;
using Merck.Helpers.Auth;
using Merck.Infrastructure;
using Merck.Helpers.ExceptionHandling;
using Merck.Helpers.JWTM;

namespace Merck.Controllers
{
    public class AuthController : Controller
    {
        private readonly MyDbContext _context;
        private readonly AppConfiguration _appConfiguration;
        public AuthController(MyDbContext context, AppConfiguration appConfiguration)
        {
            _context = context;
            _appConfiguration= appConfiguration;
        }
        public IActionResult Home()
        {
            return View("Authenticate");
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Authenticate(AuthRequest request)
        {
            AuthResponse response = AuthenticateUser(request);
            return View(response);
        }

        private AuthResponse AuthenticateUser(AuthRequest request)
        {
            Expression<Func<User, bool>> expression = x => ((x.Email.ToLower() == Convert.ToString(request.Username).ToLower()) || x.UserName.ToLower() == Convert.ToString(request.Username).ToLower() && x.Active == true);

            User existingUser = _context.User.SingleOrDefault(expression);

            AuthResponse response = new AuthResponse();

            if (existingUser != null)
            {
                if (existingUser.Password == Utility.Encrypt(request.Password))
                {
                    IDictionary<string, object> payloadAccessToken = new Dictionary<string, object>
                    {
                        { AccessTokenKeys.Id, existingUser.Id.ToString() },
                        { AccessTokenKeys.Username, existingUser.UserName },
                        { AccessTokenKeys.Email, existingUser.Email }
                    };

                    IDictionary<string, object> payloadRefreshToken = new Dictionary<string, object>
                    {
                        { AccessTokenKeys.Id, existingUser.Id },
                        { AccessTokenKeys.Username, request.Username },
                        { AccessTokenKeys.Email, request.Email },
                        { AccessTokenKeys.Password, Encryption.Encrypt(request.Password) }
                    };

                    response.Success = true;
                    response.AccessToken = JwtManager.GenerateAccessToken(_appConfiguration.JwtSecretKey, payloadAccessToken);
                    response.RefreshToken = JwtManager.GenerateRefreshToken(_appConfiguration.JwtSecretKey, payloadRefreshToken);
                    response.Message = "Login Success!";
                }
                else
                {
                    throw new ApiException("Unauthorized user.", 401);
                }
            }
            else
            {
                throw new ApiException("Unauthorized user.", 401);
            }

            return response;

        }
    }
}
