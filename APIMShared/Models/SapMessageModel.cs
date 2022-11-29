using System;
using System.Collections.Generic;

namespace APIMShared.Models
{
    public class SapMessageModel
    {
        public Document d { get; set; }
    }

    public class Document
    {
        public Metadata __metadata { get; set; }
        public string CreatedBy { get; set; }
        public string UnloadPt { get; set; }
        public string YyIcd { get; set; }
        public string DocClass { get; set; }
        public string RefdocCat { get; set; }
        public object PriceDate { get; set; }
        public string Salesdocumentin { get; set; }
        public string Refdoctype { get; set; }
        public string RefDoc { get; set; }
        public string DocType { get; set; }
        public string SalesOrg { get; set; }
        public string DistrChan { get; set; }
        public string Division { get; set; }
        public DateTime ReqDateH { get; set; }
        public object PurchDate { get; set; }
        public string PoMethod { get; set; }
        public string PurchNoC { get; set; }
        public string Pmnttrms { get; set; }
        public string DlvBlock { get; set; }
        public string BillBlock { get; set; }
        public string ShipCond { get; set; }
        public string Currency { get; set; }
        public string Incoterms1 { get; set; }
        public string Incoterms2 { get; set; }
        public string DeliveryPriority { get; set; }
        public string Contact { get; set; }
        public HEADERITEMNAV HEADER_ITEM_NAV { get; set; }
        public HEADERRESPONSENAV HEADER_RESPONSE_NAV { get; set; }
        public HEADERPARTNERNAV HEADER_PARTNER_NAV { get; set; }
        public HEADERTEXTNAV HEADER_TEXT_NAV { get; set; }
    }

    public class Deferred
    {
        public string uri { get; set; }
    }

    public class HEADERITEMNAV
    {
        public List<Result> results { get; set; }
    }

    public class HEADERPARTNERNAV
    {
        public List<Result> results { get; set; }
    }

    public class HEADERRESPONSENAV
    {
        public List<Result> results { get; set; }
    }

    public class HEADERTEXTNAV
    {
        public Deferred __deferred { get; set; }
    }

    public class Metadata
    {
        public string id { get; set; }
        public string uri { get; set; }
        public string type { get; set; }
    }

    public class Result
    {
        public Metadata __metadata { get; set; }
        public string CreatedBy { get; set; }
        public string RefDoc { get; set; }
        public string DlvTime { get; set; }
        public string RefDocCa { get; set; }
        public object PriceDate { get; set; }
        public string RefDocIt { get; set; }
        public string ReqQty { get; set; }
        public string Salesdocumentin { get; set; }
        public string TargetVal { get; set; }
        public string Currency { get; set; }
        public string ItmNumber { get; set; }
        public string SalesUnit { get; set; }
        public string Material { get; set; }
        public string Batch { get; set; }
        public string DlvGroup { get; set; }
        public string ReasonRej { get; set; }
        public string Plant { get; set; }
        public string Route { get; set; }
        public string DlvTimeCond { get; set; }
        public string Timestamp { get; set; }
        public string DocNumber { get; set; }
        public string Status { get; set; }
        public string StatusText { get; set; }
        public string HttpStatus { get; set; }
        public string Message { get; set; }
        public string PartnRole { get; set; }
        public string PartnNumb { get; set; }
        public string UnloadPt { get; set; }
    }
}