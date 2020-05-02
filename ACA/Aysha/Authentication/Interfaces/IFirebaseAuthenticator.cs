using ACA.Aysha.Authentication.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ACA.Aysha.Authentication.Interfaces
{
    public interface IFirebaseAuthenticator
    {
        Task<AppUser> LoginWithGoogle(string idTok, string accesTok);

    }
}
