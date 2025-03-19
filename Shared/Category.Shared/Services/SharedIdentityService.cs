using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CategoryService.Shared.Services
{
    public class SharedIdentityService : ISharedIdentityService
    {
        private IHttpContextAccessor _contextAccessor;

        public SharedIdentityService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        //public string GetUserId => _contextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        public string? GetUserId
        {
            get
            {
                var user = _contextAccessor.HttpContext?.User;
                if (user == null)
                    return null;

                var subClaim = user.FindFirst("sub")?.Value;
                if (!string.IsNullOrEmpty(subClaim))
                    return subClaim;

                var nameIdClaim = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (!string.IsNullOrEmpty(nameIdClaim))
                    return nameIdClaim;

                return null;
            }
        }

    }
}
