//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfApp1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Servicii
    {
        public int Serivicii_ID { get; set; }
        public Nullable<int> CAMERA_ID { get; set; }
        public string ServiciiString { get; set; }
    
        public virtual Camera Camera { get; set; }
    }
}