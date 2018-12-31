using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FixAddress
{
  public class FIASModel : INotifyPropertyChanged 
  {
    private int id;
    private string addr1;
    private string fias;
    private string fiasLevel;
    private string addr2;
    private decimal lat;
    private decimal lon;
    private string kladr;
    private string ocato;
    private bool? check;
    //private bool isEdited;

    public int ID
    {
      get { return id; }
      set
      {
        id = value;
        OnPropertyChanged("ID");
      }
    }
    public string Addr1
    {
      get { return addr1; }
      set
      {
        addr1 = value;
        OnPropertyChanged("Addr1");
      }
    }
    public string Fias
    {
      get { return fias; }
      set
      {
        fias = value;
        OnPropertyChanged("Fias");
      }
    }
    public string FiasLevel
    {
      get { return fiasLevel; }
      set
      {
        fiasLevel = value;
        OnPropertyChanged("FiasLevel");
      }
    }
    public string Addr2
    {
      get { return addr2; }
      set
      {
        addr2 = value;
        OnPropertyChanged("Addr2");
      }
    }
    public decimal Lat
    {
      get { return lat; }
      set
      {
        lat = value;
        OnPropertyChanged("Lat");
      }
    }
    public decimal Lon
    {
      get { return lon; }
      set
      {
        lon = value;
        OnPropertyChanged("Lon");
      }
    }
    public string Kladr
    {
      get { return kladr; }
      set
      {
        kladr = value;
        OnPropertyChanged("Kladr");
      }
    }
    public string OCATO
    {
      get { return ocato; }
      set
      {
        ocato = value;
        OnPropertyChanged("OCATO");
      }
    }
    public bool? Check
    {
      get { return check; }
      set
      {
        check = value;
        OnPropertyChanged("Check");
      }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged([CallerMemberName ] string prop="")
    {
      if (PropertyChanged != null)
        PropertyChanged(this, new PropertyChangedEventArgs(prop));
    }
  }
}
