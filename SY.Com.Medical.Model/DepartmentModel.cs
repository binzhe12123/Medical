using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SY.Com.Medical.Model
{
    public class DepartmentModel
    {
    }

    public class DepartmentResponse : BaseModel
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentCode { get; set; }
    }

    public class DepartmentCreateRequest : BaseModel
    {        
        public string DepartmentName { get; set; }
        public string DepartmentCode { get; set; }
    }

}
