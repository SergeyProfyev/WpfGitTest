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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FixAddress
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<AList> adrlist;

        public MainWindow()
        {
            InitializeComponent();
            var primaryMonitorArea = SystemParameters.WorkArea;
            Left = primaryMonitorArea.Left + 10;
            Top = primaryMonitorArea.Top + 10;

            FIASListViewModel vm = new FIASListViewModel();
            DataContext = vm;
            if (vm.CloseAction == null)
                vm.CloseAction = new Action(this.Close);
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            //this.Close();
        }

        private void AllAddr_Click(object sender, RoutedEventArgs e)
        {
            //RefreshAddrList();
        }

        private void LoadAddrList()
        {
            //using (var dc = new eORDEREntities())
            //{
            //    adrlist = (from al in dc.O_HouseSeriesAddrList
            //               from hsa in dc.O_HSAList.Where(h => h.HSAID == al.lngHouseSeriesAddrListID).DefaultIfEmpty()
            //               select new AList
            //               {
            //                   id = al.lngHouseSeriesAddrListID,
            //                   addr1 = al.strAddr,
            //                   fias = hsa.FiasCode,
            //                   addr2 = hsa.Address,
            //                   check = hsa.Check,
            //                   isEdited = false
            //               }).ToList();
            //}
        }

        private void RefreshAddrList()
        {
            //List<AList> query;
            //if (this.AllAddr.IsChecked == true)
            //{
            //    query = (from q in adrlist select q).ToList();
            //}
            //else
            //{
            //    query = (from q in adrlist where q.check == true select q).ToList();
            //}
            //RecNum.Text = String.Format("Всего строк: {0}", query.Count.ToString());
            //addrList.ItemsSource = query;
        }

        //private void addrList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        //{
        //  //AList rec = (AList)addrList.SelectedItem;
        //  //var form = new AddrEdit(rec.id);
        //  //form.ShowDialog();
        //  //rec.isEdited = true;
        //}

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            //LoadAddrList();
            //RefreshAddrList();
        }
    }
}
