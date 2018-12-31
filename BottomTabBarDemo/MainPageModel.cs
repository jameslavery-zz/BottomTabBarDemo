using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Rg.Plugins.Popup.Extensions;
using FreshMvvm;
using Xamarin.Forms;

namespace BottomTabBarDemo
{
    internal class MainPageModel : FreshBasePageModel
    {

        // Constructor
        public MainPageModel()
        {
            Title = "Main Page";
            LeadsSelected = true;
        }

        #region Bound Properties


        public string Title { get; set; }
        public bool LeadsSelected { get; set; }
        public bool AccountsSelected { get; set; }
        public bool ContactsSelected { get; set; }

        #endregion Bound Properties

        #region Commands

        private ICommand _LeadsCommand;
        public ICommand LeadsCommand
        {
            get
            {
                if (_LeadsCommand == null)
                {
                    _LeadsCommand = new Command(() => this.SelectTab("leads"));
                }
                return _LeadsCommand;
            }
        }

        private ICommand _ContactsCommand;
        public ICommand ContactsCommand
        {
            get
            {
                if (_ContactsCommand == null)
                {
                    _ContactsCommand = new Command(() => this.SelectTab("Contacts"));
                }
                return _ContactsCommand;
            }
        }

        private ICommand _AccountsCommand;
        public ICommand AccountsCommand
        {
            get
            {
                if (_AccountsCommand == null)
                {
                    _AccountsCommand = new Command(() => this.SelectTab("Accounts"));
                }
                return _AccountsCommand;
            }
        }


        private ICommand _MenuCommand;
        public ICommand MenuCommand
        {
            get
            {
                if (_MenuCommand == null)
                {
                    _MenuCommand = new Command(async () => await this.ShowMenu());
                }
                return _MenuCommand;
            }
        }

        #endregion Commands

        #region Private Methods

        private async Task ShowMenu()
        {
            await Application.Current.MainPage.Navigation.PushPopupAsync(new MenuPage());
        }

        private void SelectTab(string tabName)
        {
            string lowercaseName = tabName.ToLower();

            LeadsSelected = lowercaseName == "leads";
            ContactsSelected = lowercaseName == "contacts";
            AccountsSelected = lowercaseName == "accounts";

        }

        #endregion Private Methods
    }
}