using SY.Com.Medical.BLL.Clinic;
using SY.Com.Medical.Entity;
using SY.Com.Medical.Extension;
using SY.Com.Medical.Model;
using SY.Com.Medical.Repository.Clinic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SY.Com.Medical.BLL.Clinic
{
    /// <summary>
    /// 业务逻辑层
    /// </summary>
    public class RegisterProject 
	{
		private RegisterProjectRepository db;
		public RegisterProject()
		{
			db = new RegisterProjectRepository();
		}

		public List<RegisterProjectModel> getByTenant(int tenantId)
        {
			var entitys = db.getByTenant(tenantId);
			if (entitys == null)
			{
				return null;
			}
			return entitys.EntityToDto<RegisterProjectModel>();
		}


		///<summary> 
		///获取详情记录
		///</summary> 
		///<param name="id"></param>
		/// <returns></returns>
		public RegisterProjectModel get(int id)
		{
			return db.Get(id).EntityToDto<RegisterProjectModel>();
		}
		///<summary> 
		///获取列表-分页
		///</summary> 
		///<param name="request"></param>
		/// <returns></returns>
		public Tuple<IEnumerable<RegisterProjectModel>,int> gets(RegisterProjectRequest request)
		{
			var datas  = db.GetsPage(request.DtoToEntity<RegisterProjectEntity>(), request.PageSize, request.PageIndex);
			Tuple<IEnumerable<RegisterProjectModel>, int> result = new(datas.Item1.EntityToDto<RegisterProjectModel>(), datas.Item2);
			return result;
		}
		///<summary> 
		///新增
		///</summary> 
		///<param name="request"></param>
		/// <returns></returns>
		public int add(RegisterProjectAdd request)
		{
			return db.Create(request.DtoToEntity<RegisterProjectEntity>());
		}
		///<summary> 
		///修改
		///</summary> 
		///<param name="request"></param>
		/// <returns></returns>
		public void update(RegisterProjectUpdate request)
		{
			db.Update(request.DtoToEntity<RegisterProjectEntity>());
		}
		///<summary> 
		///删除
		///</summary> 
		///<param name="request"></param>
		/// <returns></returns>
		public void delete(RegisterProjectDelete request)
		{
			db.Delete(request.DtoToEntity<RegisterProjectEntity>());
		}
	}
} 