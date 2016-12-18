using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrystalCustoms2.model
{
    public class InvoiceItems
    {
        public int InvoiceItemId { get; set; }

        public int InvoiceId { get; set; }

        public int StockId { get; set; }

        public string InvoiceItemDesc { get; set; }

        public int? InvoiceItemQty { get; set; }

        public int? InvoiceItemPrice { get; set; }

        public string InvoiceItemUnit { get; set; }

        public int? InvoiceItemAmount { get; set; }

        public int? InvoiceItemVat { get; set; }

        public float? InvoiceItemVatrate { get; set; }

        public DateTime? InvoiceItemDatetime { get; set; }

        // InvoiceItems 모델 복사
        public void CopyData(InvoiceItems param)
        {
            this.InvoiceItemId = param.InvoiceItemId;
            this.InvoiceId = param.InvoiceId;
            this.StockId = param.StockId;
            this.InvoiceItemDesc = param.InvoiceItemDesc;
            this.InvoiceItemQty = param.InvoiceItemQty;
            this.InvoiceItemPrice = param.InvoiceItemPrice;
            this.InvoiceItemUnit = param.InvoiceItemUnit;
            this.InvoiceItemAmount = param.InvoiceItemAmount;
            this.InvoiceItemVat = param.InvoiceItemVat;
            this.InvoiceItemVatrate = param.InvoiceItemVatrate;
            this.InvoiceItemDatetime = param.InvoiceItemDatetime;
        }
    }
}
