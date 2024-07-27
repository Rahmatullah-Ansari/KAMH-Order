using System;
using System.IO;

namespace KAMH_Order_Sender.Utility
{
    public static class Constants
    {
        public static string ApplicationJson = "application/json";
        public static string Get = "GET";
        public static string Post = "POST";
        public static string GetPlacedTime => String.Format("{0:G}", DateTime.Now);
        public static string OrderAPI => "https://app.autolikesig.com/api/addkamh-test-order";
        public static string OrderBody(string InstagramPostUrl,string CommentID="") => $"{{\"post_url\":\"{InstagramPostUrl}\",\"comment_id\":{GetCommentID(CommentID)}}}";
        public static string GetTempPath()
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),"kAMH Orders");
            DirectoryUtility.CreateDirectory(path);
            return path;
        }
        public static string GetCommentID(string CommentID)
        {
            return string.IsNullOrEmpty(CommentID) ? RandomUtilties.GetRandomNumber(100, 1).ToString() : CommentID;
        }
    }
}
