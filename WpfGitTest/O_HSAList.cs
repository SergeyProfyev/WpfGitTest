//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FixAddress
{
    using System;
    using System.Collections.Generic;
    
    public partial class O_HSAList
    {
        public int ID { get; set; }
        public Nullable<int> HSAID { get; set; }
        public string Address { get; set; }
        public string KladrCode { get; set; }
        public string FiasCode { get; set; }
        public string Ocato { get; set; }
        public Nullable<decimal> Geo_Lat { get; set; }
        public Nullable<decimal> Geo_Lon { get; set; }
        public Nullable<bool> Check { get; set; }
        public Nullable<bool> Unknown { get; set; }
    }
}
