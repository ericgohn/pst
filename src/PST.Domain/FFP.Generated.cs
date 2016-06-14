//  ==============================================================
//   Copyright (c) 上海梓迅信息技术有限公司. All rights reserved.   
//  
//   File: FFP.Generated.cs
//   Author: Eric Gohn
//   Email: eric.gohn@outlook.com
//     
//  ==============================================================

using System;
using System.Runtime.Serialization;

namespace PST.Domain
{
    [DataContract]
    public partial class FFP
    {
        [DataMember]
        public Guid Id { get; set; }
    
        [DataMember]
        public string Series { get; set; }
    
        [DataMember]
        public string Model_Name { get; set; }
    
        [DataMember]
        public string Business_No { get; set; }
    
        [DataMember]
        public string Sales_Route { get; set; }
    
        [DataMember]
        public string PNO { get; set; }
    
        [DataMember]
        public string Sales_PNO { get; set; }
    
        [DataMember]
        public double? Sub_Information { get; set; }
    
        [DataMember]
        public string Customer_Name { get; set; }
    
        [DataMember]
        public string Rank { get; set; }
    
        [DataMember]
        public double? Rate { get; set; }
    
        [DataMember]
        public string ACC_Code { get; set; }
    
        [DataMember]
        public string Sales_Staff { get; set; }
    
        [DataMember]
        public double? Order_Division { get; set; }
    
        [DataMember]
        public DateTime? Shipped_Month { get; set; }
    
        [DataMember]
        public double? Shipped_QTY { get; set; }
    
        [DataMember]
        public double? Shipped_Qty2 { get; set; }
    
        [DataMember]
        public string F_FP_PNO { get; set; }
    
        [DataMember]
        public string F_FP_Type { get; set; }
    
        [DataMember]
        public string CIG_Name { get; set; }
    
        [DataMember]
        public string CIC_Name { get; set; }
    
        [DataMember]
        public int FFPSetId { get; set; }
    
        [DataMember]
        public int Seq { get; set; }
    
    }
}
