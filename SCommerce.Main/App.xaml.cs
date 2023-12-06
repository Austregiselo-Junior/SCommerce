using SCommerce.Main.Common;
using SCommerce.Main.Model.Data;
using SCommerce.Main.Model.Entities;
using SCommerce.Main.Model.Services;
using SCommerce.Main.View;
using System;
using System.Collections.Generic;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace SCommerce.Main
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    internal sealed partial class App : Application
    {
        public static Product SelectProduct { get; set; }

        public NavigationService NavigationService { get; private set; }
        private AppShell _appShell = null;

        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            SelectProduct = new Product();
            this.Suspending += OnSuspending;
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            Frame rootFrame = null;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();

                NavigationService = new NavigationService(rootFrame);

                _appShell = new AppShell();

                _appShell.SetContent(rootFrame);

                rootFrame.NavigationFailed += OnNavigationFailed;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Load state from previously suspended application
                }

                // Place the frame in the current Window
                Window.Current.Content = _appShell;
            }

            if (e.PrelaunchActivated == false)
            {
                if (rootFrame.Content == null)
                {
                    // When the navigation stack isn't restored navigate to the first page,
                    // configuring the new page by passing required information as a navigation
                    // parameter
                    NavigationService.Navigate(typeof(HomePage));
                }
                // Ensure the current window is active
                Window.Current.Activate();

                ServiceConnection.GetInstance().OnStartDB();
            }
        }

        /// <summary>
        /// Invoked when Navigation to a certain page fails
        /// </summary>
        /// <param name="sender">The Frame which failed navigation</param>
        /// <param name="e">Details about the navigation failure</param>
        private void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Save application state and stop any background activity
            deferral.Complete();
        }

        public void SetVisibleButtonTryGoBackPage(bool visible)
        {
            _appShell.SetVisibleTryGoBackPage(visible);
        }

        public void SetVisibleButtonGoHomePage(bool visible)
        {
            _appShell.SetVisibleGoHomePage(visible);
        }

        public void SetVisibleButtonCartQiantityItens(bool visible)
        {
            _appShell.SetVisibleCartQuantityItens(visible);
        }

        public void SetVisibleButtonAppBarButton(bool visible)
        {
            _appShell.SetVisibleAppBarButton(visible);
        }

        public void SetVisibleButtonSettingPage(bool visible)
        {
            _appShell.SetVisibleAppSettingPageButton(visible);
        }
    }
}