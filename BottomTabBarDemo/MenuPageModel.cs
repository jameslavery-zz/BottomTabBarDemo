using System;
using System.Windows.Input;
using FreshMvvm;
using Xamarin.Forms;

namespace BottomTabBarDemo
{
    public class MenuPageModel: FreshBasePageModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:BottomTabBarDemo.MenuPageModel"/> class.
        /// </summary>
        /// <param name="currentPage">The page with which the PageModel should be linked</param>
        /// <remarks>
        /// Because we're not navigating to this page via the normal FreshMvvm navigation, we need to
        /// create a CoreMethods instance manually.
        /// </remarks>
        public MenuPageModel(Page currentPage)
        {
            CoreMethods = new PageModelCoreMethods(currentPage, this);
        }

        private ICommand _AboutCommand;

        /// <summary>
        /// The command to execute when the About menu item is tapped.
        /// </summary>
        /// <value>The about command.</value>
        public ICommand AboutCommand
        {
            get
            {
                if (_AboutCommand == null)
                {
                    _AboutCommand = new Command(() => this.About());
                }
                return _AboutCommand;
            }
        }

        // The actual code run when the About menu item is tapped.
        private void About()
        {
            CoreMethods.PushPageModel<AboutPageModel>();
        }
    }
}
