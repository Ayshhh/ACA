using ACA.Aysha.Authentication.Model;
using System.Threading.Tasks;

namespace ACA.Aysha.Authentication.Views
{
    internal interface IFireBaseAuthenticator
    {
        Task<AppUser> LoginWithGoogle(object token, object p);
    }
}