using SY.Com.Medical.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SY.Com.Medical.BLL.Clinic
{
    /// <summary>
    /// 门诊业务逻辑
    /// </summary>
    public class OutPatient
    {


        /// <summary>
        /// 挂号
        /// </summary>
        /// <returns></returns>
        public RegisterRecord Register(PatientUpdatedto patient,RegisterInfo info)
        {
            return new RegisterRecord();
        }


        public TreatRecord SaveTreat(TreatRecord info)
        {
            return new TreatRecord();
        }

        public AccountRecord PlanSettlement(TreatRecord info)
        {
            return new AccountRecord();
        }

        public PaymentRecord Settlement(AccountRecord info)
        {
            return new PaymentRecord();
        }



    }

    /// <summary>
    /// 
    /// </summary>
    public class RegisterRecord
    {

    }

    public class RegisterInfo
    {
         
    }

    public class PaymentRecord
    {

    }

    public class TreatRecord
    {

    }

    public class AccountRecord
    {

    }
    

}
