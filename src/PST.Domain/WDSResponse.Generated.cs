//  ==============================================================
//   Copyright (c) 上海梓迅信息技术有限公司. All rights reserved.   
//  
//   File: WDSResponse.Generated.cs
//   Author: Eric Gohn
//   Email: eric.gohn@outlook.com
//     
//  ==============================================================

using System;
using System.Runtime.Serialization;

namespace PST.Domain
{
    [DataContract]
    public partial class WDSResponse
    {
        [DataMember]
        public Guid Id { get; set; }
    
        [DataMember]
        public string Sub_Family { get; set; }
    
        [DataMember]
        public string Series { get; set; }
    
        [DataMember]
        public string Brand_name { get; set; }
    
        [DataMember]
        public string T_R { get; set; }
    
        [DataMember]
        public string PM { get; set; }
    
        [DataMember]
        public string Category { get; set; }
    
        [DataMember]
        public string KUBUN { get; set; }
    
        [DataMember]
        public string Area { get; set; }
    
        [DataMember]
        public string Supply_Route { get; set; }
    
        [DataMember]
        public string EURO_Country { get; set; }
    
        [DataMember]
        public string GSKU { get; set; }
    
        [DataMember]
        public string G_Frame { get; set; }
    
        [DataMember]
        public string PNO { get; set; }
    
        [DataMember]
        public string Ship_Style { get; set; }
    
        [DataMember]
        public string InHouse_ODM { get; set; }
    
        [DataMember]
        public string Prod { get; set; }
    
        [DataMember]
        public string FCS_date { get; set; }
    
        [DataMember]
        public string Customer { get; set; }
    
        [DataMember]
        public string Status { get; set; }
    
        [DataMember]
        public string Cut_off { get; set; }
    
        [DataMember]
        public DateTime? Cut_off_date { get; set; }
    
        [DataMember]
        public string Month { get; set; }
    
        [DataMember]
        public string Week { get; set; }
    
        [DataMember]
        public DateTime? Date { get; set; }
    
        [DataMember]
        public double? Sales_Demand_Previous { get; set; }
    
        [DataMember]
        public double? Sales_Demand_Current_a_ { get; set; }
    
        [DataMember]
        public double? HQ_Original_Previous { get; set; }
    
        [DataMember]
        public double? HQ_Original_Current_g_ { get; set; }
    
        [DataMember]
        public double? HQ_Forecast_Previous { get; set; }
    
        [DataMember]
        public double? PSI_0506__b_ { get; set; }
    
        [DataMember]
        public double? CP_Simulation_Previous { get; set; }
    
        [DataMember]
        public double? CP_Simulation_Current { get; set; }
    
        [DataMember]
        public double? HQ_Simulation_Previous { get; set; }
    
        [DataMember]
        public double? HQ_Simulation_Current { get; set; }
    
        [DataMember]
        public double? Sales_Response_Previous_e_ { get; set; }
    
        [DataMember]
        public double? Sales_Response_Current_f_ { get; set; }
    
        [DataMember]
        public double? Pullin_Response_Previous { get; set; }
    
        [DataMember]
        public double? Pullin_Response_Current { get; set; }
    
        [DataMember]
        public double? MFG_Response_Previous_c_ { get; set; }
    
        [DataMember]
        public double? WDS_Response_0509__d_ { get; set; }
    
        [DataMember]
        public double? d_a { get; set; }
    
        [DataMember]
        public double? d_b { get; set; }
    
        [DataMember]
        public double? d_c { get; set; }
    
        [DataMember]
        public double? f_e { get; set; }
    
        [DataMember]
        public double? f_g { get; set; }
    
        [DataMember]
        public string Segment { get; set; }
    
        [DataMember]
        public string CPU { get; set; }
    
        [DataMember]
        public string LCD { get; set; }
    
        [DataMember]
        public string HDD { get; set; }
    
        [DataMember]
        public string Communication { get; set; }
    
        [DataMember]
        public string Mini_PCI { get; set; }
    
        [DataMember]
        public string Bluetooth { get; set; }
    
        [DataMember]
        public string Battery { get; set; }
    
        [DataMember]
        public string OS { get; set; }
    
        [DataMember]
        public string Pointing_Device { get; set; }
    
        [DataMember]
        public string Graphics_Controller { get; set; }
    
        [DataMember]
        public string Indent { get; set; }
    
        [DataMember]
        public string Recovery { get; set; }
    
        [DataMember]
        public string ODD { get; set; }
    
        [DataMember]
        public string Speaker { get; set; }
    
        [DataMember]
        public string TV_tuner { get; set; }
    
        [DataMember]
        public string Warranty { get; set; }
    
        [DataMember]
        public string Remote_Control { get; set; }
    
        [DataMember]
        public string Office { get; set; }
    
        [DataMember]
        public string KeyBoard { get; set; }
    
        [DataMember]
        public string OS_Language { get; set; }
    
        [DataMember]
        public string Warranty_Extension_ { get; set; }
    
        [DataMember]
        public string RecycleLabel { get; set; }
    
        [DataMember]
        public string DVD_Region_Code { get; set; }
    
        [DataMember]
        public string Energy_Star_Label { get; set; }
    
