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
		public Tuple<List<GoodBllModels>, int> getGoods(int tenantId, int pageSize, int pageIndex, int goodType = 0, int goodSort = 0, string searchKey = "")
        {
            List<GoodBllModels> mods = new List<GoodBllModels>();
            var tuple = db.getPagesByWhere(tenantId, pageSize, pageIndex, goodType, goodSort, searchKey);
            int total = tuple.Item1;
            tuple.Item2.ForEach(x =>
            {
                GoodBllModels mod = new GoodBllModels();
                mod.GoodId = x.GoodId;
                mod.GoodName = x.GoodName;
                mod.Norm = x.Norm;
                mod.Factory = x.Factory;
                mod.GoodType = x.GoodType.ToString();
                mod.GoodSort = dicbll.getValueById(x.TenantId, x.GoodSort, "DrugSort",x.GoodType.ToString());
                mod.GoodStandard = x.GoodStandard;
                mod.InsuranceCode = x.InsuranceCode;
                mod.CustomerCode = x.CustomerCode;
                mod.SalesUnit = x.SalesUnit;
                mod.CreateTime = x.CreateTime;
                mod.Price = Math.Round(x.Price / 1000.00, 3);
                mod.Stock = x.Stock;
                mod.BarCode = x.BarCode;
                mod.Usage = x.Usage;
                mod.Single = x.Single;
                mod.EveryDay = x.EveryDay;
                mods.Add(mod);
            });
            Tuple<List<GoodBllModels>, int> result = new Tuple<List<GoodBllModels>, int>(mods, total);
            return result;
        }

		/// <summary>
		/// 单个详情
		/// </summary>
		/// <param name="GoodId"></param>
		/// <returns></returns>
		public GoodBllModel getGood(int tenantId,int GoodId)
        {
            var entity = db.getOneById(tenantId, GoodId);
            GoodBllModel mod = new GoodBllModel();
            mod.GoodId = entity.GoodId;
            mod.GoodName = entity.GoodName;
            mod.Norm = entity.Norm;
            mod.Factory = dicbll.getIdByValue(tenantId, entity.Factory,"Factory","") ;
            mod.GoodType = (int)entity.GoodType;
            mod.GoodSort = entity.GoodSort;
            mod.GoodStandard = entity.GoodStandard;
            mod.InsuranceCode = entity.InsuranceCode;
            mod.CustomerCode = entity.CustomerCode;
            mod.SalesUnit = entity.SalesUnit;
            mod.CreateTime = entity.CreateTime;
            mod.Price = Math.Round(entity.Price / 1000.00, 3);
            mod.Stock = entity.Stock;
            mod.BarCode = entity.BarCode;
            mod.Usage = dicbll.getIdByValue(tenantId,entity.Usage,"Usage", entity.GoodType.ToString());
            mod.Single = entity.Single;
            mod.EveryDay = dicbll.getIdByValue(tenantId,entity.EveryDay, "EveryDay","");
            return mod;
        }


        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public int add(GoodAdd request)
        {
            GoodEntity ge = new GoodEntity();
            ge.TenantId = request.TenantId;
            ge.GoodName = request.GoodName;
            ge.Norm = request.Norm;
            ge.Factory = dicbll.getValueById(request.TenantId, request.Factory, "Factory","")  ;
            var olddata = db.Gets(ge);
            if(olddata != null && olddata.Any())
            {
                throw new MyException("该物品已经存在");
            }
            request.SearchKey = request.GoodName.GetPinYinHead() + request.InsuranceCode + request.GoodStandard;
            GoodEntity entity = new GoodEntity();
            entity.TenantId = request.TenantId;
            entity.GoodName = request.GoodName;
            entity.Norm = request.Norm;
            entity.Factory = dicbll.getValueById(request.TenantId, request.Factory, "Factory", "");
            entity.GoodType = (Enum.GoodType)request.GoodType;
            entity.GoodSort = request.GoodSort;
            entity.GoodStandard = request.GoodStandard;
            entity.InsuranceCode = request.InsuranceCode;
            entity.CustomerCode = request.CustomerCode;
            entity.SalesUnit = request.SalesUnit;
            entity.CreateTime = DateTime.Now;
            entity.Price = 0;
            entity.Stock = 0;
            entity.BarCode = request.BarCode;
            entity.SearchKey = request.GoodName.GetPinYinHead() + request.InsuranceCode + request.GoodStandard;
            entity.Usage = dicbll.getValueById(request.TenantId, request.Usage, "Usage", entity.GoodType.ToString());
            entity.Single = request.Single;                       
            entity.EveryDay = dicbll.getValueById(request.TenantId, request.EveryDay, "EveryDay", "");
            return db.Create(entity);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="request"></param>
        public void update(GoodUpdate request)
        {            
            GoodEntity entity = new GoodEntity();
            entity.GoodId = request.GoodId;
            entity.TenantId = request.TenantId;
            entity.GoodName = request.GoodName;
            entity.Norm = request.Norm;
            entity.Factory = dicbll.getValueById(request.TenantId, request.Factory, "Factory", "");
            entity.GoodType = (Enum.GoodType)request.GoodType;
            entity.GoodSort = request.GoodSort;
            entity.GoodStandard = request.GoodStandard;
            entity.InsuranceCode = request.InsuranceCode;
            entity.CustomerCode = request.CustomerCode;
            entity.SalesUnit = request.SalesUnit;
            entity.CreateTime = DateTime.Now;
            entity.Price = 0;
            entity.Stock = 0;
            entity.BarCode = request.BarCode;
            entity.SearchKey = request.GoodName.GetPinYinHead() + request.InsuranceCode + request.GoodStandard;
            entity.Usage = dicbll.getValueById(request.TenantId, request.Usage, "Usage", entity.GoodType.ToString());
            entity.Single = request.Single;
            entity.EveryDay = dicbll.getValueById(request.TenantId, request.EveryDay, "EveryDay", "");
            db.Update(entity);
        }

        /// <summary>
        /// 删除模型
        /// </summary>
        /// <param name="request"></param>
        public void delete(GoodDelete request)
        {                        
            db.Delete(request.DtoToEntity<GoodEntity>());
        }

        /// <summary>
        /// 获取药品类型
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<DicKeyValueModel> getDrugSort(GoodSortModel mod)
        {
            return dicbll.getValueByKey(mod.TenantId,"DrugSort", ((Enum.GoodType)mod.Flag).ToString(),"");
        }

    }
} 