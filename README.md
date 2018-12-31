# BottomTabBarDemo
## Overview
This is a demonstration project to show how we can create a bottom navigation bar and a burger menu in a Xamarin.Forms application.

**Important note** This is my approach to the problem. Bear in mind that *there is always more than one way to do it*.

## Tools And Libraries Used

* FreshMvvm - for a quick and easy MVVM implementation.
  * PropertyChanged.Fody - used by FreshMvvm
* Rg.Plugins.Popup - for the sliding menu

## Displaying The Bottom Tab Bar
This is built up from the following components.

### BottomTabItem
This is a custom ContentView with:

* Caption
* Icon
* Different background colour depending on whether it is selected or not
* A gesture recogniser for tapping it

The above are bindable - a notable binding is that the tap can be bound to a Command in the PageModel.

### BottomTabControl

This is a simple XAML-styled control, which just lays out a set of _BottomTabItems_ and sets up their bindings.

## Changing The UI When Tabs Are Tapped

I've used a simple XAML layout for my MainPage, with _StackLayouts_ whose _IsVisible_ properties are bound to ViewModel _Selected_ properties which were bound to the _BottomTabItem_.

_Note_ That we could have sub-views etc. which are defined in separate files, but here I'm keeping it simple.

## Menu Handling

### Displaying The Menu Icon

This is easily done using the Xamarin.Forms _NavigationPage.TitleView_.

### Displaying The Menu

I've used Rg.Plugins.Popup to display the menu.

The advantage of this is that the MenuPage is just another page with its own PageModel under MVVM - so we can still use MVVM principals to drive it.

One slight disadvantage of Rg.Plugins.Popup is that the PageModel-Page binding isn't set up automatically under FreshMvvm, so we have to get a reference to the PageModel from the XAML code behind, in order to execute the associated Command.

