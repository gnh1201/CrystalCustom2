using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrystalCustoms2.model
{
    public class StockHistory
    {
        public int StockHistoryId { get; set; }

        public int StockId { get; set; }

        public int CustomerId { get; set; }

        public string StockHistoryName { get; set; }

        public string StockHistoryType { get; set; }

        public int? StockHistoryChange { get; set; }

        public DateTime? StockHistoryDatetime { get; set; }

        // StockHistory 모델 복사
        public void CopyData(StockHistory param)
        {
            this.StockHistoryId = param.StockHistoryId;
            this.StockId = param.StockId;
            this.CustomerId = param.CustomerId;
            this.StockHistoryName = param.StockHistoryName;
            this.StockHistoryType = param.StockHistoryType;
            this.StockHistoryChange = param.StockHistoryChange;
            this.StockHistoryDatetime = param.StockHistoryDatetime;
        }
    }
}
