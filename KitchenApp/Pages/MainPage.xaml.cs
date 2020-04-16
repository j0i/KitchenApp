using KitchenApp.Models;
using KitchenApp.Models.Requests;
using KitchenApp.Models.ServiceRequests;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using System.Windows.Input;
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
        public string x;
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
        }
        private void Timer_Tick(object sender, object e)
        {
             lblTime.Text = DateTime.Now.ToString("h:mm:ss tt");
        }
        private async Task RefreshItemSource()
        {
            List<Orders> orderList0 = new List<Orders>();
            List<Orders> orderList1 = new List<Orders>();
            List<Orders> orderList2 = new List<Orders>();
            List<Orders> orderList3 = new List<Orders>();
            List<Orders> orderList4 = new List<Orders>();

            var validSendGetOrdersRequest = await GetOrdersRequest.SendGetOrdersRequest();
            //var itemsList = RealmManager.All<OrdersList>().FirstOrDefault().Orders.ToList();

            string orderId = "5e967b70cd0dd200049ca25b";
            //var validUpdatePreparedRequest = await PutToPreparedRequest.SendPutToPreparedRequest(orderId, RealmManager.All<Orders>().FirstOrDefault().menuItems.ToList());

            var itemsList = RealmManager.All<Orders>();

            for (int i = 0; i < itemsList.Count(); i++)
            {
                if(i<4)
                {
                    orderList0.Add(itemsList.ElementAt(i));
                }
                if(i>=4 && i<8)
                {
                    orderList1.Add(itemsList.ElementAt(i));
                }
                if(i>=8 && i<12)
                {
                    orderList2.Add(itemsList.ElementAt(i));
                }
                if(i>=12 && i<16)
                {
                    orderList3.Add(itemsList.ElementAt(i));
                }
                if(i>=16 && i<20)
                {
                    orderList4.Add(itemsList.ElementAt(i));
                }
            }
            uxReceivedOrdersControl0.ItemsSource = orderList0;
            uxReceivedOrdersControl1.ItemsSource = orderList1;
            uxReceivedOrdersControl2.ItemsSource = orderList2;
            uxReceivedOrdersControl3.ItemsSource = orderList3;
            uxReceivedOrdersControl4.ItemsSource = orderList4;
        }
        private void uxReceivedOrdersControl4_ItemClick(object sender, ItemClickEventArgs e)
        {
            Orders orders = (Orders)e.ClickedItem;
        }
        private void uxReceivedOrdersControl3_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
        private void uxReceivedOrdersControl2_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
        private void uxReceivedOrdersControl1_ItemClick(object sender, ItemClickEventArgs e)
        {
            Orders orders = (Orders)e.ClickedItem;

        }
        private void uxReceivedOrdersControl0_ItemClick(object sender, ItemClickEventArgs e)
        {
            Orders orders = (Orders)e.ClickedItem;
        }
    }
}
