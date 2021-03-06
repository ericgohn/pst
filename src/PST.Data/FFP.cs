//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PST.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class FFP
    {
        public System.Guid Id { get; set; }
        public string Series { get; set; }
        public string Model_Name { get; set; }
        public string Business_No { get; set; }
        public string Sales_Route { get; set; }
        public string PNO { get; set; }
        public string Sales_PNO { get; set; }
        public Nullable<double> Sub_Information { get; set; }
        public string Customer_Name { get; set; }
        public string Rank { get; set; }
        public Nullable<double> Rate { get; set; }
        public string ACC_Code { get; set; }
        public string Sales_Staff { get; set; }
        public Nullable<double> Order_Division { get; set; }
        public Nullable<System.DateTime> Shipped_Month { get; set; }
        public Nullable<double> Shipped_QTY { get; set; }
        public Nullable<double> Shipped_Qty2 { get; set; }
        public string F_FP_PNO { get; set; }
        public string F_FP_Type { get; set; }
        public string CIG_Name { get; set; }
        public string CIC_Name { get; set; }
        public int FFPSetId { get; set; }
        public int Seq { get; set; }
        public bool Dispatched { get; set; }
        public double ResAmount { get; set; }
    
        public virtual FFPSet FFPSet { get; set; }
    }
}
