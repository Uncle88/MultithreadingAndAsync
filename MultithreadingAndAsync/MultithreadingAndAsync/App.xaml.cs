using System;
using MultithreadingAndAsync.View;
using Xamarin.Forms;

namespace MultithreadingAndAsync
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new SomeViewPage();
        }
    }
}
