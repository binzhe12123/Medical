using SY.Com.Medical.Entity;
using SY.Com.Medical.Model;
using SY.Com.Medical.Repository.Platform;
using System;
using System.Collections.Generic;

namespace SY.Com.Medical.BLL.Platform
{
    /// <summary>
    /// 实现平台业务
    /// </summary>
    public class Platform : CURDObject<PlatformsEntity>
    {
        public Platform() : base()
        {
            Entity = new PlatformsEntity();
            db = new PlatformsRepository();
        }

        public void initEntity(BaseModel model)
        {
            this.ModelToBLL<PlatformsEntity, BaseModel>(model);
        }

        public BaseResponse<PlatformCRes>  insert()
        {
            int platformid = base.Create(Entity);
            PlatformCRes datas = new PlatformCRes { PlatformId =  platformid}  ;
            BaseResponse<PlatformCRes> result = new BaseResponse<PlatformCRes>() {  Data = datas  };
            return result;
        }

        public BaseResponse<PlatformsEntity> Get()
        {
            PlatformsEntity entity = base.Get(Entity.PlatformId);
            BaseResponse<PlatformsEntity> result = new BaseResponse<PlatformsEntity>() { Data = entity };
            return result;
        }

        public void Update()
        {
            base.Update(Entity);
        }

        public void Delete()
        {
            base.Delete(Entity);
        }

        public IEnumerable<PlatformsEntity> Gets()
        {
            return base.Gets(Entity);
        }

        public Tuple<IEnumerable<PlatformsEntity>, int> Page(int pageSize,int pageIndex)
        {
            return base.GetsPage(Entity, pageSize, pageIndex);
        }

        public void UpdateBatch(IEnumerable<PlatformsEntity> collection)
        {
            base.Update(collection);
        }

        public void InsertBatch(IEnumerable<PlatformsEntity> collection)
        {
            base.Insert(collection);
        }

    }
}
