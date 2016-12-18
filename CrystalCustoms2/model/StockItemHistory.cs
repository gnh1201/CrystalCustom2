using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrystalCustoms2.model
{
    public class StockItemHistory
    {
        public int StockItemHistoryId { get; set; }

        public int StockItemId { get; set; }

        public int StockHistoryId { get; set; }

        public string StockItemHistoryName { get; set; }

        public string StockItemHistoryType { get; set; }

        public int? StockItemHistoryChange { get; set; }

        public DateTime? StockItemHistoryDatetime { get; set; }

        // StockItemHistory 모델 복사
        public void CopyData(StockItemHistory param)
        {
            this.StockItemHistoryId = param.StockItemHistoryId;
            this.StockItemId = param.StockItemId;
            this.StockHistoryId = param.StockHistoryId;
            this.StockItemHistoryName = param.StockItemHistoryName;
            this.StockItemHistoryType = param.StockItemHistoryType;
            this.StockItemHistoryChange = param.StockItemHistoryChange;
            this.StockItemHistoryDatetime = param.StockItemHistoryDatetime;
        }
    }
}
