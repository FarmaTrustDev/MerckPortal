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
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Merck.Interfaces.Repositories;
using Merck.Services;
using Newtonsoft.Json;

namespace Merck.Controllers
{
    public class AuthController : Controller
    {
        private readonly MyDbContext _context;
        private readonly AppConfiguration _appConfiguration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _config;
        private readonly ITokenRepository _tokenService;
        private readonly IUserRepositories _userRepository;
        private string generatedToken = null;
        public AuthController(IConfiguration config, ITokenRepository tokenService, IUserRepositories userRepository,MyDbContext context, AppConfiguration appConfiguration, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _appConfiguration= appConfiguration;
            _httpContextAccessor = httpContextAccessor;
            _config = config;
            _tokenService = tokenService;
            _userRepository = userRepository;
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
            if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
            {
                ViewBag.Error = "Incorrect Username or Password";
                return View("Index");
            }
            IActionResult response = Unauthorized();
            User validUser = GetUser(request);
            if (validUser != null)
            {
                var UserInfo= _userRepository.GetRolesByUserId(validUser.UserName);
                ViewBag.Users = UserInfo;
                generatedToken = _tokenService.BuildToken(_config["AppConfiguration:Key"].ToString(), _config["AppConfiguration:Issuer"].ToString(), _config["AppConfiguration:Audience"].ToString(), validUser);
                if (generatedToken != null)
                {
                    HttpContext.Session.SetString("Token", generatedToken);
                    var roles = UserInfo.Roles.Select(rol => rol.Name).ToList();
                    string rolesJson = JsonConvert.SerializeObject(roles);
                    HttpContext.Session.SetString("roles", rolesJson);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Error = "Incorrect Username or Password";
                    return View("Index");
                }
            }
            else
            {
                ViewBag.Error = "Incorrect Username or Password";
                return View("Index");
            }
        }
        private User GetUser(AuthRequest userModel)
        {
            // Write your code here to authenticate the user     
            return _userRepository.GetUser(userModel);
        }
        private AuthResponse AuthenticateUser(AuthRequest request)
        {
            Expression<Func<User, bool>> expression = x => ((x.Email.ToLower() == Convert.ToString(request.Username).ToLower()) || x.UserName.ToLower() == Convert.ToString(request.Username).ToLower() && x.Active == true);

            User existingUser = _context.User.SingleOrDefault(expression);

            AuthResponse response = new AuthResponse();

            if (existingUser != null)
            {
                if (existingUser.Password == Merck.Helpers.Auth.Utility.Encrypt(request.Password))
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
