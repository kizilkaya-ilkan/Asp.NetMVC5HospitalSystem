//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hospital.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Users
    {
        public int ID { get; set; }
        public string AD { get; set; }
        public string SOYAD { get; set; }
        public string BÖLÜM { get; set; }
        public Nullable<int> YETKİDERECE { get; set; }
        public int ANAHTAR { get; set; }
        public string GÖREVİ { get; set; }
        public string TELNO { get; set; }
        public string TCNO { get; set; }
        public string ADRES { get; set; }
        public Nullable<byte> TİP { get; set; }
    }
}