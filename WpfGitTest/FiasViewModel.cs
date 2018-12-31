using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;
using System;

namespace FixAddress
{
    public class FiasViewModel : INotifyPropertyChanged
    {
        private FIASModel fias;

        // команда сохранения изменений объекта
        private RelayCommand saveCommand;
        public RelayCommand SaveCommand
        {
            get
            {
                return saveCommand ??
                  (saveCommand = new RelayCommand(obj =>
                  {
                      Save();
                      CloseAction();
                  }, (obj) => fias != null));
            }
        }

        private void Save()
        {
            var id = fias.ID;
            using (var dc = new eORDEREntities())
            {
                var hsa = (from altadr in dc.O_HSAList
                           where altadr.HSAID == id
                           select altadr).FirstOrDefault();
                if (hsa == null)  //если запись не найдена
                {
                    //добавим новую
                    hsa = new O_HSAList();
                    hsa.HSAID = id;
                    dc.O_HSAList.Add(hsa);
                }
                hsa.Address = fias.Addr2;
                hsa.FiasCode = fias.Fias;
                hsa.KladrCode = fias.Kladr;
                hsa.Ocato = fias.OCATO;
                hsa.Geo_Lat = fias.Lat;
                hsa.Geo_Lon = fias.Lon;
                hsa.Check = false;
                hsa.Unknown = false;
                dc.SaveChanges();
            }
        }
        // команда сохранения изменений объекта
        private FIASSelectViewModel fsVM;
        private RelayCommand variantCommand;
        public RelayCommand VariantCommand
        {
            get
            {
                return variantCommand ??
                  (variantCommand = new RelayCommand(obj =>
                  {
                      fsVM = new FIASSelectViewModel(fias.Addr1);
                      if (fsVM.SelectedAddr != null)
                      {
                          this.Addr2 = fsVM.SelectedAddr.Addr2;
                          this.Fias = fsVM.SelectedAddr.Fias;
                          this.Lat = fsVM.SelectedAddr.Lat;
                          this.Lon = fsVM.SelectedAddr.Lon;
                          this.Kladr = fsVM.SelectedAddr.Kladr;
                          this.OCATO = fsVM.SelectedAddr.OCATO;
                      }
                      //var form = new FiasSelect(fias);
                      //        form.ShowDialog();

                  }, (obj) => fias != null));
            }
        }
        // команда завершения работы
        private RelayCommand unknownCommand;
        public RelayCommand UnknownCommand
        {
            get
            {
                return unknownCommand ??
                    (unknownCommand = new RelayCommand(obj =>
                      {
                          Unknown();
                          CloseAction();
                      }, (obj) => fias != null));
            }
        }
        private void Unknown()
        {
            var id = fias.ID;
            using (var dc = new eORDEREntities())
            {
                var hsa = (from altadr in dc.O_HSAList
                           where altadr.HSAID == id
                           select altadr).FirstOrDefault();
                if (hsa != null)  //если запись найдена
                {
                    hsa.Unknown = true;
                    dc.SaveChanges();
                }
            }
        }
        // команда завершения работы
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
        public Action CloseAction { get; set; }

        public FiasViewModel(FIASModel f)
        {
            fias = new FIASModel();
            //материализовать объект на форме
            using (var dc = new eORDEREntities())
            {
                var id = f.ID;
                var rec = (from al in dc.O_HouseSeriesAddrList.Where(h => h.lngHouseSeriesAddrListID == id) select al).FirstOrDefault();
                fias.Addr1 = rec.strAddr.ToString();
                var rec2 = (from hsa in dc.O_HSAList.Where(h => h.HSAID == id) select hsa).FirstOrDefault();
                if (rec2 == null)
                {
                    fias.ID = 0;
                    fias.Addr2 = "";
                    fias.Fias = "";
                    fias.Lat = 0M;
                    fias.Lon = 0M;
                    fias.Kladr = "";
                    fias.OCATO = "";
                }
                else
                {
                    fias.ID = rec2.HSAID.GetValueOrDefault();
                    fias.Addr2 = rec2.Address.ToString();
                    fias.Fias = rec2.FiasCode.ToString();
                    fias.Lat = (decimal)rec2.Geo_Lat.GetValueOrDefault();
                    fias.Lon = (decimal)rec2.Geo_Lon.GetValueOrDefault();
                    fias.Kladr = rec2.KladrCode.ToString();
                    fias.OCATO = rec2.Ocato.ToString();
                }

            }
        }
        public int ID
        {
            get { return fias.ID; }
            set
            {
                fias.ID = value;
                OnPropertyChanged("ID");
            }
        }
        public string Addr1
        {
            get { return fias.Addr1; }
            set
            {
                fias.Addr1 = value;
                OnPropertyChanged("Addr1");
            }
        }
        public string Fias
        {
            get { return fias.Fias; }
            set
            {
                fias.Fias = value;
                OnPropertyChanged("Fias");
            }
        }
        public string Addr2
        {
            get { return fias.Addr2; }
            set
            {
                fias.Addr2 = value;
                OnPropertyChanged("Addr2");
            }
        }
        public decimal Lat
        {
            get { return fias.Lat; }
            set
            {
                fias.Lat = value;
                OnPropertyChanged("Lat");
            }
        }
        public decimal Lon
        {
            get { return fias.Lon; }
            set
            {
                fias.Lon = value;
                OnPropertyChanged("Lon");
            }
        }
        public string Kladr
        {
            get { return fias.Kladr; }
            set
            {
                fias.Kladr = value;
                OnPropertyChanged("Kladr");
            }
        }
        public string OCATO
        {
            get { return fias.OCATO; }
            set
            {
                fias.OCATO = value;
                OnPropertyChanged("OCATO");
            }
        }
        public bool? Check
        {
            get { return fias.Check; }
            set
            {
                fias.Check = value;
                OnPropertyChanged("Check");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

        }

    }
}
