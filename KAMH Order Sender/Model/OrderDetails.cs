using KAMH_Order_Sender.Enums;
using KAMH_Order_Sender.Utility;

namespace KAMH_Order_Sender.Model
{
    public class OrderDetails:BindableBase
    {
        private string orderId;
        public string OrderId
        {
            get => orderId;
            set=>SetProperty(ref orderId, value);
        }
        private OrderStatus status;
        public OrderStatus Status
        {
            get=>status;
            set=>SetProperty(ref status, value);
        }
        private string message;
        public string Message
        {
            get => message;
            set =>SetProperty(ref message, value);
        }
        private string time;
        public string PlacedTime
        {
            get => time; set => SetProperty(ref time, value);
        }
        private string urls;
        public string Urls
        {
            get => urls;
            set => SetProperty(ref urls, value,nameof(Urls));
        }
    }
}
