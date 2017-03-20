using CloudLogistics.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CloudLogistics.ViewModels
{
    public class LoginViewModel
    {
        public string EMail { get; set; }
        public string Password { get; set; }
        public ICommand LoginCommand { get; set; }
        public ICommand RegisterCommand { get; set; }

        private Page _page;

        public LoginViewModel(Page page)
        {
            _page = page;
            RegisterCommand = new Command(OpenRegister);
        }

        private void OpenRegister()
        {
            var app = (App)Application.Current;
            app.MainPage = new NavigationPage(new RegisterPage());

            //await _page.Navigation.PushAsync(new RegisterPage());
        }
    }
}
