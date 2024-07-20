using System.IO;

namespace KAMH_Order_Sender.Utility
{
    public static class DirectoryUtility
    {
        public static void CreateDirectory(string Path)
        {
            try
            {
                if(!Directory.Exists(Path))
                    Directory.CreateDirectory(Path);
            }
            catch { }
        }
    }
}
