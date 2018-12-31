using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System;

namespace FixAddress
{
    public class FIASSelectViewModel
    {
        //private FIASModel fias;
        //private List<FIASModel> fiasList;


        private ObservableCollection<FIASModel> _fiasList;
        public ObservableCollection<FIASModel> FiasList
        {
            get { return _fiasList; }
            set
            {
                if (value != this._fiasList)
                    _fiasList = value;
                OnPropertyChanged("FiasList");
            }
        }
        private FIASModel fias;
        public FIASModel SelectedAddr
        {
            get { return fias; }
            set
            {
                if (value != this.fias)
                {
                    fias = value;
                }
                OnPropertyChanged("SelectedAddr");
            }
        }

        // команда выбора объекта
        private RelayCommand selectCommand;
        public RelayCommand SelectCommand
        {
            get
            {
                return selectCommand ??
                  (selectCommand = new RelayCommand(obj =>
                  {
                      FIASModel fias = obj as FIASModel;
                      Select(fias);
                  }, (obj) => fias != null));

            }
        }

        public Action CloseAction { get; set; }

        private void Select(FIASModel f)
        {
            //var id = f.ID;
            CloseAction();
        }

        public FIASSelectViewModel(string addr)
        {
            var query = GetSuggest(addr);
            FiasList = new ObservableCollection<FIASModel>(query);
            var window = new FiasSelect(this);
            window.DataContext = this;
            window.ShowDialog();
        }

        private List<FIASModel> GetSuggest(string addr)
        {
            DadataHelper ddt = new DadataHelper();
            var suggest = ddt.GetSuggest(addr);
            return suggest;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

        }

    }
}
