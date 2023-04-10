using System.Collections.Generic;
using System.Linq;

namespace Merck.Helpers
{
    public class AppConstants
    {
        public const string Device1 = "EASYPOD2";
        public const string Device2 = "EASYPOD3";
        private static readonly IDictionary<string, string> DeviceList = new Dictionary<string, string>();
        private static readonly IDictionary<string, string> CountryList = new Dictionary<string, string>();
        static AppConstants()
        {
            IntializeList();
        }
        public static void IntializeList()
        {
            DeviceList.Add(Device1, "https://secret-hollows-96938.herokuapp.com/setProductInfoSetter");
            DeviceList.Add(Device2, "https://secret-hollows-96938.herokuapp.com/setProductInfoSetter");
            CountryList.Add(Device1, "Vietnam");
            CountryList.Add(Device2, "Türkiye");
        }
        public static string GetURLByDeviceName(string deviceName)
        {
            return DeviceList.Where(dv=>dv.Key==deviceName).FirstOrDefault().Value;
        }
        public static string GetCountryByDeviceName(string deviceName)
        {
            return CountryList.Where(dv => dv.Key == deviceName).FirstOrDefault().Value;
        }
        public static List<string> GetAllDevices()
        {
            List<string> deviceList = new List<string>();
            deviceList= DeviceList.Keys.ToList();
            deviceList.Add("All");
            return deviceList;
        }
        public static List<string> GetAllCountries()
        {
            List<string> countryList = new List<string>();
            countryList = CountryList.Values.ToList();
            return countryList;
        }
        public static List<string> GetAllDevicesExcludingAll()
        {
            List<string> deviceList = new List<string>();
            deviceList = DeviceList.Keys.ToList();
            return deviceList;
        }
    }
}
