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
            Lightl.TranslationY = -60;
            Lightr.TranslationY = -30;
            Clock.TranslationY = -30;
            Logintext.TranslationY = -20;
            Box.TranslationY = -20;
            Loginbutton.TranslationY = -20;
            Forgot.TranslationY = -20;
            

            Lightl.Opacity = 0;
            Lightr.Opacity = 0;
            Clock.Opacity = 0;
            Logintext.Opacity = 0;
            Box.Opacity = 0;
            Loginbutton.Opacity = 0;
            Forgot.Opacity = 0;

            Lightl.FadeTo(1, 300);
            await Lightl.TranslateTo(0, 0, 300);

            
            Lightr.FadeTo(1, 300);
            await Lightr.TranslateTo(0, 0, 300);

            
            Clock.FadeTo(1, 300);
            await Clock.TranslateTo(0, 0, 300);

            
            Logintext.FadeTo(1, 300);
            await Logintext.TranslateTo(0, 0, 300);

            
            Box.FadeTo(1, 300);
            await Box.TranslateTo(0, 0, 300);

            
            Loginbutton.FadeTo(1, 300);
            await Loginbutton.TranslateTo(0, 0, 300);

            
            Forgot.FadeTo(1, 300);
            await Forgot.TranslateTo(0, 0, 300);
            

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