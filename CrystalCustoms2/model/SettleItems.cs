using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrystalCustoms2.model
{
    public class SettleItems
    {
        public int SettleItemId { get; set; }

        public int SettleId { get; set; }

        public string SettleItemName { get; set; }

        public string SettleItemType { get; set; }

        public string SettleItemAmount { get; set; }

        public string SettleItemVat { get; set; }

        public DateTime? SettleItemDatetime { get; set; }

        // SettleItems 모델 복사
        public void CopyData(SettleItems param)
        {
            this.SettleItemId = param.SettleItemId;
            this.SettleId = param.SettleId;
            this.SettleItemName = param.SettleItemName;
            this.SettleItemType = param.SettleItemType;
            this.SettleItemAmount = param.SettleItemAmount;
            this.SettleItemVat = param.SettleItemVat;
            this.SettleItemDatetime = param.SettleItemDatetime;
        }
    }
}
