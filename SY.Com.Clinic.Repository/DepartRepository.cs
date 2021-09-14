using SY.Com.Clinic.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace SY.Com.Clinic.Repository
{
    /// <summary>
    /// 科室
    /// </summary>
    public class DepartRepository : RepositoryBase2
    {
        //获取诊所的科室列表
        /// <summary>
        /// 看诊所有自己的副本么,有读取副本
        /// 没有读取系统标星
        /// </summary>
        /// <param name="ClinicId"></param>
        /// <returns></returns>
        public List<DepartmentModel> getDeparts(int ClinicId)
        {
            string sql = " Select * From Department Where ClinicId=@ClinicId And IsDelete = 0 ";

            SqlParameter[] param = new SqlParameter[] {
                    new SqlParameter("@ClinicId",SqlDbType.Int){ Value = ClinicId}
                };
            var departlist = DbHelperSQL.QueryList<DepartmentModel>(ClinicId, sql, param);
            if(departlist == null ||departlist.Count < 1)
            {
                string sql2 = " Select * From Department Where  Star = 1 And IsDelete = 0  ";
                departlist = DbHelperSQL.QueryList<DepartmentModel>(0, sql2);
            }
            return departlist;
        }

        //添加科室
        /// <summary>
        /// 如果还没有副本,从系统拉取副本再保存当前
        /// 如果有副本,只保存当前
        /// </summary>
        /// <param name="mod"></param>
        /// <returns></returns>
        public bool addDepart(DepartmentModel mod)
        {
            string sql = " Select * From Department Where ClinicId=@ClinicId And IsDelete = 0 ";

            SqlParameter[] param = new SqlParameter[] {
                    new SqlParameter("@ClinicId",SqlDbType.Int){ Value = mod.ClinicId }
            };
            var departlist = DbHelperSQL.QueryList<DepartmentModel>(mod.ClinicId, sql, param);
            if (departlist == null || departlist.Count < 1)
            {
                string sql2 = " Select * From Department Where  Star = 1 And IsDelete = 0  ";
                departlist = DbHelperSQL.QueryList<DepartmentModel>(0, sql2);
                departlist.Add(mod);
                string sql3 = @" insert into Department(ClinicId,Name,BureauCode,Code,Kind,Star) 
                                 Values(@ClinicId,@Name,@BureauCode,@Code,@Kind,@Star) ";
                long maxbh = IDBH.getBH(IDName.Department.ToString(), mod.ClinicId, departlist.Count);
                departlist.ForEach(x => x.BH = maxbh--);
                _dbClinic.getConnection().Execute(sql3, departlist);
            }
            else {
                string sql3 = @" insert into Department(ClinicId,Name,BureauCode,Code,Kind,Star) 
                                 Values(@ClinicId,@Name,@BureauCode,@Code,@Kind,@Star) ";
                mod.BH = IDBH.getBH(IDName.Department.ToString(), mod.ClinicId);
                _dbClinic.getConnection().Execute(sql3, departlist);
            }
            return true;
        }

        /// <summary>
        /// 修改科室
        /// 如果还没有副本,从系统拉取副本再保存当前
        /// 如果有副本,只保存当前
        /// </summary>
        /// <param name="mod"></param>
        /// <returns></returns>
        public bool updateDepart(DepartmentModel mod)
        {
            string sql = " Select * From Department Where ClinicId=@ClinicId And IsDelete = 0 ";

            SqlParameter[] param = new SqlParameter[] {
                    new SqlParameter("@ClinicId",SqlDbType.Int){ Value = mod.ClinicId }
            };
            var departlist = DbHelperSQL.QueryList<DepartmentModel>(mod.ClinicId, sql, param);
            if (departlist == null || departlist.Count < 1)
            {
                string sql2 = " Select * From Department Where  Star = 1 And IsDelete = 0  ";
                departlist = DbHelperSQL.QueryList<DepartmentModel>(0, sql2);                
                string sql3 = @" insert into Department(ClinicId,Name,BureauCode,Code,Kind,Star) 
                                 Values(@ClinicId,@Name,@BureauCode,@Code,@Kind,@Star) ";
                long maxbh = IDBH.getBH(IDName.Department.ToString(), mod.ClinicId, departlist.Count);
                departlist.ForEach(x => x.BH = maxbh--);
                _dbClinic.getConnection().Execute(sql3, departlist);
            }
            string sql4 = @" Update Department 
                            Set Name=@Name,BureauCode=@BureauCode,Code=@Code,Descrition=@Descrition
                            Where SysId=@SysId ";
            _dbClinic.getConnection().Execute(sql4, mod);
            return true;
        }



    }
}
