using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Linq;
using System.Collections.Generic;
using System;
using System.Windows.Data;

namespace FixAddress
{
    public class FIASListViewModel : INotifyPropertyChanged
    {
        private FIASModel selectedFias;
        private int recordCount;
        private List<FIASModel> fullFiasList;
 
        
        /// <summary>
        /// команда редактирования элемента списка
        /// </summary>
        private RelayCommand editCommand;
        public RelayCommand EditCommand
        {
            get
            {
                return editCommand ??
                  (editCommand = new RelayCommand(obj =>
                  {

                      FIASModel fias = obj as FIASModel;
                      if (fias != null)
                      {
                  var form = new AddrEdit(fias);
                          form.ShowDialog();
                      }
                  }, (obj) => selectedFias != null));
            }
        }
        /// <summary>
        /// Команда обновления списка адресов из БД 
        /// </summary>
        private RelayCommand refreshCommand;
        public RelayCommand RefreshCommand
        {
            get
            {
                return refreshCommand ??
                  (refreshCommand = new RelayCommand(obj =>
                  {
                      //FiasList = null;
                      fullFiasList = LoadAddrList();  //Получить полный список адресов из БД
                      GetAddrSubSet(fullFiasList);
                  }));
            }
        }
        /// <summary>
        /// Команда завершения работы 
        /// </summary>
        private RelayCommand closeCommand;
        public RelayCommand CloseCommand
        {
            get
            {
                return closeCommand ??
                  (closeCommand = new RelayCommand(obj =>
                  {
                      CloseAction();

                  }));
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public Action CloseAction { get; set; }

        /// <summary>
        /// Свойство "Список адресов базы ФИАС"
        /// </summary>
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
        /// <summary>
        /// Свойство "Выбранный элемент списка"
        /// </summary>
        public FIASModel SelectedFias
        {
            get { return selectedFias; }
            set
            {
                selectedFias = value;
                OnPropertyChanged("SelectedFias");
            }
        }
        /// <summary>
        /// Свойство "Режим отбора списка адресов базы ФИАС"
        /// </summary>
        private bool mode;
        public bool Mode
        {
            get { return mode; }
            set
            {
                mode = value;
                OnPropertyChanged("Mode");
                GetAddrSubSet(fullFiasList);
            }
        }
        /// <summary>
        /// Свойство "Количество записей в списке адресов"
        /// </summary>
        public int RecordCount
        {
            get { return recordCount; }
            set
            {
                recordCount = value;
                OnPropertyChanged("RecordCount");
            }
        }
        /// <summary>
        /// Конструктор ВМ
        /// </summary>
        public FIASListViewModel()
        {
            fullFiasList = LoadAddrList();  //Получить полный список адресов из БД
            GetAddrSubSet(fullFiasList);    //Вывести список на форму согласно режима отбора

        }
        /// <summary>
        /// Получить полный список адресов из БД
        /// </summary>
        /// <returns></returns>
        private List<FIASModel> LoadAddrList() //IQueryable<FIASModel> LoadAddrList()
        {
            using (var dc = new eORDEREntities())
            {
                var query = (from al in dc.O_HouseSeriesAddrList
                             from hsa in dc.O_HSAList.Where(h => h.HSAID == al.lngHouseSeriesAddrListID).DefaultIfEmpty()
                             select new FIASModel
                             {
                                 ID = al.lngHouseSeriesAddrListID,
                                 Addr1 = al.strAddr,
                                 Fias = hsa.FiasCode,
                                 Addr2 = hsa.Address,
                                 Check = hsa.Check
                                 //isEdited = false
                             }).ToList();
                return query;
            }
        }
        private void GetAddrSubSet(List<FIASModel> fullList)
        {
            List<FIASModel> query;
            if (Mode == true)
            {
                query = (from q in fullList select q).ToList();
            }
            else
            {
                query = (from q in fullList where q.Check == true select q).ToList();
            }
            FiasList = new ObservableCollection<FIASModel>(query);
            RecordCount = FiasList.Count(); //кол-во записей в подвыборке

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

        }
    }
}
