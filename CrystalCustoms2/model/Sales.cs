using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrystalCustoms2.model
{
    public class Sales
    {
        public int SalesId { get; set; }

        public int? CustomerId { get; set; }

        public int? ProductId { get; set; }

        public int StockId { get; set; }

        public int? SalesQty { get; set; }

        public int? SalesUnitprice { get; set; }

        public int? SalesVat { get; set; }

        public float? SalesVatrate { get; set; }

        public int SalesCost { get; set; }

        public int SalesProfit { get; set; }

        public DateTime? SalesDatetime { get; set; }

        // Sales 모델 복사
        public void CopyData(Sales param)
        {
            this.SalesId = param.SalesId;
            this.CustomerId = param.CustomerId;
            this.ProductId = param.ProductId;
            this.StockId = param.StockId;
            this.SalesQty = param.SalesQty;
            this.SalesUnitprice = param.SalesUnitprice;
            this.SalesVat = param.SalesVat;
            this.SalesVatrate = param.SalesVatrate;
            this.SalesCost = param.SalesCost;
            this.SalesProfit = param.SalesProfit;
            this.SalesDatetime = param.SalesDatetime;
        }
    }
}
