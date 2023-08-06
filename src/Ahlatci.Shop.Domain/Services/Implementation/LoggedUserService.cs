using Ahlatci.Shop.Domain.Entites;
using Ahlatci.Shop.Domain.Service.Abstract;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Ahlatci.Shop.Domain.Service.Implementation
{
	public class LoggedUserService : ILoggedUserService
	{
		private readonly IHttpContextAccessor _httpContextAccessor;

		public LoggedUserService(IHttpContextAccessor httpContextAccessor)
		{
			_httpContextAccessor = httpContextAccessor;
		}

		public int? UserId => GetClaim(ClaimTypes.Sid)!=null ? int.Parse(GetClaim(ClaimTypes.Sid)): null;

		public Roles? Role => GetClaim(ClaimTypes.Role) != null ? (Roles)Enum.Parse(typeof(Roles), GetClaim(ClaimTypes.Role)) : null;

		public string UserName => GetClaim(ClaimTypes.Name) != null ? GetClaim(ClaimTypes.Name):null;

		public string Email => GetClaim(ClaimTypes.Email) != null ? GetClaim(ClaimTypes.Email) : null;

		private string GetClaim(string claimType)
		{
			return _httpContextAccessor?.HttpContext?.User.Claims.FirstOrDefault(x => x.Type == claimType)?.Value;
		}
	}
}
