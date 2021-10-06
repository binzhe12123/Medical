using Dapper;
using SY.Com.Medical.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SY.Com.Medical.Repository.Platform
{
    /// <summary>
    /// 员工
    /// </summary>
    public class EmployeesRepository : BaseRepository<EmployeeEntity>
    {

        /// <summary>
        /// 获取诊所的员工
        /// </summary>
        /// <param name="TenantId"></param>
        /// <returns></returns>
        public IEnumerable<EmployeeEntity> getTenant(int TenantId)
        {
            string sql = " Select * From Employees Where TenantId = @TenantId ";
            return _db.Query<EmployeeEntity>(sql, new { TenantId = TenantId });
        }

        //邀请员工
        public int InviteEmployee(UserEntity user,string Roles,int TenantId)
        {
            EmployeeEntity entity = new EmployeeEntity() { 
                 UserId = user.UserId,Roles = Roles,TenantId = TenantId
                 ,CreateTime = DateTime.Now,IsDelete= Enum.Delete.正常,IsEnable= Enum.Enable.启用
                 ,EmployeeName = user.Account
            };
            return Create(entity);
        }

        /// <summary>
        /// 根据用户信息获取员工信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public EmployeeEntity getByUser(UserEntity user)
        {
            string sql = " Select * From EmployeeEntity Where UserId = @UserId ";
            return _db.Query<EmployeeEntity>(sql, user).FirstOrDefault();
        }
        
    }
}
