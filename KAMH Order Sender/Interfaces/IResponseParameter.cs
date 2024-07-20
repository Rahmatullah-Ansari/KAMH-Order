using System;

namespace KAMH_Order_Sender.Interfaces
{
    public interface IResponseParameter
    {
        bool Success { get; set; }
        Exception Error {  get; set; }
        string Response {  get; set; }
        string ErrorMessage {  get; set; }
    }
    public class ResponseParameter : IResponseParameter
    {
        public bool Success { get; set; }
        public Exception Error { get ; set ; }
        public string Response { get; set; }
        public string ErrorMessage { get; set; }
    }
}
