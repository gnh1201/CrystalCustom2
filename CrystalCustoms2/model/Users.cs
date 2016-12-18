using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrystalCustoms2.model
{
    public class Users
    {
        public int UserId { get; set; }

        public int? UserNo { get; set; }

        public int? AddrId { get; set; }

        public string UserName { get; set; }

        public string UserPassword { get; set; }

        public string UserLevel { get; set; }

        public string UserType { get; set; }

        public string UserGender { get; set; }

        public string UserBirth { get; set; }

        public string UserContent { get; set; }

        public string UserStatus { get; set; }

        public DateTime? UserDatetime { get; set; }

        public DateTime? UserLastLogin { get; set; }

        // Users 모델 복사
        public void CopyData(Users param)
        {
            this.UserId = param.UserId;
            this.UserNo = param.UserNo;
            this.AddrId = param.AddrId;
            this.UserName = param.UserName;
            this.UserPassword = param.UserPassword;
            this.UserLevel = param.UserLevel;
            this.UserType = param.UserType;
            this.UserGender = param.UserGender;
            this.UserBirth = param.UserBirth;
            this.UserContent = param.UserContent;
            this.UserStatus = param.UserStatus;
            this.UserDatetime = param.UserDatetime;
            this.UserLastLogin = param.UserLastLogin;
        }
    }
}
