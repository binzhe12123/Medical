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
    public class ChargeRecord 
	{
		private ChargeRecordRepository db;
		public ChargeRecord()
		{
			db = new ChargeRecordRepository();
		}
		///<summary> 
		///获取详情记录
		///</summary> 
		///<param name="id"></param>
		/// <returns></returns>
		public ChargeRecordModel get(int id)
		{
			return db.Get(id).EntityToDto<ChargeRecordModel>();
		}
		///<summary> 
		///获取列表-分页
		///</summary> 
		///<param name="request"></param>
		/// <returns></returns>
		public Tuple<IEnumerable<ChargeRecordModel>,int> gets(ChargeRecordRequest request)
		{
			var datas  = db.GetsPage(request.DtoToEntity<ChargeRecordEntity>(), request.PageSize, request.PageIndex);
			Tuple<IEnumerable<ChargeRecordModel>, int> result = new(datas.Item1.EntityToDto<ChargeRecordModel>(), datas.Item2);
			return result;
		}
		///<summary> 
		///新增
		///</summary> 
		///<param name="request"></param>
		/// <returns></returns>
		public int add(ChargeRecordAdd request)
		{
			return db.Create(request.DtoToEntity<ChargeRecordEntity>());
		}
		///<summary> 
		///修改
		///</summary> 
		///<param name="request"></param>
		/// <returns></returns>
		public void update(ChargeRecordUpdate request)
		{
			db.Update(request.DtoToEntity<ChargeRecordEntity>());
		}
		///<summary> 
		///删除
		///</summary> 
		///<param name="request"></param>
		/// <returns></returns>
		public void delete(ChargeRecordDelete request)
		{
			db.Delete(request.DtoToEntity<ChargeRecordEntity>());
		}
	}
} 