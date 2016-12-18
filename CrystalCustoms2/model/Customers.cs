using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrystalCustoms2.model
{
    public class Customers
    {
        public int CustomerId { get; set; }

        public int UserId { get; set; }

        public string CustomerName { get; set; }

        public DateTime? CustomerDatetime { get; set; }

        // Customers 모델 복사
        public void CopyData(Customers param)
        {
            this.CustomerId = param.CustomerId;
            this.UserId = param.UserId;
            this.CustomerName = param.CustomerName;
            this.CustomerDatetime = param.CustomerDatetime;
        }
    }
}
