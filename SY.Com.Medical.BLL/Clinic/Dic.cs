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
			int result;
			var exsists = gets(new DicRequest() { DicValue = request.DicValue, DicType = request.DicType });
			if (!exsists.Item1.Any())
			{
				request.SearchKey = request.DicValue.GetPinYinHead();
				result = db.Create(request.DtoToEntity<DicEntity>());
			}
			else {
				result = exsists.Item1.FirstOrDefault().DicId;
			}
			return result;
		}
		///<summary> 
		///修改
		///如果修改的新值系统有则返回存在的id否则插入并返回存在的id
		///</summary> 
		///<param name="request"></param>
		/// <returns></returns>
		public int update(DicUpdate request)
		{
			int result;
			var oldmod = get(request.DicId);
			var exsists = gets(new DicRequest() { DicValue = request.DicValue, DicType = oldmod.DicType });
			if (!exsists.Item1.Any())
			{
				var addmod = request.Mapping<DicAdd>();
				addmod.DicType = oldmod.DicType;
				result = add(addmod);
			}
			else {
				result = exsists.Item1.FirstOrDefault().DicId;
			}
			return result;
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