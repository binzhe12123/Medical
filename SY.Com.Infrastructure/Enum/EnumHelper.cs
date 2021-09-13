using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SY.Com.Infrastructure
{
   public static class EnumHelper
    {
        public enum PayType
        {
            WX_SCAN = 1
        }

        public enum AppType
        {
            WXPay = 1,
            ALIPay = 2
        }
    }
}
