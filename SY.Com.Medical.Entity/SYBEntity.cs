using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SY.Com.Medical.Entity
{
    public class SYBEntity : BaseEntity
    {
    }

    public class YBSign
    {
        public int Id { get; set; }
        public int TenantId { get; set; }
        public int EmployeeId { get; set; }
        public int IsOpen { get; set; }
        public string SignNo { get; set; }
        public DateTime? CreateTime { get; set; }
    }

}
