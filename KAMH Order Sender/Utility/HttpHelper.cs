using KAMH_Order_Sender.Interfaces;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace KAMH_Order_Sender.Utility
{
    public class HttpHelper
    {
        private static HttpHelper Instance;
        public static HttpHelper GetInstance
        {
            get=>Instance ?? (Instance = new HttpHelper());
        }
        public async Task<IResponseParameter> PostRequestAsync(string PostAPI,string PostBody)
        {
            IResponseParameter responseParameter = new ResponseParameter();
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(PostAPI);
                request.Method = Constants.Post;
                request.ContentType = Constants.ApplicationJson;
                var buffer = Encoding.UTF8.GetBytes(PostBody);
                request.ContentLength = buffer.Length;
                using (var postDataStream = request.GetRequestStream())
                {
                    postDataStream.Write(buffer, 0, buffer.Length);
                }
                var response = (HttpWebResponse)await request.GetResponseAsync();
                var responseStream = response.GetResponseStream();
                using(var stream = new StreamReader(responseStream))
                {
                    responseParameter.Response = stream.ReadToEnd()?.ToString();
                }
                responseParameter.Success = true;
            }
            catch(Exception ex) { 
                responseParameter.Success = false;
                responseParameter.ErrorMessage = ex.Message;
                responseParameter.Error = ex;
                responseParameter.Response = string.Empty;
            }
            return responseParameter;
        }
    }
}
