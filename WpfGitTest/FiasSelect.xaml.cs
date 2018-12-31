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
  /// Логика взаимодействия для FiasSelect.xaml
  /// </summary>
  public partial class FiasSelect : Window
  {
    //private FIASModel selectedFias;
    //private List<FIASModel> fiasList; 

    public FiasSelect(FIASSelectViewModel vm)
    {
      InitializeComponent();
            //FIASSelectViewModel vm = new FIASSelectViewModel(fm.Addr2);
            //this.DataContext = vm;
            if (vm.CloseAction == null)
                vm.CloseAction = new Action(this.Close);
           //fvm.ClosingRequest += (sender, e) => this.Close();

        }
  }
}
