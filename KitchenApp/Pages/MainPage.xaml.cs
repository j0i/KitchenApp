using KitchenApp.Models;
using KitchenApp.Models.Requests;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
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

namespace KitchenApp
{
    public sealed partial class MainPage : Page
    {
        DispatcherTimer Timer = new DispatcherTimer();
        public Orders c_ordersMaster = new Orders();
        public Employee c_employeeMaster = new Employee();

        List<Orders> orderList0 = new List<Orders>();
        List<Orders> orderList1 = new List<Orders>();
        List<Orders> orderList2 = new List<Orders>();
        List<Orders> orderList3 = new List<Orders>();
        List<Orders> orderList4 = new List<Orders>();

        public MainPage()
        {
            this.InitializeComponent();
            DataContext = this;
            InitializeTimer();
            RefreshItemSource();
            RefreshEmployeeList();
        }
        //Upon page appearance start AutoRefresh
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            //Initalization for awaited system tasks to be cancelled for AutoRefresh ONLY
            await AutoRefreshEnabled();
        }
        //Digital clock logic
        private void InitializeTimer()
        {
            Timer.Tick += Timer_Tick;
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Start();
        }
        private void Timer_Tick(object sender, object e)
        {
             lblTime.Text = DateTime.Now.ToString("h:mm:ss tt");
        }
        //Gets current employees for the day
        public async void RefreshEmployeeList()
        {
            RealmManager.RemoveAll<EmployeeList>();
            RealmManager.RemoveAll<Employee>();
            var validEmployeesRequest = await GetEmployeeListRequest.SendGetEmployeeListRequest();
        }
        //Get current employee to display
        //Called by each received orders controls
        //Parameter passed by c_orderMaster.employee_id
        public async Task<string> GetEmployeeName(string employeeID)
        {
            var validEmployeesRequest = await GetEmployeeListRequest.SendGetEmployeeListRequest();
            c_employeeMaster = RealmManager.Find<Employee>(employeeID);

            return c_employeeMaster.first_name;
        }
        //Refresh the page every 10 seconds
        public async Task AutoRefreshEnabled()
        {
            while(true)
            {
                uxReceivedOrdersControl0.IsEnabled = false;
                uxReceivedOrdersControl1.IsEnabled = false;
                uxReceivedOrdersControl2.IsEnabled = false;
                uxReceivedOrdersControl4.IsEnabled = false;
                var validSendGetOrdersRequest = await GetOrdersRequest.SendGetOrdersRequest();
                RefreshItemSource();
                uxReceivedOrdersControl0.IsEnabled = true;
                uxReceivedOrdersControl1.IsEnabled = true;
                uxReceivedOrdersControl2.IsEnabled = true;
                uxReceivedOrdersControl4.IsEnabled = true;
                await Task.Delay(TimeSpan.FromSeconds(10));
            }
        }

        private void RefreshItemSource()
        {
            var itemsList = RealmManager.All<Orders>();
            orderList0 = new List<Orders>();
            orderList1 = new List<Orders>();
            orderList2 = new List<Orders>();
            orderList3 = new List<Orders>();
            orderList3 = new List<Orders>();

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
           Each time an order block is clicked it will update class var c_ordersMaster and c_employeeMaster
           to the order & associated employee that was clicked on and populates popup values with unique order text */
        private async void uxReceivedOrdersControl4_ItemClick(object sender, ItemClickEventArgs e)
        {
            //update class variables
            c_ordersMaster = (Orders)e.ClickedItem;
            //c_employeeMaster.first_name = await GetEmployeeName(c_ordersMaster.employee_id);
            string employeeID = c_ordersMaster.employee_id;
            string employeeName = await GetEmployeeName(employeeID);

            //update UI views
            lblTableNumber.Text = c_ordersMaster.table_number_string;
            uxGetEmployeeButton.Content = "Get " + c_employeeMaster.first_name;
            uxOrdersPopup.IsOpen = true;
        }
        private async void uxReceivedOrdersControl3_ItemClick(object sender, ItemClickEventArgs e)
        {
            c_ordersMaster = (Orders)e.ClickedItem;
            //c_employeeMaster.first_name = await GetEmployeeName(c_ordersMaster.employee_id);
            string employeeID = c_ordersMaster.employee_id;
            string employeeName = await GetEmployeeName(employeeID);
            
            lblTableNumber.Text = c_ordersMaster.table_number_string;
            uxGetEmployeeButton.Content = "Get " + c_employeeMaster.first_name;
            uxOrdersPopup.IsOpen = true;
        }
        private async void uxReceivedOrdersControl2_ItemClick(object sender, ItemClickEventArgs e)
        {
            c_ordersMaster = (Orders)e.ClickedItem;
            //c_employeeMaster.first_name = await GetEmployeeName(c_ordersMaster.employee_id);
            string employeeID = c_ordersMaster.employee_id;
            string employeeName = await GetEmployeeName(employeeID);

            lblTableNumber.Text = c_ordersMaster.table_number_string;
            uxGetEmployeeButton.Content = "Get " + c_employeeMaster.first_name;
            uxOrdersPopup.IsOpen = true;
        }
        private async void uxReceivedOrdersControl1_ItemClick(object sender, ItemClickEventArgs e)
        {
            c_ordersMaster = (Orders)e.ClickedItem;
            //c_employeeMaster.first_name = await GetEmployeeName(c_ordersMaster.employee_id);
            string employeeID = c_ordersMaster.employee_id;
            string employeeName = await GetEmployeeName(employeeID);

            lblTableNumber.Text = c_ordersMaster.table_number_string;
            uxGetEmployeeButton.Content = "Get " + c_employeeMaster.first_name;
            uxOrdersPopup.IsOpen = true;
        }
        private async void uxReceivedOrdersControl0_ItemClick(object sender, ItemClickEventArgs e)
        {
            c_ordersMaster = (Orders)e.ClickedItem;
            //c_employeeMaster.first_name = await GetEmployeeName(c_ordersMaster.employee_id);
            string employeeID = c_ordersMaster.employee_id;
            string employeeName = await GetEmployeeName(employeeID);

            lblTableNumber.Text = c_ordersMaster.table_number_string;
            uxGetEmployeeButton.Content = "Get " + c_employeeMaster.first_name;
            uxOrdersPopup.IsOpen = true;
        }

        // send kitchen notification to appropriate employee
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

            await DecrementIngredients();
            var validUpdatePreparedRequest = await PutToPreparedRequest.SendPutToPreparedRequest(c_ordersMaster._id, c_ordersMaster.menuItems.ToList());
            await PostNotificationsRequest.SendNotificationRequest(notificationType, c_ordersMaster.employee_id, "Kitchen");
            uxOrdersPopup.IsOpen = false;
        }

        private async void uxExitButton_Click(object sender, RoutedEventArgs e)
        {
            uxOrdersPopup.IsOpen = false;
        }
        public async Task DecrementIngredients()
        {
            //get all of the ingredients for the current order
            await GetIngredientsRequest.SendGetIngredientsListRequest();
            foreach(MenuItems m in c_ordersMaster.menuItems)
            {
                foreach(string i in m.ingredients)
                {
                    string check = i;
                    int newQuantity = RealmManager.Find<Ingredients>(i).quantity - 1;
                    var validResponse = await UpdateIngredientRequest.SendUpdateIngredientRequest(i, "quantity", newQuantity.ToString());
                }
            }
        }
    }
}
