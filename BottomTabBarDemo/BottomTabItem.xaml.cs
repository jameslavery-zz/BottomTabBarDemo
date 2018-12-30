using System;
using System.Collections.Generic;
using System.Windows.Input;
using FreshMvvm;
using Xamarin.Forms;

namespace BottomTabBarDemo
{
    public partial class BottomTabItem : ContentView
    {
        // Retrieve the colours so that we're only doing this once, not when the item is selected/unselected
        private static Color SelectedItemBackgroundColor = (Color)Application.Current.Resources["ToolbarItemSelectedBackground"];
        private static Color UnselecteItemBackgroundcolor = (Color)Application.Current.Resources["ToolbarItemUnselectedBackground"];


        public BottomTabItem()
        {
            InitializeComponent();
        }

        #region Caption
        public static readonly BindableProperty CaptionProperty =
            BindableProperty.Create(propertyName: nameof(Caption),
                                    returnType: typeof(string),
                                    declaringType: typeof(BottomTabItem),
                                    defaultValue: "Home",
                                    defaultBindingMode: BindingMode.OneWay,
                                    propertyChanged: CaptionChanged);

        public string Caption
        {
            get; set;
        }

        private static void CaptionChanged(BindableObject bindable, object oldValue, object newValue)
        {
            BottomTabItem ThisControl = (BottomTabItem)bindable;
            string NewValue = (string)newValue;
            ThisControl.CaptionLabel.Text = NewValue;
        }
        #endregion Caption

        #region IconSource
        public static readonly BindableProperty IconSourceProperty =
            BindableProperty.Create(propertyName: nameof(IconSource),
                                    returnType: typeof(string),
                                    declaringType: typeof(BottomTabItem),
                                    defaultValue: "icon",
                                    defaultBindingMode: BindingMode.OneWay,
                                    propertyChanged: IconSourceChanged);

        public string IconSource
        {
            get; set;
        }

        private static void IconSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            BottomTabItem ThisControl = (BottomTabItem)bindable;
            string NewValue = (string)newValue;
            ThisControl.IconImage.Source = NewValue;
        }

        #endregion IconSource

        #region Selected
        public static readonly BindableProperty SelectedProperty =
            BindableProperty.Create(propertyName: nameof(Selected),
                            returnType: typeof(bool),
                            declaringType: typeof(BottomTabItem),
                            defaultValue: false,
                            defaultBindingMode: BindingMode.OneWay,
                            propertyChanged: SelectedChanged);


        public bool Selected
        {
            get; set;
        }

        private static void SelectedChanged(BindableObject bindable, object oldValue, object newValue)
        {
            BottomTabItem ThisControl = (BottomTabItem)bindable;
            bool NewValue = (bool)newValue;
            ThisControl.BackgroundColor = NewValue ? SelectedItemBackgroundColor : UnselecteItemBackgroundcolor;
        }
        #endregion Selected

        #region TapCommand
        public static readonly BindableProperty TapCommandProperty =
            BindableProperty.Create(propertyName: nameof(TapCommand),
                                    returnType: typeof(ICommand),
                                    declaringType: typeof(BottomTabItem),
                                    defaultValue: null,
                                    defaultBindingMode: BindingMode.OneWay,
                                    propertyChanged: TapCommandChanged);

        public ICommand TapCommand
        {
            get; set;
        }

        private static void TapCommandChanged(BindableObject bindable, object oldValue, object newValue)
        {
            BottomTabItem ThisControl = (BottomTabItem)bindable;
            ThisControl.TapCommand = (Command)newValue;
        }

        #endregion TapCommand

        #region Event Handlers

        private void Handle_Tapped(object sender, EventArgs args)
        {
            TapCommand?.Execute(this);
        }

        #endregion Event Handlers
    }
}