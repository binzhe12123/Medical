using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SY.Com.Medical.WebApi.Filter
{
    /// <summary>
    /// 自定义swagger的header中tenantid
    /// </summary>
    public class AddTenantIdHeaderParameter : IOperationFilter
    {
        /// <summary>
        /// 增加TenantId
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="context"></param>
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<OpenApiParameter>();
            operation.Parameters.Add(new OpenApiParameter()
            {
                Name = "TenantId",
                Description="租户ID",
                In = ParameterLocation.Header,
                Required = false
            });
        }
    }

}
