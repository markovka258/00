using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace WorkCalendar.Data
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private readonly AuthService _authService;

        public CustomAuthStateProvider(AuthService authService)
        {
            _authService = authService;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            // Реализуйте логику получения состояния аутентификации
            var identity = new ClaimsIdentity();
            var user = new ClaimsPrincipal(identity);
            return new AuthenticationState(user);
        }
    }
}
