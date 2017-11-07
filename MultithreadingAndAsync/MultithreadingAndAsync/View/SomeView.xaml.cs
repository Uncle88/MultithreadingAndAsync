using System;
using System.Collections.Generic;
using MultithreadingAndAsync.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MultithreadingAndAsync.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SomeView : ContentPage
    {
        public SomeView()
        {
            InitializeComponent();
            BindingContext = new SomeViewModel();
        }
    }
}
