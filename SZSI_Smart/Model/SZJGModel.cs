using YB.FrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Client.Model
{
    public class SZJGModel
    {
        public SZJG_Key_Model key_mod { get; set; }
        public SZJG_Type_Enum szjgtype { get; set; }
        public string data { get; set; }

    }

    public class SZJGInModel
    {
        public string ZHMC { get; set; }
        public string channelId { get; set; }
        public string accessKey { get; set; }
        public string secretKey { get; set; }
        public string publicKey { get; set; }
        public string ZHCode { get; set; }
        public string szjgtype { get; set; }
        public string data { get; set; }
    }
}