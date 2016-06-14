//  ==============================================================
//   Copyright (c) 上海梓迅信息技术有限公司. All rights reserved.   
//  
//   File: FFPSet.Generated.cs
//   Author: Eric Gohn
//   Email: eric.gohn@outlook.com
//     
//  ==============================================================

using System;
using System.Runtime.Serialization;

namespace PST.Domain
{
    [DataContract]
    public partial class FFPSet
    {
        [DataMember]
        public int Id { get; set; }
    
        [DataMember]
        public string Name { get; set; }
    
    }
}
