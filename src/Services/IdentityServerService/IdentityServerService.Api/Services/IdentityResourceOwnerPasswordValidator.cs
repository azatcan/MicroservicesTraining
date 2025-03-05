using Duende.IdentityServer.Validation;
using IdentityModel;
using IdentityServerService.Api.Models;
using Microsoft.AspNetCore.Identity;

namespace IdentityServerService.Api.Services
{
    public class IdentityResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public IdentityResourceOwnerPasswordValidator(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var existUser = await _userManager.FindByEmailAsync(context.UserName);
            if (existUser == null) 
            {
                var errors = new Dictionary<string, object>();
                errors.Add("errors", new List<string> { "Email veya şifre yanlış" });
                context.Result.CustomResponse = errors;
                return;
            }

            var password = await _userManager.CheckPasswordAsync(existUser,context.Password);
            if (password == false)
            {
                var errors = new Dictionary<string, object>();
                errors.Add("errors", new List<string> { "Email veya şifre yanlış" });
                context.Result.CustomResponse = errors;
                return;
            }

            context.Result = new GrantValidationResult(existUser.Id.ToString(), OidcConstants.AuthenticationMethods.Password);
        }
    }
}
