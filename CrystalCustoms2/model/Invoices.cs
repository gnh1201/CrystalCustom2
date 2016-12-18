using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrystalCustoms2.model
{
    public class Invoices
    {
        public int InvoiceId { get; set; }

        public string InvoiceName { get; set; }

        public string InvoiceCurrency { get; set; }

        public int? InvoiceAmount { get; set; }

        public int? InvoiceDomesticAmount { get; set; }

        public DateTime? InvoiceDatetime { get; set; }

        // Invoices 모델 복사
        public void CopyData(Invoices param)
        {
            this.InvoiceId = param.InvoiceId;
            this.InvoiceName = param.InvoiceName;
            this.InvoiceCurrency = param.InvoiceCurrency;
            this.InvoiceAmount = param.InvoiceAmount;
            this.InvoiceDomesticAmount = param.InvoiceDomesticAmount;
            this.InvoiceDatetime = param.InvoiceDatetime;
        }
    }
}
