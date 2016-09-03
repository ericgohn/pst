//  ==============================================================
//   Copyright (c) 上海梓迅信息技术有限公司. All rights reserved.   
//  
//   File: SummarizedFFP.cs
//   Author: Eric Gohn
//   Email: eric.gohn@outlook.com
//     
//  ==============================================================

using System;
using System.Runtime.Serialization;

namespace PST.Domain
{
    [DataContract]
    public class SummarizedFFP
    {
        [DataMember]
        public string PNO { get; set; }

        [DataMember]
        public int ItemCount { get; set; }

        [DataMember]
        public double ShippedQty { get; set; }

        [DataMember]
        public DateTime ShippedMonth { get; set; }

        [DataMember]
        public int Factor { get; set; }

        [DataMember]
        public string CustomerName { get; set; }
    }
}