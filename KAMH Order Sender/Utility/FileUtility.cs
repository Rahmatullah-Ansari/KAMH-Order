using System;
using System.IO;

namespace KAMH_Order_Sender.Utility
{
    public static class FileUtility
    {
        public static bool SaveOrder(string OrderText)
        {
            if (string.IsNullOrEmpty(OrderText)) return false;
            try
            {
                var file = $"{Constants.GetTempPath()}\\{string.Join("_", DateTime.Now.ToString().Split(Path.GetInvalidFileNameChars()))}.txt";
                File.WriteAllText(file, OrderText);
                return true;
            }
            catch { return false; }
        }
    }
}
