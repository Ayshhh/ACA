using ACA.Aysha.Authentication.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACA.Aysha.Authentication.Interfaces
{
    public interface IGoogleAuthenticator
    {
        void Login(Action<GoogleUser, string> OnLoginComplete);
        void Logout();
    }
}
