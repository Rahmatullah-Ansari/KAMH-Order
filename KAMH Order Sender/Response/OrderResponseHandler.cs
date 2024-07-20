using KAMH_Order_Sender.Interfaces;
using KAMH_Order_Sender.Model;
using KAMH_Order_Sender.Utility;
using System;

namespace KAMH_Order_Sender.Response
{
    public class OrderResponseHandler
    {
        public OrderDetails Details { get; set; }= new OrderDetails();
        private JsonParser Parser => JsonParser.GetInstance;
        public bool Success {  get; set; }
        public OrderResponseHandler(IResponseParameter responseParameter)
        {
            try
            {
                var jObject = Parser.Parse(responseParameter.Response);
                Details.OrderId = Parser.GetJTokenValue(jObject, "order_id");
                Success = Parser.GetJTokenValue(jObject, "code") == "200";
                Details.Message = Parser.GetJTokenValue(jObject, "message");
                Details.PlacedTime = Constants.GetPlacedTime;
            }catch (Exception ex) { }
        }
    }
}
