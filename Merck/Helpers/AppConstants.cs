using System.Collections.Generic;
using System.Linq;

namespace Merck.Helpers
{
    public class AppConstants
    {
        public const string Device1 = "EASYPOD2";
        public const string Device2 = "EASYPOD3";
        private static readonly IDictionary<string, string> DeviceList = new Dictionary<string, string>();
        static AppConstants()
        {
            IntializeList();
        }
        public static void IntializeList()
        {
            DeviceList.Add(Device1, "https://secret-hollows-96938.herokuapp.com/setProductInfoSetter");
            DeviceList.Add(Device2, "https://secret-hollows-96938.herokuapp.com/setProductInfoSetter");
        }
        public static string GetURLByDeviceName(string deviceName)
        {
            return DeviceList.Where(dv=>dv.Key==deviceName).FirstOrDefault().Value;
        }
    }
}
