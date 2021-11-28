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
    public class Outpatient 
	{
		private OutpatientRepository db;
		public Outpatient()
		{
			db = new OutpatientRepository();
		}
		///<summary> 
		///获取详情记录
		///</summary> 
		///<param name="id"></param>
		/// <returns></returns>
		public OutpatientModel get(int id)
		{
			return db.Get(id).EntityToDto<OutpatientModel>();
		}
		///<summary> 
		///获取列表-分页
		///</summary> 
		///<param name="request"></param>
		/// <returns></returns>
		public Tuple<IEnumerable<OutpatientModel>,int> gets(OutpatientRequest request)
		{
			var datas  = db.GetsPage(request.DtoToEntity<OutpatientEntity>(), request.PageSize, request.PageIndex);
			Tuple<IEnumerable<OutpatientModel>, int> result = new(datas.Item1.EntityToDto<OutpatientModel>(), datas.Item2);
			return result;
		}
		///<summary> 
		///新增
		///</summary> 
		///<param name="request"></param>
		/// <returns></returns>
		public int add(OutpatientAdd request)
		{
			return db.Create(request.DtoToEntity<OutpatientEntity>());
		}
		///<summary> 
		///修改
		///</summary> 
		///<param name="request"></param>
		/// <returns></returns>
		public void update(OutpatientUpdate request)
		{
			db.Update(request.DtoToEntity<OutpatientEntity>());
		}
		///<summary> 
		///删除
		///</summary> 
		///<param name="request"></param>
		/// <returns></returns>
		public void delete(OutpatientDelete request)
		{
			db.Delete(request.DtoToEntity<OutpatientEntity>());
		}
	}
} 