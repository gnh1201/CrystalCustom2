using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CrystalCustoms2.model.KoreaCustomsModel
{
    // 화물통관 전체정보
    [XmlRoot("cargCsclPrgsInfoQryRtnVo")]
    public class cargCsclPrgsInfoQryRtnVo
    {
        [XmlElement("cargCsclPrgsInfoQryVo")]
        public List<cargCsclPrgsInfoQryVo> cargCsclPrgsInfoQryVo { get; set; }

        [XmlElement("cargCsclPrgsInfoDtlQryVo")]
        public List<cargCsclPrgsInfoDtlQryVo> cargCsclPrgsInfoDtlQryVo { get; set; }
    }

    // 화물통관 기본정보
    public class cargCsclPrgsInfoQryVo
    {
        [XmlElement("csclPrgsStts")]
        public string csclPrgsStts { get; set; }
        [XmlElement("vydf")]
        public string vydf { get; set; }
        [XmlElement("prnm")]
        public string prnm { get; set; }
        [XmlElement("ldprCd")]
        public string ldprCd { get; set; }
        [XmlElement("shipNat")]
        public string shipNat { get; set; }
        [XmlElement("blPt")]
        public string blPt { get; set; }
        [XmlElement("dsprNm")]
        public string dsprNm { get; set; }
        [XmlElement("etprDt")]
        public string etprDt { get; set; }
        [XmlElement("prgsStCd")]
        public string prgsStCd { get; set; }
        [XmlElement("msrm")]
        public string msrm { get; set; }
        [XmlElement("wghtUt")]
        public string wghtUt { get; set; }
        [XmlElement("dsprCd")]
        public string dsprCd { get; set; }
        [XmlElement("cntrGcnt")]
        public string cntrGcnt { get; set; }
        [XmlElement("cargTp")]
        public string cargTp { get; set; }
        [XmlElement("shcoFlcoSgn")]
        public string shcoFlcoSgn { get; set; }
        [XmlElement("pckGcnt")]
        public string pckGcnt { get; set; }
        [XmlElement("etprCstm")]
        public string etprCstm { get; set; }
        [XmlElement("shipNm")]
        public string shipNm { get; set; }
        [XmlElement("hblNo")]
        public string hblNo { get; set; }
        [XmlElement("prcsDttm")]
        public string prcsDttm { get; set; }
        [XmlElement("spcnCargCd")]
        public string spcnCargCd { get; set; }
        [XmlElement("ttwg")]
        public string ttwg { get; set; }
        [XmlElement("ldprNm")]
        public string ldprNm { get; set; }
        [XmlElement("mtTrgtCargYnNm")]
        public string mtTrgtCargYnNm { get; set; }
        [XmlElement("cargMtNo")]
        public string cargMtNo { get; set; }
        [XmlElement("cntrNo")]
        public string cntrNo { get; set; }
        [XmlElement("mblNo")]
        public string mblNo { get; set; }
        [XmlElement("blPtNm")]
        public string blPtNm { get; set; }
        [XmlElement("lodCntyCd")]
        public string lodCntyCd { get; set; }
        [XmlElement("prgsStts")]
        public string prgsStts { get; set; }
        [XmlElement("shcoFlco")]
        public string shcoFlco { get; set; }
        [XmlElement("pckUt")]
        public string pckUt { get; set; }
        [XmlElement("shipNatNm")]
        public string shipNatNm { get; set; }
        [XmlElement("agnc")]
        public string agnc { get; set; }
    }

    // 화물통관 진행이력
    public class cargCsclPrgsInfoDtlQryVo {
        [XmlElement("shedNm")]
        public string shedNm { get; set; }
        [XmlElement("prcsDttm")]
        public string prcsDttm { get; set; }
        [XmlElement("dclrNo")]
        public string dclrNo { get; set; }
        [XmlElement("rlbrDttm")]
        public string rlbrDttm { get; set; }
        [XmlElement("wght")]
        public string wght { set; get; }
        [XmlElement("rlbrBssNo")]
        public string rlbrBssNo { set; get; }
        [XmlElement("bfhnGdncCn")]
        public string bfhnGdncCn { set; get; }
        [XmlElement("wghtUt")]
        public string wghtUt { set; get; }
        [XmlElement("pckGcnt")]
        public string pckGcnt { set; get; }
        [XmlElement("cargTrcnRelaBsopTpcd")]
        public string cargTrcnRelaBsopTpcd { set; get; }
        [XmlElement("pckUt")]
        public string pckUt { set; get; }
        [XmlElement("rlbrCn")]
        public string rlbrCn { set; get; }
        [XmlElement("shedSgn")]
        public string shedSgn { set; get; }
    }
}
