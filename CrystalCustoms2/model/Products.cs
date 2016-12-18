using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrystalCustoms2.model
{
    public class Products
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string ProductStandard { get; set; }

        public DateTime? ProductDatetime { get; set; }

        // Products 모델 복사
        public void CopyData(Products param)
        {
            this.ProductId = param.ProductId;
            this.ProductName = param.ProductName;
            this.ProductStandard = param.ProductStandard;
            this.ProductDatetime = param.ProductDatetime;
        }
    }
}
