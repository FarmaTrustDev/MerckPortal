using Merck.Helpers.JWTM;
using Merck.Infrastructure;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.DependencyInjection;
using Merck.Helpers.ExceptionHandling;

namespace Merck.Filters
{
	public class AuthManager : ActionFilterAttribute
	{
		public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
		{
			IServiceProvider serviceProvider = ServiceProviderResolver.ServiceProvider;
			AppConfiguration appConfiguration = serviceProvider.GetService<AppConfiguration>();
			ITokenProvider tokenProvider = serviceProvider.GetService<ITokenProvider>();
			bool isValid = false;
			string accessToken = tokenProvider.GetAccessToken();
			string secretKey = appConfiguration.JwtSecretKey;

			if (!string.IsNullOrEmpty(accessToken))
			{
				isValid = JwtManager.IsValidToken(accessToken, secretKey, true);
			}

			if (!isValid)
			{
				throw new AuthException("Unauthorized user.");
			}

			await next();
		}

	}
}
