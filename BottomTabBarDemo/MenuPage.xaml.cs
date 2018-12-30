using System;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;

namespace BottomTabBarDemo
{
    public partial class MenuPage : PopupPage
    {
        public MenuPage()
        {
            InitializeComponent();

            // Associate the Page with its PageModel manually - this is normally done as part of FreshMvvm navigation, but we're not using
            // FreshMvvm to display the Menu.
            BindingContext = new MenuPageModel(this);

        }

        public void AboutTapped(object sender, EventArgs e)
        {
            // Get the PageModel
            var model = (MenuPageModel)this.BindingContext;

            // If it was obtained successfully, execute the About command.
            model?.AboutCommand.Execute(null);

            // Dismiss the Menu.
            Navigation.PopPopupAsync();
        }

    }
}
