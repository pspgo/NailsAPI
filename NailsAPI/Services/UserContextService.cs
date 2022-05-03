using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NailsAPI.Services
{
    public interface IUserContextService
    {
        //abstrahujemy intefejs aby zarejestrowac w startup
        //by moc wstrzykiwac do konkretnej klasy
        //gdzie chcemy uzyc kontekstu uzytkownika
        ClaimsPrincipal User { get; }
        int? GetUserId { get; }
    }
    public class UserContextService : IUserContextService
    {
        //udostepnianie informacji o uzytkowniku na podstawie kontekstu HTTP
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserContextService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public ClaimsPrincipal User => _httpContextAccessor.HttpContext?.User;
        public int? GetUserId =>
            User is null ? null : (int?)int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value);
    }
}
