using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixAddress
{
    public class DadataHelper
    {
        private static string token = FixAddress.Properties.Resources.DadataKey;    // "API-КЛЮЧ";
        private static string url = "https://suggestions.dadata.ru/suggestions/api/4_1/rs";
        /// <summary>
        ///  запросить подсказку по адресу
        /// </summary>
        /// <param name="addr">адрес для подсказки</param>
        public List<FIASModel> GetSuggest(string addr)
        {
            Console.WriteLine("Подключение к DADATA...");
            var api = new SuggestClient(token, url);
            Console.WriteLine("Подключение к DADATA выполнено.");
            if (addr.IndexOf(Environment.NewLine) >= 0)
                addr = addr.Substring(0, addr.IndexOf(Environment.NewLine));  //подавить метро и доп сведения в адресе
            var response = api.QueryAddress(addr);                          // запросить подсказку по адресу

            return FillAddrList(response); ;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        private List<FIASModel> FillAddrList(SuggestAddressResponse response)
        {
            var adl = new List<FIASModel>();
            foreach (var r in response.suggestions)
            {
                if (r.data.fias_level == "8")
                {
                    decimal lat = 0;
                    decimal lon = 0;
                    if (!(r.data.geo_lat == null)) decimal.TryParse(r.data.geo_lat.Replace(".", ","), out lat);
                    if (!(r.data.geo_lon == null)) decimal.TryParse(r.data.geo_lon.Replace(".", ","), out lon);
                    var item = new FIASModel();
                    item.Addr2 = r.ToString();
                    item.Fias = r.data.fias_id;
                    item.FiasLevel = r.data.fias_level;
                    item.Kladr = r.data.kladr_id;
                    item.OCATO = r.data.okato;
                    item.Lat = lat;
                    item.Lon = lon;
                    adl.Add(item);
                }
            }
            return adl;
        }


    }
}
