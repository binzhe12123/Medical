using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SY.Com.Infrastructure
{
    public class ThirdModel
    {
    }

    /// <summary>
    /// 通联扫码支付我方传前后端传递参数
    /// </summary>
    public class ThirdTLScanPayOurModel
    {
        public long ZHID { get; set; }
        public long MZBH { get; set; }
        public string money { get; set; }
        public string payway { get; set; }
        public string key { get; set; }
        public string authcode { get; set; }

    }

    /// <summary>
    /// 通联扫码支付第三方入参
    /// </summary>
    public class ThirdTLScanPayInModel
    {
        public string orgid { get; set; }// 机构号 代为发起交易的机构商户号 否	15	 
        public string cusid { get; set; }//商户号 平台分配的商户号 否	15	 
        public string appid { get; set; }// 应用ID    平台分配的APPID 否	8	 
        public string version { get; set; }// 版本号 接口版本号 可	2	默认填11
        public string randomstr { get; set; }//   随机字符串 商户自行生成的随机字符串    否	32	 
        public string trxamt { get; set; }// 交易金额    单位为分 否	15	 
        public string reqsn { get; set; }// 商户交易单号  商户的交易订单号 否	32	保证商户平台唯一
        public string body { get; set; }//    订单标题 订单商品名称，为空则以商户名作为商品名称 是	100	最大100个字节(50个中文字符)
        public string remark { get; set; }// 备注  备注信息 是	160	 
        public string authcode { get; set; }// 支付授权码   如微信,支付宝,银联的付款二维码 否	32	 
        public string goods_tag { get; set; }// 订单优惠标记  订单优惠标记，用于区分订单是否可以享受优惠，字段内容在微信后台配置券时进行设置，说明详见代金券或立减优惠 是	32	仅对微信支付有效
        public string benefitdetail { get; set; }//   优惠信息 Benefitdetail的json字符串, 注意是String填写格式详见附录5.8	是	-	微信单品优惠支付宝智慧门店银联云闪付单品优惠
        public string chnlstoreid { get; set; }// 渠道门店编号 商户在支付渠道端的门店编号   是例如对于支付宝支付，支付宝门店编号对于微信支付，微信门店编号
        public string subbranch { get; set; }//   门店号 是	4	 
        public string extendparams { get; set; }// 拓展参数    json字符串，注意是String一般用于渠道的活动参数填写           参考5.9拓展参数附录说明
        public string idno { get; set; }//    证件号 实名交易必填.填了此字段就会验证证件号和姓名  是   32	暂只支持支付宝支付
        public string truename { get; set; }//    付款人真实姓名 实名交易必填.填了此字段就会验证证件号和姓名 是	32	暂只支持支付宝支付
        public string asinfo { get; set; }//  分账信息 格式:cusid:type:amount; cusid:type:amount…其中cusid:接收分账的通联商户号type分账类型（01：按金额  02：按比率）如果分账类型为02，则分账比率为0.5表示50%。如果分账类型为01，则分账金额以元为单位表示 是	1024	开通此业务需开通分账配置
        public string fqnum { get; set; }//   花呗分期	6-花呗分期6期12-花呗分期12期 是	4	暂只支持支付宝花呗分期
        public string signtype { get; set; }//    签名方式 是	8	MD5RSA不填默认MD5
        public string sign { get; set; }//    签名 详见安全规范  否	32	
        public long ZHID { get; set; }
        public long MZBH { get; set; }
        public string Name { get; set; }
        public int JE { get; set; }
        public string BHLX { get; set; }
        public string paytype { get; set; }
    }



    /// <summary>
    /// 通联扫码支付第三方出参
    /// </summary>
    public class ThirdTLScanPayOutModel
    {
        public string retcode { get; set; } //返回码SUCCESS/FAIL 否	8此字段是通信标识，非交易结果，交易是否成功需要查看trxstatus来判断
        public string retmsg { get; set; }  //返回码说明 是	100
        public string cusid { get; set; }// 商户号 平台分配的商户号 否	15	 
        public string appid { get; set; }// 应用ID    平台分配的APPID 否	8	 
        public string trxid { get; set; }// 交易单号    收银宝平台的交易流水号 否	20	 
        public string chnltrxid { get; set; }// 渠道平台交易单号    例如微信,支付宝平台的交易单号 是	50	 
        public string reqsn { get; set; }// 商户交易单号  商户的交易订单号 否	32	 
        public string trxstatus { get; set; }// 交易状态    交易的状态,对于刷卡支付，该状态表示实际的支付结果，其他为下单状态 否	4	详见交易返回码说明
        public string fintime { get; set; }// 交易完成时间 yyyyMMddHHmmss  是	14	 
        public string acct { get; set; }// 支付平台用户标识     微信支付-用户的微信openid支付宝支付-用户user_id是	32	 
        public string trxcode { get; set; }// 交易类型    交易类型 是	8	见交易类型
        public string errmsg { get; set; }//  错误原因 失败的原因说明 是	100	 
        public string randomstr { get; set; }// 随机字符串   随机生成的字符串 否	32	 
        public string initamt { get; set; }// 原交易金额       是	15	 
        public string trxamt { get; set; }// 实际交易金额      是	15	参与优惠活动的实际交易金额
        public string fee { get; set; }// 手续费 是	15	单位：分
        public string cmid { get; set; }//    渠道子商户号 是	32	限微信/支付宝交易响应
        public string chnlid { get; set; }//  渠道号 是	32	限微信交易响应
        public string chnlextendparams { get; set; }//    渠道扩展字段 一般用于渠道的活动参数填写   是	-	 
        public string chnldata { get; set; }// 渠道信息    目前返回云闪付/微信/支付宝的活动参数 否	-	限交易参与活动
        public string sign { get; set; }//    签名 否	32	详见安全规范

    }

    public class ThirdTLQueryPayOurModel
    {

    }

    public class ThirdTLQueryPayInModel
    {
        public string retcode { get; set; } //返回码SUCCESS/FAIL 否	8此字段是通信标识，非交易结果，交易是否成功需要查看trxstatus来判断
        public string retmsg { get; set; }
        public string orgid { get; set; }
        public string cusid { get; set; }	 
        public string appid { get; set; } 
        public string trxid { get; set; } 
        public string version { get; set; }// 版本号
        public string reqsn { get; set; }// 商户交易单号  商户的交易订单号 否	32	 
        public string randomstr { get; set; }// 随机字符串   随机生成的字符串 否	32	 
        public string initamt { get; set; }// 原交易金额       是	15	 
        public string trxamt { get; set; }// 实际交易金额      是	15	参与优惠活动的实际交易金额
        public string sign { get; set; }//    签名 否	32	详见安全规范
    }

    public class ThirdTLQueryPayOutModel
    {
        public string retcode { get; set; } //返回码SUCCESS/FAIL 否	8此字段是通信标识，非交易结果，交易是否成功需要查看trxstatus来判断
        public string retmsg { get; set; }  //返回码说明 是	100
        public string cusid { get; set; }// 商户号 平台分配的商户号 否	15	 
        public string appid { get; set; }// 应用ID    平台分配的APPID 否	8	 
        public string trxid { get; set; }// 交易单号    收银宝平台的交易流水号 否	20	 
        public string chnltrxid { get; set; }// 渠道平台交易单号    例如微信,支付宝平台的交易单号 是	50	 
        public string reqsn { get; set; }// 商户交易单号  商户的交易订单号 否	32	 
        public string trxstatus { get; set; }// 交易状态    交易的状态,对于刷卡支付，该状态表示实际的支付结果，其他为下单状态 否	4	详见交易返回码说明
        public string fintime { get; set; }// 交易完成时间 yyyyMMddHHmmss  是	14	 
        public string acct { get; set; }// 支付平台用户标识     微信支付-用户的微信openid支付宝支付-用户user_id是	32	 
        public string trxcode { get; set; }// 交易类型    交易类型 是	8	见交易类型
        public string errmsg { get; set; }//  错误原因 失败的原因说明 是	100	 
        public string randomstr { get; set; }// 随机字符串   随机生成的字符串 否	32	 
        public string initamt { get; set; }// 原交易金额       是	15	 
        public string trxamt { get; set; }// 实际交易金额      是	15	参与优惠活动的实际交易金额
        public string fee { get; set; }// 手续费 是	15	单位：分
        public string cmid { get; set; }//    渠道子商户号 是	32	限微信/支付宝交易响应
        public string chnlid { get; set; }//  渠道号 是	32	限微信交易响应
        public string chnlextendparams { get; set; }//    渠道扩展字段 一般用于渠道的活动参数填写   是	-	 
        public string chnldata { get; set; }// 渠道信息    目前返回云闪付/微信/支付宝的活动参数 否	-	限交易参与活动
        public string sign { get; set; }//    签名 否	32	详见安全规范
        public string IsSuccess { get; set; }
    }

    public class ThirdTLClosePayOurModel
    {

    }

    public class ThirdTLClosePayInModel
    {

    }

    public class ThirdTLClosePayOutModel
    {

    }

    public class ThirdTLRefundPayOurModel
    {

    }

    public class ThirdTLRefundPayInModel
    {

    }

    public class ThirdTLRefundPayOutModel
    {

    }
}