        [DataMember]
        public string RecoveryCD { get; set; }
    
        [DataMember]
        public string Memory_Slot1 { get; set; }
    
        [DataMember]
        public string Memory_Slot2 { get; set; }
    
        [DataMember]
        public string AC_Cable { get; set; }
    
        [DataMember]
        public string C2nd_HDD { get; set; }
    
        [DataMember]
        public string LAN { get; set; }
    
        [DataMember]
        public string Button { get; set; }
    
        [DataMember]
        public string Recovery_HDD { get; set; }
    
        [DataMember]
        public string Recovery_Media { get; set; }
    
        [DataMember]
        public string OnSite_Service { get; set; }
    
        [DataMember]
        public string Color_Variation { get; set; }
    
        [DataMember]
        public string Mouse { get; set; }
    
        [DataMember]
        public string Security { get; set; }
    
        [DataMember]
        public string Generation { get; set; }
    
        [DataMember]
        public string C3G { get; set; }
    
        [DataMember]
        public string C2nd_TV_Tuner { get; set; }
    
        [DataMember]
        public string Windows_Sticker { get; set; }
    
        [DataMember]
        public string Connector { get; set; }
    
        [DataMember]
        public string Web_Camera_Mic { get; set; }
    
        [DataMember]
        public string Disk_Cache { get; set; }
    
        [DataMember]
        public string Card_Slot { get; set; }
    
        [DataMember]
        public string KeyBoard_Color { get; set; }
    
        [DataMember]
        public string Target_Customer { get; set; }
    
        [DataMember]
        public string Pen_Device { get; set; }
    
        [DataMember]
        public string OS_Category { get; set; }
    
        [DataMember]
        public string Backend_Processor { get; set; }
    
        [DataMember]
        public string Anti_Virus_SW { get; set; }
    
        [DataMember]
        public string Energy_Star_Label_ODM_ { get; set; }
    
        [DataMember]
        public string Micro_SATA_SSD_for_Dedicated_SSD_Slot { get; set; }
    
        [DataMember]
        public string Flush_Screen { get; set; }
    
        [DataMember]
        public string Ambient_Sensor { get; set; }
    
        [DataMember]
        public string PCBA_BTO_Combination { get; set; }
    
        [DataMember]
        public string External_IR_Transceiver { get; set; }
    
        [DataMember]
        public string KeyBoard_BTO_Combination { get; set; }
    
        [DataMember]
        public string Discrete_Graphics_Controller { get; set; }
    
        [DataMember]
        public string Chipset { get; set; }
    
        [DataMember]
        public string Wireless_Device { get; set; }
    
        [DataMember]
        public string Memory_Slot3 { get; set; }
    
        [DataMember]
        public string Brand_No { get; set; }
    
        [DataMember]
        public string Product_Category { get; set; }
    
        [DataMember]
        public string Importer { get; set; }
    
        [DataMember]
        public string Special_Bundle { get; set; }
    
        [DataMember]
        public string Wireless_Display { get; set; }
    
        [DataMember]
        public string LTE { get; set; }
    
        [DataMember]
        public string Dock { get; set; }
    
        [DataMember]
        public string MAC_address_sticker { get; set; }
    
        [DataMember]
        public string Web_Camera_Mic_Back_ { get; set; }
    
        [DataMember]
        public string Memory_Slot4 { get; set; }
    
        [DataMember]
        public string AC_Plug_Type { get; set; }
    
        [DataMember]
        public string Carry_Case { get; set; }
    
        [DataMember]
        public string Package { get; set; }
    
        [DataMember]
        public string SmallParts { get; set; }
    
        [DataMember]
        public string MFGInfo { get; set; }
    
        [DataMember]
        public string Antenna { get; set; }
    
        [DataMember]
        public string Keyboard_TAIS { get; set; }
    
        [DataMember]
        public string Warranty_ODM_ { get; set; }
    
        [DataMember]
        public string Recovery_CD_ODM_ { get; set; }
    
        [DataMember]
        public string LAN_ODM_ { get; set; }
    
        [DataMember]
        public string PackageL { get; set; }
    
        [DataMember]
        public string AC_Adaptor { get; set; }
    
        [DataMember]
        public string RatingLabel { get; set; }
    
        [DataMember]
        public string Remote_Control_STC_ { get; set; }
    
        [DataMember]
        public string Remote_Control_TAIS { get; set; }
    
        [DataMember]
        public string PCB { get; set; }
    
        [DataMember]
        public string Country_Pack { get; set; }
    
        [DataMember]
        public string KeyBoard_Dock { get; set; }
    
        [DataMember]
        public string MediaBridgeSlot { get; set; }
    
        [DataMember]
        public string Indent1 { get; set; }
    
        [DataMember]
        public string Indent2 { get; set; }
    
        [DataMember]
        public string Security_Frame { get; set; }
    
        [DataMember]
        public string Security_PCBA { get; set; }
    
        [DataMember]
        public string Security_FP { get; set; }
    
        [DataMember]
        public string KeyBoard_FP { get; set; }
    
        [DataMember]
        public int FFPSetId { get; set; }
    
        [DataMember]
        public int Seq { get; set; }
    
        [DataMember]
        public bool Dispatched { get; set; }
    
    }
}
