using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrystalCustoms2.model
{
    public class Settles
    {
        public int SettleId { get; set; }

        public int? InvoiceId { get; set; }

        public string SettleName { get; set; }

        public string SettleSerialnum { get; set; }

        public string SettleCycletime { get; set; }

        public string SettleShipdate { get; set; }

        public string SettleCleardate { get; set; }

        public string SettleWeight { get; set; }

        public string SettleWeightUnit { get; set; }

        public int? SettleRemit { get; set; }

        public int? SettleExpend { get; set; }

        public int? SettleBalance { get; set; }

        public string SettleBuy { get; set; }

        public string SettleSell { get; set; }

        public string SettleMblno { get; set; }

        public string SettleHblno { get; set; }

        public string SettleOwn { get; set; }

        public string SettleLoadport { get; set; }
        
        public string SettleArriveport { get; set; }

        public int SettleVolume { get; set; }

        public string SettleVolumeUnit { get; set; }

        public int SettleSIze { get; set; }

        public string SettleSizeUnit { get; set; }

        public DateTime SettleArriveDate { get; set; }

        public int SettleDuty { get; set; }

        public int SettleVat { get; set; }

        public int SettleVatrate { get; set; }

        public int SettleCommision { get; set; }

        public string SettleType { get; set;  }

        public string SettleShipno { get; set; }

        public int SettleCostsum { get; set; }

        public DateTime? SettleDatetime { get; set; }

        // Settles 모델 복사
        public void CopyData(Settles param)
        {
            this.SettleId = param.SettleId;
            this.InvoiceId = param.InvoiceId;
            this.SettleName = param.SettleName;
            this.SettleSerialnum = param.SettleSerialnum;
            this.SettleCycletime = param.SettleCycletime;
            this.SettleShipdate = param.SettleShipdate;
            this.SettleCleardate = param.SettleCleardate;
            this.SettleWeight = param.SettleWeight;
            this.SettleWeightUnit = param.SettleWeightUnit;
            this.SettleRemit = param.SettleRemit;
            this.SettleExpend = param.SettleExpend;
            this.SettleBalance = param.SettleBalance;
            this.SettleBuy = param.SettleBuy;
            this.SettleSell = param.SettleSell;
            this.SettleMblno = param.SettleMblno;
            this.SettleHblno = param.SettleHblno;
            this.SettleOwn = param.SettleOwn;
            this.SettleDatetime = param.SettleDatetime;
        }
    }
}
