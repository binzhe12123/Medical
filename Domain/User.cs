using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class User
    {
        public long ID { get; set; }//ID
        public string Name { get; set; }//姓名
        public string Sex { get; set; }//年龄
        public string BirthDay { get; set; }//出生年月
        public string SFZH { get; set; }//身份证号
        public string Phone { get; set; }//电话
        public string Profession { get; set; }//职业
        public string Title { get; set; }//职称
        public string YbCode { get; set; }//医保编码
        public string WJCode { get; set; }//卫监编码

        public string UserName { get; set; }//用户名
        public string PassWord { get; set; }//密码
        public DateTime CreateTime { get; set; }//创建日期



    }
}
