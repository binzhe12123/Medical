using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator
{
    /// <summary>
    /// Entity生成器
    /// </summary>
    public class EntityGen
    {

        public string NameSpace { get; private set; }
        public string EntityName { get; private set; }
        public string TableName { get;private set; }
        public string TableKey { get;private set; }
        private string Using { get; set; }
        private string Namespace { get; set; }
        

        public EntityGen(string tablename,string tablekey,string DataBase)
        {
            TableName = tablename;
            TableKey = tablekey;
            NameSpace = DataBase;
        }

        public string Gen()
        {
            string result = "";

            return result;
        }

        private string GenUsing()
        {
            return @"
                    using SY.Com.Medical.Attribute;
                    using SY.Com.Medical.Enum;
                    using System;
                    using System.Collections.Generic;
                    using System.Linq;
                    using System.Text;
                    using System.Threading.Tasks;
                    ";
        }

        private string GenNameSpance(string body)
        {
            return @"";
        }

    }
}
