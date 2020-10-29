using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.Security.Auth
{
    public interface ITokenManager
    {
        string GetToken(string username, string password);
    }
}
