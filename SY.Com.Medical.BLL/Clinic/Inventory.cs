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
    public class Inventory 
	{
		private InventoryRepository db;
		public Inventory()
		{
			db = new InventoryRepository();
		}
		///<summary> 
		///获取详情记录
		///</summary> 
		///<param name="id"></param>
		/// <returns></returns>
		public InventoryModel get(int id)
		{
			var x = db.Get(id);
			InventoryModel model = new InventoryModel();
			model.InventoryId = x.InventoryId;
			model.GoodsCount = x.GoodsCount;			
			model.CreateTime = x.CreateTime.Value;
			return model;
		}
		///<summary> 
		///获取列表-分页
		///</summary> 
		///<param name="request"></param>
		/// <returns></returns>
		public Tuple<IEnumerable<InventoryModel>, int> gets(InventoryRequest request)
		{
			var datas = db.page(request.TenantId, request.PageSize, request.PageIndex, request.start, request.end, request.GoodName);
			List<InventoryModel> list = new List<InventoryModel>();
			datas.Item1.ToList().ForEach(x =>
			{
				InventoryModel model = new InventoryModel();
				model.InventoryId = x.InventoryId;
				model.GoodsCount = x.GoodsCount;
				model.CreateTime = x.CreateTime.Value;
				list.Add(model);
			});
			Tuple<IEnumerable<InventoryModel>, int> result = new(list, datas.Item2);
			return result;
		}
	}
} 