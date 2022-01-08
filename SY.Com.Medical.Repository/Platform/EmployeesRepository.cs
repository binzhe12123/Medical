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
        public EmployeesRepository() : base() { }
        public EmployeesRepository(string connection) : base(connection) { }


        /// <summary>
        /// 获取诊所的员工
        /// </summary>
        /// <param name="TenantId"></param>
        /// <returns></returns>
        public Tuple<IEnumerable<EmployeeEntity>, int> getTenant(int tenantId, int pageSize,int pageIndex,string searchKey = "",string deparment = "")
        {
            //string sql = " Select * From Employees Where TenantId = @TenantId And IsEnable=@IsEnable And IsDelete = 1 ";
            string where = "";
            if(!string.IsNullOrEmpty(searchKey))
            {
                where += " And EmployeeName like '%"+ searchKey +"%' ";
            }
            if(!string.IsNullOrEmpty(deparment))
            {
                where += " And Departments like '%"+ deparment +"%' ";
            }
            string sqlpage = @$" 
            Select  count(1) as nums From Employees Where TenantId = @TenantId And IsEnable=@IsEnable And IsDelete = 1 {where}
            Select * From
            (
                Select  ROW_NUMBER() over(order by CreateTime desc) as row_id,* From Employees
                Where TenantId = @TenantId And IsEnable=@IsEnable And IsDelete = 1 {where} 
            )t
            Where t.row_id between {(pageIndex - 1) * pageSize + 1} and { pageIndex * pageSize }
            ";
            var multi = _db.QueryMultiple(sqlpage, new { TenantId = tenantId, IsEnable = Enum.Enable.启用 });
            int count = multi.Read<int>().First();
            IEnumerable<EmployeeEntity> datas = multi.Read<EmployeeEntity>();
            Tuple<IEnumerable<EmployeeEntity>, int> result = new Tuple<IEnumerable<EmployeeEntity>, int>(datas, count);
            return result;
        }

        /// <summary>
        /// 获取诊所的员工
        /// </summary>
        /// <param name="TenantId"></param>
        /// <returns></returns>
        public IEnumerable<EmployeeEntity> getTenantClose(int TenantId)
        {
            string sql = " Select * From Employees Where TenantId = @TenantId And IsEnable=@IsEnable ";
            return _db.Query<EmployeeEntity>(sql, new { TenantId = TenantId, IsEnable = Enum.Enable.禁用 });
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
        public EmployeeEntity getByUser(UserEntity user,int TenantId)
        {
            string sql = " Select * From Employees Where UserId = @UserId And TenantId=@TenantId ";
            return _db.Query<EmployeeEntity>(sql,new { UserId = user.UserId,TenantId=TenantId } ).FirstOrDefault();
        }
                

    }
}
