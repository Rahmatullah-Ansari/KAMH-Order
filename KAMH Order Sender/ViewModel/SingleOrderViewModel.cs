using KAMH_Order_Sender.Model;
using KAMH_Order_Sender.Response;
using KAMH_Order_Sender.Utility;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace KAMH_Order_Sender.ViewModel
{
    public class SingleOrderViewModel:BindableBase
    {
        private static SingleOrderViewModel Instance;
        public static SingleOrderViewModel GetInstance
        {
            get
            {
                return Instance ?? (Instance = new SingleOrderViewModel());
            }
        }
        public SingleOrderViewModel()
        {
            PlaceOrderCommand = new BaseCommand<object>(sender => true, PlaceOrderExecute);
            helper = HttpHelper.GetInstance;
        }

        private async void PlaceOrderExecute(object obj)
        {
            var UrlsCollection = await GetUrlsCollections();
            var text = "Date Time | Order ID | Post URL \n";
            foreach (var Url in UrlsCollection)
            {
                var response = await helper.PostRequestAsync(Constants.OrderAPI,Constants.OrderBody(Url));
                var PlacedResponse = new OrderResponseHandler(response);
                if (PlacedResponse != null && PlacedResponse.Success)
                {
                    Orders.Add(PlacedResponse.Details);
                    text += $"{PlacedResponse.Details.PlacedTime} | {PlacedResponse.Details.OrderId} | {Url}\n";
                }
                await Task.Delay(TimeSpan.FromSeconds(3));
            }
            FileUtility.SaveOrder(text);
            Model.Urls = string.Empty;
        }

        private async Task<List<string>> GetUrlsCollections()
        {
            var list = new List<string>();
            if(!string.IsNullOrEmpty(Model.Urls))
            {
                await Task.Run(() =>
                {
                    var lines = Model.Urls?.Replace("\r","").Split('\n')?.ToList();
                    lines.RemoveAll(z=>string.IsNullOrEmpty(z));
                    foreach(var line in lines)
                    {
                        var collection = line.Split(',')?.ToList();
                        collection.RemoveAll(x => string.IsNullOrEmpty(x) || !x.Contains(".instagram.com"));
                        foreach(var item in collection)
                        {
                            list.Add(Regex.Replace(item,"\\?.*",""));
                        }
                        
                    }
                });
            }
            return list;
        }

        public ICommand PlaceOrderCommand {  get; set; }
        public HttpHelper helper { get; set; }
        private OrderDetails details = new OrderDetails();
        public OrderDetails Details
        {
            get=> details;
            set=>SetProperty(ref details, value);
        }
        public OrderDetails Model=>Details;
        private ObservableCollection<OrderDetails> _orders=new ObservableCollection<OrderDetails>();
        public ObservableCollection<OrderDetails> Orders
        {
            get => _orders;
            set => SetProperty(ref _orders, value);
        }
    }
}
