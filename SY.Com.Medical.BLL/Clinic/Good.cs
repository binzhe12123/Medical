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
    public class Good 
	{
		private GoodRepository db;
        private Dic dicbll = new Dic();
		public Good()
		{
			db = new GoodRepository();
		}


		/// <summary>
		/// 物品列表-分页查询
		/// </summary>
		/// <param name="request"></param>
		/// <returns></returns>
		public Tuple<List<GoodModels>, int> getGoods(int tenantId, int pageSize, int pageIndex, int goodType = 0, int goodSort = 0, string searchKey = "")
        {
            List<GoodModels> mods = new List<GoodModels>();
            var tuple = db.getPagesByWhere(tenantId, pageSize, pageIndex, goodType, goodSort, searchKey);
            int total = tuple.Item1;
            tuple.Item2.ForEach(x =>
            {
                GoodModels mod = new GoodModels();
                mod.GoodId = x.GoodId;
                mod.GoodName = x.GoodName;
                mod.Norm = x.Norm;
                mod.Factory = x.Factory;
                mod.GoodType = x.GoodType.ToString();
                mod.GoodSort = dicbll.getValueByKey(x.TenantId,"Drug",x.GoodType.ToString(),x.GoodSort);
                mod.GoodStandard = x.GoodStandard;
                mod.InsuranceCode = x.InsuranceCode;
                mod.CustomerCode = x.CustomerCode;
                mod.SalesUnit = x.SalesUnit;
                mod.CreateTime = x.CreateTime;
                mod.Price = Math.Round(x.Price / 1000.00, 3);
                mod.Stock = x.Stock;
                mods.Add(mod);
            });
            Tuple<List<GoodModels>, int> result = new Tuple<List<GoodModels>, int>(mods, total);
            return result;
        }

		/// <summary>
		/// 单个详情
		/// </summary>
		/// <param name="GoodId"></param>
		/// <returns></returns>
		public GoodModels get(int tenantId,int GoodId)
        {
            return "";
        }


        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public int add(GoodAdd request)
        {
            GoodEntity ge = new GoodEntity();
            ge.GoodName = request.GoodName;
            ge.Norm = request.Norm;
            ge.Factory = request.Factory;
            var olddata = db.Gets(ge);
            if(olddata != null && olddata.Any())
            {
                throw new MyException("该物品已经存在");
            }
            request.SearchKey = request.GoodName.GetPinYinHead() + request.InsuranceCode + request.GoodStandard;            
            return db.Create(request.DtoToEntity<GoodEntity>());
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="request"></param>
        public void update(GoodUpdate request)
        {
            request.SearchKey = request.GoodName.GetPinYinHead() + request.InsuranceCode + request.GoodStandard;
            db.Update(request.DtoToEntity<GoodEntity>());
        }

        /// <summary>
        /// 删除模型
        /// </summary>
        /// <param name="request"></param>
        public void delete(GoodDelete request)
        {            
            db.Delete(request.DtoToEntity<GoodEntity>());
        }


    }
} 