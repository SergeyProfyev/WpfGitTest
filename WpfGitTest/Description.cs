using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixAddress
{
    /// <summary>
  /// 
  /// </summary>
  public class AddrList
  {
    public string Address { get; set; }
    public string FiasCode { get; set; }
    public string FiasLevel { get; set; }
    public string KladrCode { get; set; }
    public string Ocato { get; set; }
    public decimal Geo_Lat { get; set; }
    public decimal Geo_Lon { get; set; }

    public AddrList()
    {
      Address = "";
      FiasCode = "";
      FiasLevel = "";
      KladrCode = "";
      Ocato = "";
      Geo_Lat = 0;
      Geo_Lon = 0;
    }

  }
  /// <summary>
  /// 
  /// </summary>
  public class AList
  {
    public int id { get; set; }
    public string addr1 { get; set; }
    public string fias { get; set; }
    public string addr2 { get; set; }
    public bool? check { get; set; }
    public bool isEdited { get; set; }

    public AList()
    {
      id = 0;
      addr1 = "";
      fias = "";
      addr2 = "";
      check = false;
      isEdited = false;
    }
    //public AList(string s1, string s2, string s3)
    //{
    //  addr1 = s1;
    //  fias = s2;
    //  addr2 = s3;
    //  //check = false;
    //}
  }
}
