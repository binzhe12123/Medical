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
		public Good()
		{
			db = new GoodRepository();
		}


		/// <summary>
		/// 分页查询
		/// </summary>
		/// <param name="request"></param>
		/// <returns></returns>
		public Tuple<IEnumerable<GoodModel>, int> gets(GoodRequest request)
        {			
			var data = db.GetsPage(request.DtoToEntity<GoodEntity>(), request.PageSize, request.PageIndex);
			Tuple<IEnumerable<GoodModel>, int> result = new Tuple<IEnumerable<GoodModel>, int>(data.Item1.EntityToDto<GoodModel>(),data.Item2);
			return result;			
        }

		/// <summary>
		/// 单个详情
		/// </summary>
		/// <param name="GoodId"></param>
		/// <returns></returns>
		public GoodModel get(int GoodId)
        {
			return db.Get(GoodId).EntityToDto<GoodModel>();
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
                throw new MyException("该药品已经存在");
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

        /// <summary>
        /// 获取药品分类字典信息
        /// </summary>
        /// <returns></returns>
        public List<Dictionary<int, string>> getGoodSort(GoodSortReuqest request)
        {
            return db.getGoodSort(request.DicType).ToList();
        }

    }
} 