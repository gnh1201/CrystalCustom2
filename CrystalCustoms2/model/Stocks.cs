using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrystalCustoms2.model
{
    public class Stocks
    {
        public int StockId { get; set; }

        public int? ProductId { get; set; }

        public string StockName { get; set; }

        public string StockTotalqty { get; set; }

        public DateTime? StockDatetime { get; set; }

        // Stocks 모델 복사
        public void CopyData(Stocks param)
        {
            this.StockId = param.StockId;
            this.ProductId = param.ProductId;
            this.StockName = param.StockName;
            this.StockTotalqty = param.StockTotalqty;
            this.StockDatetime = param.StockDatetime;
        }
    }
}
