using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACA.Aysha.Authentication.Interfaces;
using ACA.Aysha.Authentication.Model;
using ACA.Aysha.Authentication.Views;
using ACA.Droid.Interfaces;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Auth;
using Xamarin.Forms;

[assembly: Dependency(typeof(FireBaseAuthenticator))]

namespace ACA.Droid.Interfaces
{
    public class FireBaseAuthenticator : IFireBaseAuthenticator
    {
        public async Task<AppUser> LoginWithGoogle(string IdTok, string accessTok)
        {
            var cred = GoogleAuthProvider.GetCredential(IdTok, accessTok);

            var user = await FirebaseAuth.Instance.SignInWithCredentialAsync(cred);

            if (user != null)
            {
                AppUser appUser = new AppUser()
                {
                    Email = user.User.Email,
                    Name = user.User.DisplayName,
                    Picture = user.User.PhotoUrl.ToString(),
                    Uid = user.User.Uid
                };
                return appUser;
            }
            else
                return null;
        }
    }
}