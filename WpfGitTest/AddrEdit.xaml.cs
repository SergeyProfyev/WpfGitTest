using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FixAddress
{
    /// <summary>
    /// Логика взаимодействия для AddrEdit.xaml
    /// </summary>
    public partial class AddrEdit : Window
    {
        private int recID;
        private FIASModel fias;
        public List<AddrList> AdList;
        /// <summary>
        /// Конструктор формы, открыть для редактирования переданной записи
        /// </summary>
        /// <param name="id">id записи для редактирования</param>
        public AddrEdit(FIASModel fias)
        {
            InitializeComponent();
            FiasViewModel vm = new FiasViewModel(fias);
            this.DataContext = vm;
            if (vm.CloseAction == null)
                vm.CloseAction = new Action(this.Close);
            ////материализовать объект на форме
            //using (var dc = new eORDEREntities())
            //{
            //  var rec = (from al in dc.O_HouseSeriesAddrList.Where(h => h.lngHouseSeriesAddrListID == id) select al).FirstOrDefault();
            //  recID = id;
            //  this.Addr.Text = rec.strAddr.ToString();
            //  var rec2 = (from hsa in dc.O_HSAList.Where(h => h.HSAID == id) select hsa).FirstOrDefault();
            //  if (rec2 == null)
            //  {
            //    this.AddrFias.Text = "";
            //    this.Fias.Text = "";
            //    this.Lat.Text = "";
            //    this.Lon.Text = "";
            //    this.Kladr.Text = "";
            //    this.Ocato.Text = "";
            //  }
            //  else
            //  {
            //    this.AddrFias.Text = rec2.Address.ToString();
            //    this.Fias.Text = rec2.FiasCode.ToString();
            //    this.Lat.Text = rec2.Geo_Lat.ToString();
            //    this.Lon.Text = rec2.Geo_Lon.ToString();
            //    this.Kladr.Text = rec2.KladrCode.ToString();
            //    this.Ocato.Text = rec2.Ocato.ToString();
            //  }
            //}
        }
        /// <summary>
        /// закрыть диалог без сохранения 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            //this.Close();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Variant_Click(object sender, RoutedEventArgs e)
        {
            //DadataHelper ddt = new DadataHelper();
            //AdList = ddt.GetSuggest(this.Addr.Text);
            //this.VariantList.ItemsSource = AdList;

        }
        /// <summary>
        /// двойной клик - выбор правильного варианта для замены 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VariantList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //var item = AdList[this.VariantList.SelectedIndex];
            //this.AddrFias.Text = item.Address;
            //this.Fias.Text = item.FiasCode;
            //this.Lat.Text = item.Geo_Lat.ToString();
            //this.Lon.Text = item.Geo_Lon.ToString();
            //this.Kladr.Text = item.KladrCode.ToString();
            //this.Ocato.Text = item.Ocato.ToString();
        }
        /// <summary>
        /// сохранить изменения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            //using (var dc = new eORDEREntities())
            //{
            //    var hsa = (from altadr in dc.O_HSAList
            //               where altadr.HSAID == recID
            //               select altadr).FirstOrDefault();
            //    if (hsa == null)  //если запись не найдена
            //    {
            //        //добавим новую
            //        hsa = new O_HSAList();
            //        hsa.HSAID = recID;
            //        dc.O_HSAList.Add(hsa);
            //    }
            //    decimal.TryParse(Lat.Text.Replace(".", ","), out var lat);
            //    decimal.TryParse(this.Lon.Text.Replace(".", ","), out var lon);
            //    hsa.Address = this.AddrFias.Text;
            //    hsa.FiasCode = this.Fias.Text;
            //    hsa.KladrCode = this.Kladr.Text;
            //    hsa.Ocato = this.Ocato.Text;
            //    hsa.Geo_Lat = lat;
            //    hsa.Geo_Lon = lon;
            //    hsa.Check = false;
            //    hsa.Unknown = false;
            //    dc.SaveChanges();
            //}
            //this.Close();
        }
        /// <summary>
        /// Пометить адрес как неизвестный
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Unknown_Click(object sender, RoutedEventArgs e)
        {
            //using (var dc = new eORDEREntities())
            //{
            //    var hsa = (from altadr in dc.O_HSAList
            //               where altadr.HSAID == recID
            //               select altadr).FirstOrDefault();
            //    if (hsa != null)  //если запись найдена
            //    {
            //        hsa.Unknown = true;
            //        dc.SaveChanges();
            //    }
            //}
            //this.Close();
        }
    }
}
