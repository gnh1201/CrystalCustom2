using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrystalCustoms2.model
{
    public class StockItems
    {
        public int StockItemId { get; set; }

        public int StockId { get; set; }

        public string StockItemName { get; set; }

        public string StockItemFirstqty { get; set; }

        public int? StockItemQty { get; set; }

        public int? StockItemUnitprice { get; set; }

        public DateTime? StockItemTimelimit { get; set; }

        public DateTime? StockItemDatetime { get; set; }

        // StockItems 모델 복사
        public void CopyData(StockItems param)
        {
            this.StockItemId = param.StockItemId;
            this.StockId = param.StockId;
            this.StockItemName = param.StockItemName;
            this.StockItemFirstqty = param.StockItemFirstqty;
            this.StockItemQty = param.StockItemQty;
            this.StockItemUnitprice = param.StockItemUnitprice;
            this.StockItemTimelimit = param.StockItemTimelimit;
            this.StockItemDatetime = param.StockItemDatetime;
        }
    }
}
