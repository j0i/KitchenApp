using KitchenApp.Models.Requests;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace KitchenApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        DispatcherTimer Timer = new DispatcherTimer();
        public MainPage()
        {
            this.InitializeComponent();
            DataContext = this;
            InitializeTimer();
        }
        private void InitializeTimer()
        {
            Timer.Tick += Timer_Tick;
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Start();
        }
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            await RefreshItemSource();
            var validSendGetOrdersRequest = await GetOrdersRequest.SendGetOrdersRequest();
        }
        private void Timer_Tick(object sender, object e)
        {
             lblTime.Text = DateTime.Now.ToString("h:mm:ss tt");
        }
        private async Task RefreshItemSource()
        {
            IList<string> tempList = new List<string>()
            {
                "This",
                "is",
                "a",
                "test"
            };
            uxReceivedOrdersView.ItemsSource = tempList;
        }
    }
}
