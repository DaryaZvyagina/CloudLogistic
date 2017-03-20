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
    public class RegisterViewModel
    {
        public string EMail { get; set; }
        public string Password { get; set; }
        public string One { get; set; }
        public string Two { get; set; }
        public string Three { get; set; }
        public ICommand ProfileCommand { get; set; }

        private Page _page;

        public RegisterViewModel(Page page)
        {
            _page = page;
            ProfileCommand = new Command(OpenProfile);
        }

        private async void OpenProfile()
        {
            await _page.Navigation.PushAsync(new ProfilePage());
        }
    }
}
