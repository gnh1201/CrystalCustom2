using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrystalCustoms2.model
{
    public class SalesDetails
    {
        public int SalesDetailId { get; set; }

        public int SalesId { get; set; }

        public string SalesDetailName { get; set; }

        public string SalesDetailType { get; set; }

        public string SalesDetailAmount { get; set; }

        public DateTime? SalesDetailDatetime { get; set; }

        // SalesDetails 모델 복사
        public void CopyData(SalesDetails param)
        {
            this.SalesDetailId = param.SalesDetailId;
            this.SalesId = param.SalesId;
            this.SalesDetailName = param.SalesDetailName;
            this.SalesDetailType = param.SalesDetailType;
            this.SalesDetailAmount = param.SalesDetailAmount;
            this.SalesDetailDatetime = param.SalesDetailDatetime;
        }
    }
}
