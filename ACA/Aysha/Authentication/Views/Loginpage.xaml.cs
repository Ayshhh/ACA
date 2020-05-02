using ACA.Aysha.Authentication.Interfaces;
using ACA.Aysha.Authentication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ACA.Aysha.Authentication.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Loginpage : ContentPage
    {
        public static IGoogleAuthenticator _googleManager = DependencyService.Get<IGoogleAuthenticator>();
        public GoogleUser GoogleUser { get; private set; }
        public bool IsLogedIn { get; private set; }
        public object MainLayout { get; private set; }
        public object LoadingLayout { get; private set; }

        public Loginpage()
        {
            InitializeComponent();
        }

        public async void Login(object sender, EventArgs e)
        {
            try
            {

                _googleManager.Logout();
                _googleManager.Login(OnLoginComplete);

            }
            catch (Exception x)
            {

                await DisplayAlert("Authentication Failed", "Your Authentication Attempt Failed. Please try again..", "Ok");
            }
        }
        private async void OnLoginComplete(GoogleUser googleUser, string message)
        {
            if (googleUser != null)
            {
                GoogleUser = googleUser;
                try
                {
                    AppUser User = await DependencyService.Get<IFireBaseAuthenticator>().LoginWithGoogle(googleUser.Token, null);
                    Application.Current.Properties["User"] = User.Uid;
                }
                catch (Exception e)
                {
                    await DisplayAlert("Oops", "Firebase Error", "Ok");
                }

                IsLogedIn = true;
                await DisplayAlert("Success", message, "Ok");
            }
            else
            {
                await DisplayAlert("Error", message, "Ok");
            }
        }

        
    }
}