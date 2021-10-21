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
    public class Dic 
	{
		private DicRepository db;
		public Dic()
		{
			db = new DicRepository();
		}
		///<summary> 
		///获取详情记录
		///</summary> 
		///<param name="id"></param>
		/// <returns></returns>
		public DicModel get(int id)
		{
			return db.Get(id).EntityToDto<DicModel>();
		}
		///<summary> 
		///获取列表-分页
		///</summary> 
		///<param name="request"></param>
		/// <returns></returns>
		public Tuple<IEnumerable<DicModel>,int> gets(DicRequest request)
		{
			var datas  = db.GetsPage(request.DtoToEntity<DicEntity>(), request.PageSize, request.PageIndex);
			Tuple<IEnumerable<DicModel>, int> result = new(datas.Item1.EntityToDto<DicModel>(), datas.Item2);
			return result;
		}
		///<summary> 
		///新增
		///</summary> 
		///<param name="request"></param>
		/// <returns></returns>
		public int add(DicAdd request)
		{
			request.SearchKey = request.DicKey.GetPinYinHead() + request.DicValue.GetPinYinHead();
			return db.Create(request.DtoToEntity<DicEntity>());
		}
		///<summary> 
		///修改
		///</summary> 
		///<param name="request"></param>
		/// <returns></returns>
		public void update(DicUpdate request)
		{
			request.SearchKey = request.DicKey.GetPinYinHead() + request.DicValue.GetPinYinHead();
			db.Update(request.DtoToEntity<DicEntity>());
		}
		///<summary> 
		///删除
		///</summary> 
		///<param name="request"></param>
		/// <returns></returns>
		public void delete(DicDelete request)
		{
			db.Delete(request.DtoToEntity<DicEntity>());
		}
	}
} 