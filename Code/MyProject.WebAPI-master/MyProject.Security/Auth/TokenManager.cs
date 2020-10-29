using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.Security.Auth
{
    public class TokenManager : ITokenManager
    {
        private readonly IJwtAuthenticationManager jwtAuthenticationManager;

        public TokenManager(IJwtAuthenticationManager jwtAuthenticationManager)
        {
            this.jwtAuthenticationManager = jwtAuthenticationManager;
        }
        public string GetToken(string username, string password)
        {
            var token = jwtAuthenticationManager.Authenticate(username, password);
            return token;
        }
    }
}
