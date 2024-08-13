using SvaraKalkulators.Checklist.Bootstrap;
using SvaraKalkulators.Checklist.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SvaraKalkulators.Checklist.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainView : ContentPage
    {
        MainViewModel mainViewModel;
        public MainView()
        {
            InitializeComponent();
            OnAppearing();
        }

        protected override void OnAppearing()
        {
            AppContainer.Resolve<MainViewModel>();

            Task.Delay(10);

            barcodeInput.Focus();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Task.Delay(50);
            barcodeInput.Focus();
        }

        private void Label_Focused(object sender, FocusEventArgs e)
        {
            Task.Delay(50);
            barcodeInput.Focus();
        }
    }
}