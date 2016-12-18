using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrystalCustoms2.model
{
    public class Addresses
    {
        public int AddrId { get; set; }

        public int UserId { get; set; }

        public string AddrType { get; set; }

        public string AddrName { get; set; }

        public string AddrZipcode1 { get; set; }

        public string AddrZipcode2 { get; set; }

        public string AddrLine1 { get; set; }

        public string AddrLine2 { get; set; }

        public string AddrLine3 { get; set; }

        public string AddrLine4 { get; set; }

        public string AddrTel { get; set; }

        public string AddrPhone { get; set; }

        public string AddrFax { get; set; }

        public string AddrEmail { get; set; }

        public string AddrContent { get; set; }

        public string AddrCountrycode { get; set; }

        public int? AddrDefault { get; set; }

        public DateTime? AddrDatetime { get; set; }

        // Addresses 모델 복사
        public void CopyData(Addresses param)
        {
            this.AddrId = param.AddrId;
            this.UserId = param.UserId;
            this.AddrType = param.AddrType;
            this.AddrName = param.AddrName;
            this.AddrZipcode1 = param.AddrZipcode1;
            this.AddrZipcode2 = param.AddrZipcode2;
            this.AddrLine1 = param.AddrLine1;
            this.AddrLine2 = param.AddrLine2;
            this.AddrLine3 = param.AddrLine3;
            this.AddrLine4 = param.AddrLine4;
            this.AddrTel = param.AddrTel;
            this.AddrPhone = param.AddrPhone;
            this.AddrFax = param.AddrFax;
            this.AddrEmail = param.AddrEmail;
            this.AddrContent = param.AddrContent;
            this.AddrCountrycode = param.AddrCountrycode;
            this.AddrDefault = param.AddrDefault;
            this.AddrDatetime = param.AddrDatetime;
        }
    }
}
