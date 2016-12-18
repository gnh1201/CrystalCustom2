using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrystalCustoms2.model
{
    public class Apikeys 
    {
        public int KeyId { get; set; }

        public string KeyType { get; set; }

        public string KeyName { get; set; }

        public string KeyDesc { get; set; }

        public string KeyCode { get; set; }

        public int KeyCount { get; set; }

        public DateTime KeyLastused { get; set; }

        public DateTime KeyDatetime { get; set; }

        // Apikeys 모델 복사
        public void CopyData(Apikeys param)
        {
            this.KeyId = param.KeyId;
            this.KeyType = param.KeyType;
            this.KeyName = param.KeyName;
            this.KeyDesc = param.KeyDesc;
            this.KeyCode = param.KeyCode;
            this.KeyDatetime = param.KeyDatetime;
        }
    }
}
