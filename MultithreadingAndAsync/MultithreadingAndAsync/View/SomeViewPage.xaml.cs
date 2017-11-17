using MultithreadingAndAsync.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MultithreadingAndAsync.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SomeViewPage : ContentPage
    {
        public SomeViewPage()
        {
            InitializeComponent();
            BindingContext = new SomeViewModel();
        }
    }
}
