using System;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms;

namespace BottomTabBarDemo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void MenuTapped(object sender, EventArgs e)
        {
            await Navigation.PushPopupAsync(new MenuPage());
        }

    }
}
