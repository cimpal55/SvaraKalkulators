using SvaraKalkulators.Checklist.Bootstrap;
using SvaraKalkulators.Checklist.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace SvaraKalkulators.Checklist
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            InitializeApp();

            MainPage = new MainView();
        }

        private void InitializeApp()
        {
            AppContainer.RegisterDependencies();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}