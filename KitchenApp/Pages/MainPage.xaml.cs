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
        public Orders c_ordersMaster;
        public Employee c_employeeMaster;
        public MainPage()
        {
            this.InitializeComponent();
            DataContext = this;
            InitializeTimer();
            RefreshEmployeeList();
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
        public async void RefreshEmployeeList()
        {
            RealmManager.RemoveAll<EmployeeList>();
            RealmManager.RemoveAll<Employee>();
            var validEmployeesRequest = await GetEmployeeListRequest.SendGetEmployeeListRequest();
        }
        public async Task<string> GetEmployeeName(string employeeID)
        {
            var validEmployeesRequest = await GetEmployeeListRequest.SendGetEmployeeListRequest();
            c_employeeMaster = RealmManager.Find<Employee>(employeeID);

            return c_employeeMaster.first_name;
        }
        public void FilterPreparedOrders()
        {
            c_ordersMaster = (Orders)c_ordersMaster.menuItems.Where(p => !p.prepared);
        }

        private async Task RefreshItemSource()
        {
            var validSendGetOrdersRequest = await GetOrdersRequest.SendGetOrdersRequest();

            List<Orders> orderList0 = new List<Orders>();
            List<Orders> orderList1 = new List<Orders>();
            List<Orders> orderList2 = new List<Orders>();
            List<Orders> orderList3 = new List<Orders>();
            List<Orders> orderList4 = new List<Orders>();

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

        /* Item sourced containers for all orders.
           Each time an order block is clicked it will update class var c_ordersMaster 
           to the order that was clicked on and populates popup values with unique order text */
        private async void uxReceivedOrdersControl4_ItemClick(object sender, ItemClickEventArgs e)
        {
            c_ordersMaster = (Orders)e.ClickedItem;
            string employeeName = await GetEmployeeName(c_ordersMaster.employee_id);
            lblTableNumber.Text = c_ordersMaster.table_number_string;
            uxGetEmployeeButton.Content = "Get " + employeeName;
            uxOrdersPopup.IsOpen = true;
        }
        private async void uxReceivedOrdersControl3_ItemClick(object sender, ItemClickEventArgs e)
        {
            c_ordersMaster = (Orders)e.ClickedItem;
            string employeeName = await GetEmployeeName(c_ordersMaster.employee_id);
            lblTableNumber.Text = c_ordersMaster.table_number_string;
            uxGetEmployeeButton.Content = "Get " + employeeName;
            uxOrdersPopup.IsOpen = true;
        }
        private async void uxReceivedOrdersControl2_ItemClick(object sender, ItemClickEventArgs e)
        {
            c_ordersMaster = (Orders)e.ClickedItem;
            string employeeName = await GetEmployeeName(c_ordersMaster.employee_id);
            lblTableNumber.Text = c_ordersMaster.table_number_string;
            uxGetEmployeeButton.Content = "Get " + employeeName;
            uxOrdersPopup.IsOpen = true;
        }
        private async void uxReceivedOrdersControl1_ItemClick(object sender, ItemClickEventArgs e)
        {
            c_ordersMaster = (Orders)e.ClickedItem;
            string employeeName = await GetEmployeeName(c_ordersMaster.employee_id);
            lblTableNumber.Text = c_ordersMaster.table_number_string;
            uxGetEmployeeButton.Content = "Get " + employeeName;
            uxOrdersPopup.IsOpen = true;
        }
        private async void uxReceivedOrdersControl0_ItemClick(object sender, ItemClickEventArgs e)
        {
            c_ordersMaster = (Orders)e.ClickedItem;
            string employeeName = await GetEmployeeName(c_ordersMaster.employee_id);
            lblTableNumber.Text = c_ordersMaster.table_number_string;
            uxGetEmployeeButton.Content = "Get " + employeeName;
            uxOrdersPopup.IsOpen = true;
            uxReceivedOrdersControl0.IsFocusEngaged=false ;
        }

        // send notification to appropriate employee
        private async void uxGetEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            string notificationType = "Order Question";
            await PostNotificationsRequest.SendNotificationRequest(notificationType, RealmManager.All<Orders>().FirstOrDefault().employee_id, "Kitchen");
            uxOrdersPopup.IsOpen = false;
        }
        // set all menu items to prepared
        // send notification to appropriate employee
        private async void uxCompleteOrderButton_Click(object sender, RoutedEventArgs e)
        {
            string notificationType = "Order Complete for " + c_ordersMaster.table_number_string;
            var validUpdatePreparedRequest = await PutToPreparedRequest.SendPutToPreparedRequest(c_ordersMaster._id, c_ordersMaster.menuItems.ToList());
            await PostNotificationsRequest.SendNotificationRequest(notificationType, RealmManager.All<Orders>().FirstOrDefault().employee_id, "Kitchen");
            uxOrdersPopup.IsOpen = false;
        }

        private void uxExitButton_Click(object sender, RoutedEventArgs e)
        {
            uxOrdersPopup.IsOpen = false;
        }
    }
}
